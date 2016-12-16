using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XMLimport
{
    public partial class formIgnoreList : Form
    {
        private Settings settings;

        public formIgnoreList()
        {
            InitializeComponent();
            settings = new Settings();
            this.Load += FormIgnoreList_Load;
            btnOK.Click += BtnOK_Click;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtList.Text))
                    settings.SaveIgnoreList(txtList.Lines);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException.Message, "Ошибка при обработке списка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormIgnoreList_Load(object sender, EventArgs e)
        {
            txtList.Lines = settings.IgnoreList;
        }
    }
}
