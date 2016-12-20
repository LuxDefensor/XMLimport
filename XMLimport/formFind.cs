using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace XMLimport
{
    public partial class formFind : Form
    {

        // TODO: Рассмотреть возможность замены двух кнопок ОК и Отмена на одну Закрыть
        // TODO: Сделать контекстное меню на результатах, чтобы можно было найденную xml-ку открыть в блокноте или IE
        private Settings s;
        private string fileName = "XMLCodes.lst";
        private List<string> lines;

        public formFind()
        {
            InitializeComponent();
            s = new Settings();
            this.Load += FormFind_Load;            
            btnLoad.Click += BtnLoad_Click;
            btnSave.Click += BtnSave_Click;
            btnFind.Click += BtnFind_Click;
            btnOK.Click += BtnOK_Click;
            btnDeselect.Click += BtnDeselect_Click;
            btnToProcess.Click += BtnToProcess_Click;
            btnToCheck.Click += BtnToCheck_Click;
            dgvResults.SelectionChanged += DgvResults_SelectionChanged;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnToCheck_Click(object sender, EventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 1)
            {
                formCheck frm = new formCheck(Path.Combine(s.ArchiveFolder, dgvResults.SelectedRows[0].Cells[0].Value.ToString()));
                frm.ShowDialog();
            }
        }

        private void DgvResults_SelectionChanged(object sender, EventArgs e)
        {
            txtSelected.Text = dgvResults.SelectedRows.Count.ToString();
        }

        private void BtnToProcess_Click(object sender, EventArgs e)
        {
            string selected = dgvResults.SelectedRows[0].Cells[0].Value.ToString();
            try
            {
                File.Move(Path.Combine(s.ArchiveFolder, selected),
                    Path.Combine(s.InboxFolder, selected));
                dgvResults.Rows.Remove(dgvResults.SelectedRows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно переместить файл " + selected +
                    Environment.NewLine + ex.Message, "Ошибка переноса XML на конвейер",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnDeselect_Click(object sender, EventArgs e)
        {
            dgvResults.ClearSelection();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            string pattern;
            dgvResults.Rows.Clear();
            string[] files;
            FileInfo f;
            if (dgvCodes.SelectedRows != null)
            {
                pattern = string.Format("80020_{0}_{1}*.xml",
                    dgvCodes.SelectedRows[0].Cells[0].Value.ToString(),
                    dtpDay.Value.ToString("yyyyMMdd"));
                files = Directory.GetFiles(s.ArchiveFolder, pattern);
                foreach (string file in files)
                {
                    f = new FileInfo(file);
                    dgvResults.Rows.Add(Path.GetFileName(file), f.Length, f.LastWriteTime);
                }
            }
            tabControl1.SelectTab(1);
            txtFound.Text = dgvResults.Rows.Count.ToString();
            txtSelected.Text = "0";
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            lines.Clear();
            foreach (DataGridViewRow row in dgvCodes.Rows)
            {
                if (!row.IsNewRow)
                    lines.Add(string.Format("{0}={1}", row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString()));
            }
            File.WriteAllLines(fileName, lines);
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            ReadCodes();
        }

        private void FormFind_Load(object sender, EventArgs e)
        {
            txtArchive.Text = s.ArchiveFolder;
            txtArchive.Enabled = false;
            ReadCodes(); 
        }

        private void ReadCodes()
        {
            if (File.Exists(fileName))
            {
                dgvCodes.Rows.Clear();
                lines = new List<string>(File.ReadAllLines(fileName));
                foreach (string line in lines)
                {
                    dgvCodes.Rows.Add(line.Split('='));
                }
            }
            else
            {
                var f = File.Create(fileName);
                f.Close();
                dgvCodes.Rows.Clear();
            }
        }

        private bool IsValid(string input)
        {
            string left = "";
            bool result = false;
            result = input.Contains("=");
            if (result)
                left = input.Split('=')[0];
            else
                result = false;
            Regex r = new Regex("\\D+");
            result = result && !r.Match(left).Success;
            return result;
        }

        private Tuple<string, string> ParseLine(string line)
        {
            string[] p = line.Split('=');
            Tuple<string, string> result = new Tuple<string, string>(p[0].Trim(' '), p[1].Trim(' '));
            return result;
        }
    }
}
