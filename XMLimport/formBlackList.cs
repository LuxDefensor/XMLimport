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
    public partial class formBlackList : Form
    {
        private bool dirty = false;
        private formMain main;
        public formBlackList()
        {
            InitializeComponent();
            main = (formMain)Owner;
            this.Load += FormBlackList_Load;
            btnOK.Click += BtnOK_Click;
            btnAdd.Click += BtnAdd_Click;
            txtBlackList.TextChanged += TxtBlackList_TextChanged;
        }

        private void TxtBlackList_TextChanged(object sender, EventArgs e)
        {
            dirty = true; 
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                formSelect dlg = new formSelect(File.ReadAllLines(Settings.CodesFile));
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (txtBlackList.Text.Length > 0)
                        txtBlackList.Text += Environment.NewLine;
                    txtBlackList.Text += dlg.Result.Split('=')[0].Trim();
                    dirty = true;
                }
            }
            catch (Exception ex)
            {
                main.Logger.WriteError("Ошибка добавления ИНН в черный список" + Environment.NewLine + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка добавления ИНН в черный список",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (dirty)
            {
                try
                {
                    File.WriteAllLines(Settings.BlackList, txtBlackList.Lines);
                }
                catch (Exception ex)
                {
                    main.Logger.WriteError("Ошибка записи черного списка" + Environment.NewLine + ex.Message);
                    MessageBox.Show(ex.Message, "Ошибка записи черного списка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }

        private void FormBlackList_Load(object sender, EventArgs e)
        {
            try
            {
                txtBlackList.Lines = File.ReadAllLines(Settings.BlackList);
            }
            catch (Exception ex)
            {
                main.Logger.WriteError("Ошибка чтения черного списка" + Environment.NewLine + ex.Message);
                MessageBox.Show(ex.Message, "Ошибка чтения черного списка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
