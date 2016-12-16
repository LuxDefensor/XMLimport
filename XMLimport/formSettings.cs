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
    public partial class formSettings: Form
    {
        private Settings settings;
        private FolderBrowserDialog dlgFolder;
        private OpenFileDialog dlgFile;
        public formSettings()
        {
            InitializeComponent();
            try
            {
                settings = new Settings();
            }
            catch
            {
                MessageBox.Show("Проверьте файл настроек XMLimport.ini", "Ошибка в файле настроек",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            #region Event handlers
            this.Load += FormSettings_Load;
            btnOK.Click += BtnOK_Click;
            btnInbox.Click += PickFolder;
            btnArchive.Click += PickFolder;
            btnArchiver.Click += BtnArchiver_Click;
            #endregion
        }

        private void BtnArchiver_Click(object sender, EventArgs e)
        {
            dlgFile = new OpenFileDialog();
            dlgFile.Title = "Выберите программу-архиватор";
            dlgFile.CheckFileExists = true;
            dlgFile.CheckPathExists = true;
            dlgFile.DereferenceLinks = true;
            dlgFile.Filter = "Программы|*.exe";
            if (!string.IsNullOrEmpty(txtArchiver.Text) && System.IO.Directory.Exists(txtArchiver.Text))
                dlgFile.InitialDirectory = txtArchiver.Text;
            dlgFile.Multiselect = false;
            dlgFile.RestoreDirectory = true;
            if (dlgFile.ShowDialog(this.Owner) == DialogResult.OK)
                txtArchiver.Text = dlgFile.FileName;
        }

        private void PickFolder(object sender, EventArgs e)
        {
            TextBox target;
            string folderPurpose;
            Button button = sender as Button;
            if (button.Name == "btnInbox")
            {
                target = txtInbox;
                folderPurpose = "входящих";
            }
            else
            {
                target = txtArchive;
                folderPurpose = "архивных";
            }
            dlgFolder = new FolderBrowserDialog();
            dlgFolder.RootFolder = Environment.SpecialFolder.MyComputer;
            dlgFolder.ShowNewFolderButton = true;
            dlgFolder.Description = string.Format("Выберите папку для {0} XML", folderPurpose);
            if (!string.IsNullOrEmpty(target.Text))
                dlgFolder.SelectedPath = target.Text;
            if (dlgFolder.ShowDialog(this.Owner) == DialogResult.OK)
                target.Text = dlgFolder.SelectedPath;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                settings.SaveSettings(txtServer.Text,
                                      txtDatabase.Text,
                                      txtUser.Text,
                                      txtPassword.Text,
                                      txtInbox.Text,
                                      txtArchive.Text,
                                      chkAutoStart.Checked,
                                      chkIgnoreStatus.Checked,
                                      chkRewrite.Checked,
                                      txtStoreDepthMonths.Text,
                                      chkPackArchive.Checked,
                                      txtArchiver.Text,
                                      txtMaxErrorLogLines.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException.Message, "Неверные данные",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            txtServer.Text = settings.Server;
            txtDatabase.Text = settings.Database;
            txtUser.Text = settings.UserName;
            txtPassword.Text = settings.Password;
            txtInbox.Text = settings.InboxFolder;
            txtArchive.Text = settings.ArchiveFolder;
            chkAutoStart.Checked = settings.RunOnStart;
            chkIgnoreStatus.Checked = settings.IgnoreNonCommercialStatus;
            chkRewrite.Checked = settings.Rewrite;
            txtStoreDepthMonths.Text = settings.StoreDepthMonths.ToString();
            chkPackArchive.Checked = settings.PackArchive;
            txtArchiver.Text = settings.ArchiveProgram;
            txtMaxErrorLogLines.Text = settings.MaxErrorLogLines.ToString();
        }
    }
}
