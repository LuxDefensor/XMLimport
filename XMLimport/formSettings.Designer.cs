namespace XMLimport
{
    partial class formSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMaxErrorLogLines = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnArchiver = new System.Windows.Forms.Button();
            this.txtArchiver = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkPackArchive = new System.Windows.Forms.CheckBox();
            this.txtStoreDepthMonths = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkRewrite = new System.Windows.Forms.CheckBox();
            this.chkIgnoreStatus = new System.Windows.Forms.CheckBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.btnArchive = new System.Windows.Forms.Button();
            this.btnInbox = new System.Windows.Forms.Button();
            this.txtArchive = new System.Windows.Forms.TextBox();
            this.txtInbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnExportFolder = new System.Windows.Forms.Button();
            this.txtExportFolder = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtDatabase);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 130);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "База данных";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(93, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(177, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(93, 74);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(177, 20);
            this.txtUser.TabIndex = 6;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(93, 49);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(177, 20);
            this.txtDatabase.TabIndex = 5;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(93, 24);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(177, 20);
            this.txtServer.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пользователь";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "База данных";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сервер";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnExportFolder);
            this.groupBox2.Controls.Add(this.txtExportFolder);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtMaxErrorLogLines);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnArchiver);
            this.groupBox2.Controls.Add(this.txtArchiver);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.chkPackArchive);
            this.groupBox2.Controls.Add(this.txtStoreDepthMonths);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.chkRewrite);
            this.groupBox2.Controls.Add(this.chkIgnoreStatus);
            this.groupBox2.Controls.Add(this.chkAutoStart);
            this.groupBox2.Controls.Add(this.btnArchive);
            this.groupBox2.Controls.Add(this.btnInbox);
            this.groupBox2.Controls.Add(this.txtArchive);
            this.groupBox2.Controls.Add(this.txtInbox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 148);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(585, 265);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Обработка XML";
            // 
            // txtMaxErrorLogLines
            // 
            this.txtMaxErrorLogLines.Location = new System.Drawing.Point(265, 231);
            this.txtMaxErrorLogLines.Name = "txtMaxErrorLogLines";
            this.txtMaxErrorLogLines.Size = new System.Drawing.Size(77, 20);
            this.txtMaxErrorLogLines.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(252, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Максимальный размер журнала ошибок (строк)";
            // 
            // btnArchiver
            // 
            this.btnArchiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnArchiver.Location = new System.Drawing.Point(551, 202);
            this.btnArchiver.Name = "btnArchiver";
            this.btnArchiver.Size = new System.Drawing.Size(28, 23);
            this.btnArchiver.TabIndex = 15;
            this.btnArchiver.Text = "...";
            this.btnArchiver.UseVisualStyleBackColor = true;
            // 
            // txtArchiver
            // 
            this.txtArchiver.Location = new System.Drawing.Point(129, 204);
            this.txtArchiver.Name = "txtArchiver";
            this.txtArchiver.Size = new System.Drawing.Size(416, 20);
            this.txtArchiver.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Программа-архиватор";
            // 
            // chkPackArchive
            // 
            this.chkPackArchive.AutoSize = true;
            this.chkPackArchive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkPackArchive.Location = new System.Drawing.Point(410, 145);
            this.chkPackArchive.Name = "chkPackArchive";
            this.chkPackArchive.Size = new System.Drawing.Size(135, 17);
            this.chkPackArchive.TabIndex = 12;
            this.chkPackArchive.Text = "Упаковывать архивы";
            this.chkPackArchive.UseVisualStyleBackColor = true;
            // 
            // txtStoreDepthMonths
            // 
            this.txtStoreDepthMonths.Location = new System.Drawing.Point(452, 113);
            this.txtStoreDepthMonths.Name = "txtStoreDepthMonths";
            this.txtStoreDepthMonths.Size = new System.Drawing.Size(93, 20);
            this.txtStoreDepthMonths.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(272, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Глубина хранения архивов (мес.)";
            // 
            // chkRewrite
            // 
            this.chkRewrite.AutoSize = true;
            this.chkRewrite.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRewrite.Location = new System.Drawing.Point(6, 176);
            this.chkRewrite.Name = "chkRewrite";
            this.chkRewrite.Size = new System.Drawing.Size(243, 17);
            this.chkRewrite.TabIndex = 9;
            this.chkRewrite.Text = "Перезаписывать существующие значения";
            this.chkRewrite.UseVisualStyleBackColor = true;
            // 
            // chkIgnoreStatus
            // 
            this.chkIgnoreStatus.AutoSize = true;
            this.chkIgnoreStatus.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIgnoreStatus.Location = new System.Drawing.Point(6, 145);
            this.chkIgnoreStatus.Name = "chkIgnoreStatus";
            this.chkIgnoreStatus.Size = new System.Drawing.Size(134, 17);
            this.chkIgnoreStatus.TabIndex = 8;
            this.chkIgnoreStatus.Text = "Игнорировать статус";
            this.chkIgnoreStatus.UseVisualStyleBackColor = true;
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAutoStart.Location = new System.Drawing.Point(5, 116);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(204, 17);
            this.chkAutoStart.TabIndex = 7;
            this.chkAutoStart.Text = "Запускать процесс автоматически";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // btnArchive
            // 
            this.btnArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnArchive.Location = new System.Drawing.Point(551, 50);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(28, 23);
            this.btnArchive.TabIndex = 5;
            this.btnArchive.Text = "...";
            this.btnArchive.UseVisualStyleBackColor = true;
            // 
            // btnInbox
            // 
            this.btnInbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnInbox.Location = new System.Drawing.Point(551, 22);
            this.btnInbox.Name = "btnInbox";
            this.btnInbox.Size = new System.Drawing.Size(28, 23);
            this.btnInbox.TabIndex = 4;
            this.btnInbox.Text = "...";
            this.btnInbox.UseVisualStyleBackColor = true;
            // 
            // txtArchive
            // 
            this.txtArchive.Location = new System.Drawing.Point(129, 52);
            this.txtArchive.Name = "txtArchive";
            this.txtArchive.Size = new System.Drawing.Size(416, 20);
            this.txtArchive.TabIndex = 3;
            // 
            // txtInbox
            // 
            this.txtInbox.Location = new System.Drawing.Point(129, 24);
            this.txtInbox.Name = "txtInbox";
            this.txtInbox.Size = new System.Drawing.Size(416, 20);
            this.txtInbox.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Архивная папка";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Папка входящих XML";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(441, 447);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отемна";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(522, 447);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnExportFolder
            // 
            this.btnExportFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExportFolder.Location = new System.Drawing.Point(551, 76);
            this.btnExportFolder.Name = "btnExportFolder";
            this.btnExportFolder.Size = new System.Drawing.Size(28, 23);
            this.btnExportFolder.TabIndex = 20;
            this.btnExportFolder.Text = "...";
            this.btnExportFolder.UseVisualStyleBackColor = true;
            // 
            // txtExportFolder
            // 
            this.txtExportFolder.Location = new System.Drawing.Point(129, 78);
            this.txtExportFolder.Name = "txtExportFolder";
            this.txtExportFolder.Size = new System.Drawing.Size(416, 20);
            this.txtExportFolder.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Папка экспорта";
            // 
            // formSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(610, 483);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "formSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button btnInbox;
        private System.Windows.Forms.TextBox txtArchive;
        private System.Windows.Forms.TextBox txtInbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIgnoreStatus;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.CheckBox chkRewrite;
        private System.Windows.Forms.TextBox txtStoreDepthMonths;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkPackArchive;
        private System.Windows.Forms.Button btnArchiver;
        private System.Windows.Forms.TextBox txtArchiver;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaxErrorLogLines;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnExportFolder;
        private System.Windows.Forms.TextBox txtExportFolder;
        private System.Windows.Forms.Label label10;
    }
}