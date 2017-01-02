﻿namespace XMLimport
{
    partial class formMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuXML = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCheckXML = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFindXML = new System.Windows.Forms.ToolStripMenuItem();
            this.menuService = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIgnoreList = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnStart = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtWatcherStat = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.txtUnarchStat = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.txtXML = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
            this.txtArc = new System.Windows.Forms.ToolStripTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCompleted = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtValuesCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPointsCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBeginning = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtXMLDay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtINN = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSenderName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFileSize = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuExportCodesList = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuXML,
            this.menuService});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1032, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(48, 20);
            this.menuFile.Text = "Файл";
            // 
            // menuExit
            // 
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(108, 22);
            this.menuExit.Text = "Выход";
            // 
            // menuXML
            // 
            this.menuXML.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCheckXML,
            this.menuFindXML});
            this.menuXML.Name = "menuXML";
            this.menuXML.Size = new System.Drawing.Size(43, 20);
            this.menuXML.Text = "XML";
            // 
            // menuCheckXML
            // 
            this.menuCheckXML.Name = "menuCheckXML";
            this.menuCheckXML.Size = new System.Drawing.Size(161, 22);
            this.menuCheckXML.Text = "Проверить XML";
            // 
            // menuFindXML
            // 
            this.menuFindXML.Name = "menuFindXML";
            this.menuFindXML.Size = new System.Drawing.Size(161, 22);
            this.menuFindXML.Text = "Найти XML";
            // 
            // menuService
            // 
            this.menuService.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettings,
            this.menuIgnoreList,
            this.menuExportCodesList});
            this.menuService.Name = "menuService";
            this.menuService.Size = new System.Drawing.Size(59, 20);
            this.menuService.Text = "Сервис";
            // 
            // menuSettings
            // 
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(225, 22);
            this.menuSettings.Text = "Настройки";
            // 
            // menuIgnoreList
            // 
            this.menuIgnoreList.Name = "menuIgnoreList";
            this.menuIgnoreList.Size = new System.Drawing.Size(225, 22);
            this.menuIgnoreList.Text = "Список исключений";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLog, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1032, 490);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStart,
            this.btnStop,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripLabel2,
            this.txtWatcherStat,
            this.toolStripLabel3,
            this.txtUnarchStat,
            this.toolStripLabel4,
            this.txtXML,
            this.toolStripLabel5,
            this.txtArc});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1032, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnStart
            // 
            this.btnStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStart.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnStart.ForeColor = System.Drawing.Color.Green;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(29, 22);
            this.btnStart.Text = "4";
            this.btnStart.ToolTipText = "Запуск конвейера";
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStop.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnStop.ForeColor = System.Drawing.Color.Red;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(29, 22);
            this.btnStop.Text = "<";
            this.btnStop.ToolTipText = "Остановка конвейера";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(67, 22);
            this.toolStripLabel1.Text = "Процессы:";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(65, 22);
            this.toolStripLabel2.Text = "файловый";
            // 
            // txtWatcherStat
            // 
            this.txtWatcherStat.Name = "txtWatcherStat";
            this.txtWatcherStat.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel3.Text = "распаковка";
            // 
            // txtUnarchStat
            // 
            this.txtUnarchStat.Name = "txtUnarchStat";
            this.txtUnarchStat.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(31, 22);
            this.toolStripLabel4.Text = "XML";
            // 
            // txtXML
            // 
            this.txtXML.Name = "txtXML";
            this.txtXML.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripLabel5
            // 
            this.toolStripLabel5.Name = "toolStripLabel5";
            this.toolStripLabel5.Size = new System.Drawing.Size(64, 22);
            this.toolStripLabel5.Text = "архивация";
            // 
            // txtArc
            // 
            this.txtArc.Name = "txtArc";
            this.txtArc.Size = new System.Drawing.Size(100, 25);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtStatus);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtCompleted);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtValuesCount);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtPointsCount);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtBeginning);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtXMLDay);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtINN);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtSenderName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtFileSize);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtFileName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1026, 144);
            this.panel1.TabIndex = 1;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(594, 100);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(100, 20);
            this.txtStatus.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(544, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Статус:";
            // 
            // txtCompleted
            // 
            this.txtCompleted.Location = new System.Drawing.Point(446, 100);
            this.txtCompleted.Name = "txtCompleted";
            this.txtCompleted.Size = new System.Drawing.Size(74, 20);
            this.txtCompleted.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(369, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Обработано:";
            // 
            // txtValuesCount
            // 
            this.txtValuesCount.Location = new System.Drawing.Point(274, 100);
            this.txtValuesCount.Name = "txtValuesCount";
            this.txtValuesCount.Size = new System.Drawing.Size(74, 20);
            this.txtValuesCount.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(211, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "значений:";
            // 
            // txtPointsCount
            // 
            this.txtPointsCount.Location = new System.Drawing.Point(136, 100);
            this.txtPointsCount.Name = "txtPointsCount";
            this.txtPointsCount.Size = new System.Drawing.Size(54, 20);
            this.txtPointsCount.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Количество ТИ в XML:";
            // 
            // txtBeginning
            // 
            this.txtBeginning.Location = new System.Drawing.Point(387, 71);
            this.txtBeginning.Name = "txtBeginning";
            this.txtBeginning.Size = new System.Drawing.Size(152, 20);
            this.txtBeginning.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Процесс начат:";
            // 
            // txtXMLDay
            // 
            this.txtXMLDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtXMLDay.Location = new System.Drawing.Point(122, 71);
            this.txtXMLDay.Name = "txtXMLDay";
            this.txtXMLDay.Size = new System.Drawing.Size(136, 20);
            this.txtXMLDay.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(9, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Расчётный день:";
            // 
            // txtINN
            // 
            this.txtINN.Location = new System.Drawing.Point(621, 32);
            this.txtINN.Name = "txtINN";
            this.txtINN.Size = new System.Drawing.Size(143, 20);
            this.txtINN.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(581, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "ИНН:";
            // 
            // txtSenderName
            // 
            this.txtSenderName.Location = new System.Drawing.Point(230, 32);
            this.txtSenderName.Name = "txtSenderName";
            this.txtSenderName.Size = new System.Drawing.Size(331, 20);
            this.txtSenderName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(151, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Отправитель:";
            // 
            // txtFileSize
            // 
            this.txtFileSize.Location = new System.Drawing.Point(64, 32);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.Size = new System.Drawing.Size(66, 20);
            this.txtFileSize.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Размер:";
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(82, 6);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(935, 20);
            this.txtFileName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя файла:";
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 178);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(1026, 309);
            this.txtLog.TabIndex = 2;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // menuExportCodesList
            // 
            this.menuExportCodesList.Name = "menuExportCodesList";
            this.menuExportCodesList.Size = new System.Drawing.Size(225, 22);
            this.menuExportCodesList.Text = "Список кодов для экспорта";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 514);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "formMain";
            this.Text = "Импорт данных из XML";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnStart;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtXMLDay;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtINN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSenderName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileSize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCompleted;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtValuesCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPointsCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBeginning;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtWatcherStat;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox txtUnarchStat;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox txtXML;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem menuXML;
        private System.Windows.Forms.ToolStripMenuItem menuService;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuIgnoreList;
        private System.Windows.Forms.ToolStripMenuItem menuCheckXML;
        private System.Windows.Forms.ToolStripMenuItem menuFindXML;
        private System.Windows.Forms.ToolStripLabel toolStripLabel5;
        private System.Windows.Forms.ToolStripTextBox txtArc;
        private System.Windows.Forms.ToolStripMenuItem menuExportCodesList;
    }
}

