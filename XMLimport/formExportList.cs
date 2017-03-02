using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace XMLimport
{
    public partial class formExportList : Form
    {
        private bool dirty = false;
        private formMain main;

        public formExportList()
        {
            InitializeComponent();
            main = (formMain)Owner;
            this.Load += FormExportList_Load;
            btnOK.Click += BtnOK_Click;
            btnSelectFromList.Click += BtnSelectFromList_Click;
            txtCodes.TextChanged += TxtCodes_TextChanged;
        }

        private void TxtCodes_TextChanged(object sender, EventArgs e)
        {
            dirty = true;
        }

        private void BtnSelectFromList_Click(object sender, EventArgs e)
        {
            try
            {
                formSelect dlg = new formSelect(File.ReadAllLines(Settings.CodesFile));
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (txtCodes.Text.Length > 0)
                        txtCodes.Text += Environment.NewLine;
                    txtCodes.Text += dlg.Result.Split('=')[0].Trim();
                    dirty = true;
                }
            }
            catch (Exception ex)
            {
                main.Logger.WriteError("Ошибка чтения списка экспорта" +
                    Environment.NewLine + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка чтения списка для экспорта",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (dirty)
            {
                try
                {
                    File.WriteAllLines(Settings.ExportFile, txtCodes.Lines);
                }
                catch (Exception ex)
                {
                    main.Logger.WriteError("Ошибка записи списка для экспорта" +
                        Environment.NewLine + ex.Message);
                    MessageBox.Show(ex.Message, "Ошибка записи списка для экспорта",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }

        private void FormExportList_Load(object sender, EventArgs e)
        {
            try
            {
                txtCodes.Lines = File.ReadAllLines(Settings.ExportFile);
            }
            catch (Exception ex)
            {
                main.Logger.WriteError("Ошибка чтения списка экспорта" +
                    Environment.NewLine + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка чтения списка для экспорта",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }       



    }
}
