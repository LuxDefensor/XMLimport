namespace XMLimport
{
    partial class formFind
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSearch = new System.Windows.Forms.TabPage();
            this.dgvCodes = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDay = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtArchive = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.btnToCheck = new System.Windows.Forms.Button();
            this.btnDeselect = new System.Windows.Forms.Button();
            this.txtSelected = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFound = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnToProcess = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFileSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOpenInNotepad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOpenInIE = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuToCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuToProcess = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOK = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuDeleteCode = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1.SuspendLayout();
            this.tabSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodes)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSearch);
            this.tabControl1.Controls.Add(this.tabResults);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(779, 503);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSearch
            // 
            this.tabSearch.Controls.Add(this.dgvCodes);
            this.tabSearch.Controls.Add(this.panel1);
            this.tabSearch.Controls.Add(this.label6);
            this.tabSearch.Controls.Add(this.txtArchive);
            this.tabSearch.Controls.Add(this.label5);
            this.tabSearch.Controls.Add(this.btnSave);
            this.tabSearch.Controls.Add(this.btnLoad);
            this.tabSearch.Controls.Add(this.label1);
            this.tabSearch.Location = new System.Drawing.Point(4, 22);
            this.tabSearch.Name = "tabSearch";
            this.tabSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabSearch.Size = new System.Drawing.Size(771, 477);
            this.tabSearch.TabIndex = 0;
            this.tabSearch.Text = "Поиск";
            this.tabSearch.UseVisualStyleBackColor = true;
            // 
            // dgvCodes
            // 
            this.dgvCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.Title});
            this.dgvCodes.ContextMenuStrip = this.contextMenuStrip2;
            this.dgvCodes.Location = new System.Drawing.Point(9, 40);
            this.dgvCodes.MultiSelect = false;
            this.dgvCodes.Name = "dgvCodes";
            this.dgvCodes.RowHeadersVisible = false;
            this.dgvCodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCodes.Size = new System.Drawing.Size(377, 431);
            this.dgvCodes.TabIndex = 14;
            // 
            // Code
            // 
            this.Code.HeaderText = "Код XML";
            this.Code.Name = "Code";
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.HeaderText = "Смежник";
            this.Title.Name = "Title";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dtpDay);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Location = new System.Drawing.Point(395, 182);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 61);
            this.panel1.TabIndex = 13;
            // 
            // dtpDay
            // 
            this.dtpDay.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtpDay.Location = new System.Drawing.Point(55, 30);
            this.dtpDay.Name = "dtpDay";
            this.dtpDay.Size = new System.Drawing.Size(187, 20);
            this.dtpDay.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Выбрать XML за период:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "с";
            // 
            // btnFind
            // 
            this.btnFind.ForeColor = System.Drawing.Color.Red;
            this.btnFind.Location = new System.Drawing.Point(248, 27);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 9;
            this.btnFind.Text = "Найти";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(392, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(323, 34);
            this.label6.TabIndex = 12;
            this.label6.Text = "Архивную папку можно изменить в настройках программы (меню Сервис -> Настройки)\r\n" +
    "\r\n";
            // 
            // txtArchive
            // 
            this.txtArchive.Location = new System.Drawing.Point(392, 96);
            this.txtArchive.Name = "txtArchive";
            this.txtArchive.Size = new System.Drawing.Size(367, 20);
            this.txtArchive.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(392, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(308, 34);
            this.label5.TabIndex = 10;
            this.label5.Text = "Поиск будет производиться в архивной папке, то есть, на данный момент в:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(322, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Сохранить в файл";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(187, 9);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(129, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Прочитать из файла";
            this.btnLoad.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Список кодов XML смежников";
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.btnToCheck);
            this.tabResults.Controls.Add(this.btnDeselect);
            this.tabResults.Controls.Add(this.txtSelected);
            this.tabResults.Controls.Add(this.label7);
            this.tabResults.Controls.Add(this.txtFound);
            this.tabResults.Controls.Add(this.label4);
            this.tabResults.Controls.Add(this.btnToProcess);
            this.tabResults.Controls.Add(this.dgvResults);
            this.tabResults.Location = new System.Drawing.Point(4, 22);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabResults.Size = new System.Drawing.Size(771, 477);
            this.tabResults.TabIndex = 1;
            this.tabResults.Text = "Результат";
            this.tabResults.UseVisualStyleBackColor = true;
            // 
            // btnToCheck
            // 
            this.btnToCheck.Location = new System.Drawing.Point(490, 429);
            this.btnToCheck.Name = "btnToCheck";
            this.btnToCheck.Size = new System.Drawing.Size(129, 42);
            this.btnToCheck.TabIndex = 7;
            this.btnToCheck.Text = "На проверку";
            this.btnToCheck.UseVisualStyleBackColor = true;
            // 
            // btnDeselect
            // 
            this.btnDeselect.Location = new System.Drawing.Point(208, 449);
            this.btnDeselect.Name = "btnDeselect";
            this.btnDeselect.Size = new System.Drawing.Size(162, 23);
            this.btnDeselect.TabIndex = 6;
            this.btnDeselect.Text = "Снять выделение";
            this.btnDeselect.UseVisualStyleBackColor = true;
            // 
            // txtSelected
            // 
            this.txtSelected.BackColor = System.Drawing.SystemColors.Control;
            this.txtSelected.Location = new System.Drawing.Point(133, 451);
            this.txtSelected.Name = "txtSelected";
            this.txtSelected.Size = new System.Drawing.Size(69, 20);
            this.txtSelected.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 454);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Выделено файлов:";
            // 
            // txtFound
            // 
            this.txtFound.BackColor = System.Drawing.SystemColors.Control;
            this.txtFound.Location = new System.Drawing.Point(133, 426);
            this.txtFound.Name = "txtFound";
            this.txtFound.Size = new System.Drawing.Size(69, 20);
            this.txtFound.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Найдено файлов:";
            // 
            // btnToProcess
            // 
            this.btnToProcess.Location = new System.Drawing.Point(625, 429);
            this.btnToProcess.Name = "btnToProcess";
            this.btnToProcess.Size = new System.Drawing.Size(129, 42);
            this.btnToProcess.TabIndex = 1;
            this.btnToProcess.Text = "На конвейер";
            this.btnToProcess.UseVisualStyleBackColor = true;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFileName,
            this.colFileSize,
            this.colDate});
            this.dgvResults.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvResults.Location = new System.Drawing.Point(16, 15);
            this.dgvResults.MultiSelect = false;
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(738, 408);
            this.dgvResults.TabIndex = 0;
            // 
            // colFileName
            // 
            this.colFileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colFileName.HeaderText = "Имя файла";
            this.colFileName.Name = "colFileName";
            this.colFileName.ReadOnly = true;
            // 
            // colFileSize
            // 
            this.colFileSize.HeaderText = "Размер";
            this.colFileSize.Name = "colFileSize";
            this.colFileSize.ReadOnly = true;
            this.colFileSize.Width = 80;
            // 
            // colDate
            // 
            dataGridViewCellStyle2.Format = "G";
            dataGridViewCellStyle2.NullValue = null;
            this.colDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDate.HeaderText = "Изменен";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 120;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpenInNotepad,
            this.menuOpenInIE,
            this.toolStripSeparator1,
            this.menuToCheck,
            this.toolStripSeparator2,
            this.menuToProcess});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(186, 104);
            // 
            // menuOpenInNotepad
            // 
            this.menuOpenInNotepad.Name = "menuOpenInNotepad";
            this.menuOpenInNotepad.Size = new System.Drawing.Size(185, 22);
            this.menuOpenInNotepad.Text = "Открыть в блокноте";
            // 
            // menuOpenInIE
            // 
            this.menuOpenInIE.Name = "menuOpenInIE";
            this.menuOpenInIE.Size = new System.Drawing.Size(185, 22);
            this.menuOpenInIE.Text = "Открыть в IE";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // menuToCheck
            // 
            this.menuToCheck.Name = "menuToCheck";
            this.menuToCheck.Size = new System.Drawing.Size(185, 22);
            this.menuToCheck.Text = "Проверить";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(182, 6);
            // 
            // menuToProcess
            // 
            this.menuToProcess.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.menuToProcess.Name = "menuToProcess";
            this.menuToProcess.Size = new System.Drawing.Size(185, 22);
            this.menuToProcess.Text = "На конвейер";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(685, 521);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "Закрыть";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDeleteCode});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(119, 26);
            // 
            // menuDeleteCode
            // 
            this.menuDeleteCode.Name = "menuDeleteCode";
            this.menuDeleteCode.Size = new System.Drawing.Size(152, 22);
            this.menuDeleteCode.Text = "Удалить";
            // 
            // formFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 556);
            this.ControlBox = false;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "formFind";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск XML";
            this.tabControl1.ResumeLayout(false);
            this.tabSearch.ResumeLayout(false);
            this.tabSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCodes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabResults.ResumeLayout(false);
            this.tabResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSearch;
        private System.Windows.Forms.TabPage tabResults;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtArchive;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.DateTimePicker dtpDay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToProcess;
        private System.Windows.Forms.ToolStripMenuItem menuOpenInNotepad;
        private System.Windows.Forms.ToolStripMenuItem menuOpenInIE;
        private System.Windows.Forms.DataGridView dgvCodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.Button btnDeselect;
        private System.Windows.Forms.TextBox txtSelected;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFound;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnToProcess;
        private System.Windows.Forms.Button btnToCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFileSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuToCheck;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem menuDeleteCode;
    }
}