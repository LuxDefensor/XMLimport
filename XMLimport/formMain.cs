﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.IO;

namespace XMLimport
{
    public partial class formMain : Form
    {
        private bool process;
        private Settings settings;
        private Dictionary<string, XmlDocument> xmls;
        private List<string> disposables;
        private List<string> pass;
        private FolderWatcher watcher;
        private XMLFeeder feeder;
        private Unarchive unarch;
        private Logger logger;
        private Archiver arc;
        private Reporter report;
        private string[] currentInfo;
        private int currentProgress;
        private string windowTitle = "Импорт данных из XML";
        private bool logDirty = false;

        private object lockProperties = new object();

        Thread thrXML;
        Thread thrFiles;
        Thread thrUnarch;
        Thread thrArc;
        Thread thrReport;

        public object sync = new object();

        public formMain()
        {
            InitializeComponent();
            try
            {
                settings = new Settings();
                xmls = new Dictionary<string, XmlDocument>();
                disposables = new List<string>();
                pass = new List<string>();
                this.logger = new Logger(settings.MaxErrorLogLines);
                try
                {
                    feeder = new XMLFeeder(this);
                }
                catch (Exception ex)
                {
                    logger.WriteError(ex.Message + Environment.NewLine + ex.InnerException.Message);
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.InnerException.Message + Environment.NewLine +
                        "Программа не сможет работать, пока эта проблема не будет решена" + Environment.NewLine +
                        "Пока!", "Неустранимая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
                watcher = new FolderWatcher(this, settings.InboxFolder, settings.ArchiveFolder);
                unarch = new Unarchive(this, settings.InboxFolder);
                arc = new Archiver(this);
                report = new Reporter(this);
                thrXML = new Thread(new ThreadStart(feeder.StartProcess));
                thrFiles = new Thread(new ThreadStart(watcher.StartProcess));
                thrUnarch = new Thread(new ThreadStart(unarch.StartProcess));
                thrArc = new Thread(new ThreadStart(arc.StartProcess));
                thrReport = new Thread(new ThreadStart(report.StartProcess));
                currentProgress = 0;
                currentInfo = new string[] { "", "", "", "", "", "", "", "", "", "", "" };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка в INI-файле", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
            #region Event handlers
            this.Load += FormMain_Load;
            this.FormClosing += FormMain_FormClosing;
            btnStart.Click += BtnStart_Click;
            btnStop.Click += BtnStop_Click;
            timer1.Tick += Timer1_Tick;
            menuExit.Click += MenuExit_Click;
            menuSettings.Click += MenuSettings_Click;
            menuCheckXML.Click += MenuCheckXML_Click;
            menuFindXML.Click += MenuFindXML_Click;
            menuIgnoreList.Click += MenuIgnoreList_Click;
            menuExportCodesList.Click += MenuExportCodesList_Click;
            menuBlackList.Click += MenuBlackList_Click;
            menuOpenInNotepad.Click += MenuOpenInNotepad_Click;
            menuOpenInIE.Click += MenuOpenInIE_Click;
            menuToProcess.Click += MenuToProcess;
            menuToCheck.Click += MenuToCheck;
            #endregion
        }

        private void MenuOpenInIE_Click(object sender, EventArgs e)
        {
            string selected, fileName;
            string[] files;
            if (dgvLog.SelectedCells.Count == 1)
            {
                selected = dgvLog[0, dgvLog.SelectedCells[0].RowIndex].Value.ToString();
                fileName = Path.GetFileNameWithoutExtension(selected);
                files = Directory.GetFiles(settings.ArchiveFolder, fileName + "*.xml");
                if (files.Length > 0)
                    System.Diagnostics.Process.Start("iexplore", files[files.Length - 1]);
            }
        }

        private void MenuOpenInNotepad_Click(object sender, EventArgs e)
        {
            string selected, fileName;
            string[] files;
            if (dgvLog.SelectedCells.Count == 1)
            {
                selected = dgvLog[0, dgvLog.SelectedCells[0].RowIndex].Value.ToString();
                fileName = Path.GetFileNameWithoutExtension(selected);
                files = Directory.GetFiles(settings.ArchiveFolder, fileName + "*.xml");
                if (files.Length > 0)
                    System.Diagnostics.Process.Start("notepad", files[files.Length - 1]);
            }
        }

        private void MenuToCheck(object sender, EventArgs e)
        {
            string selected, fileName;
            string[] files;
            if (dgvLog.SelectedCells.Count == 1)
            {
                selected = dgvLog[0, dgvLog.SelectedCells[0].RowIndex].Value.ToString();
                fileName = Path.GetFileNameWithoutExtension(selected);
                files = Directory.GetFiles(settings.ArchiveFolder, fileName + "*.xml");
                if (files.Length > 0)
                {
                    formCheck frm = new formCheck(files[files.Length - 1]);
                    frm.ShowDialog();
                }
            }
        }

        private void MenuToProcess(object sender, EventArgs e)
        {
            string selected = dgvLog[0, dgvLog.SelectedCells[0].RowIndex].Value.ToString();
            string fileName = Path.GetFileNameWithoutExtension(selected);
            string[] files = Directory.GetFiles(settings.ArchiveFolder, fileName + "*.xml");
            if (files.Length > 0)
            {
                fileName = files[files.Length - 1];
                try
                {
                    File.Move(fileName,
                        Path.Combine(settings.InboxFolder, selected));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно переместить файл " + selected +
                        Environment.NewLine + ex.Message, "Ошибка переноса XML на конвейер",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Файла " + selected + Environment.NewLine + " уже нет в архиве",
                    "Ошибка переноса XML на конвейр",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MenuBlackList_Click(object sender, EventArgs e)
        {
            formBlackList frm = new formBlackList();
            frm.ShowDialog(this);
        }

        private void MenuExportCodesList_Click(object sender, EventArgs e)
        {
            formExportList frm = new formExportList();
            frm.ShowDialog(this);
        }

        private void MenuFindXML_Click(object sender, EventArgs e)
        {
            formFind frm = new formFind();
            frm.ShowDialog(this);
        }

        private void MenuIgnoreList_Click(object sender, EventArgs e)
        {
            formIgnoreList frm = new formIgnoreList();
            frm.ShowDialog(this);

        }

        private void MenuCheckXML_Click(object sender, EventArgs e)
        {
            formCheck frm = new formCheck();
            frm.ShowDialog(this);
        }

        private void MenuSettings_Click(object sender, EventArgs e)
        {
            formSettings s = new formSettings();
            if (s.ShowDialog(this) == DialogResult.OK)
                MessageBox.Show("Изменения настроек вступят в силу только после перезапуска программы",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            txtWatcherStat.Text = thrFiles.ThreadState.ToString();
            txtUnarchStat.Text = thrUnarch.ThreadState.ToString();
            txtXML.Text = thrXML.ThreadState.ToString();
            txtReport.Text = thrReport.ThreadState.ToString();
            ShowCurrentInfo();
            UpdateProgress();
            if (logDirty)
                LoadLog();
            //UpdateLog();
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Text = "Подождите, прогррамма завершает текущие процессы и закрывается...";
            feeder.EndProcess();
            watcher.EndProcess();
            unarch.EndProcess();
            arc.EndProcess();
            report.EndProcess();
            while ((thrFiles.ThreadState != ThreadState.Stopped &&
                    thrFiles.ThreadState != ThreadState.Unstarted) ||
                   (thrXML.ThreadState != ThreadState.Stopped &&
                    thrXML.ThreadState != ThreadState.Unstarted) ||
                   (thrUnarch.ThreadState != ThreadState.Stopped &&
                    thrUnarch.ThreadState != ThreadState.Unstarted) ||
                   (thrArc.ThreadState != ThreadState.Stopped &&
                    thrArc.ThreadState != ThreadState.Unstarted) ||
                    thrReport.ThreadState != ThreadState.Stopped &&
                    thrReport.ThreadState != ThreadState.Unstarted)
            {
                Thread.Sleep(500);
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            process = false;
            this.Text = windowTitle + " (ПАУЗА)";
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            process = true;
            this.Text = windowTitle;
            if (thrXML.ThreadState == ThreadState.Stopped || thrXML.ThreadState == ThreadState.Unstarted)
                thrXML.Start();
            if (thrFiles.ThreadState == ThreadState.Stopped || thrFiles.ThreadState == ThreadState.Unstarted)
                thrFiles.Start();
            if (thrUnarch.ThreadState == ThreadState.Stopped || thrUnarch.ThreadState == ThreadState.Unstarted)
                thrUnarch.Start();
            if (thrReport.ThreadState == ThreadState.Stopped || thrReport.ThreadState == ThreadState.Unstarted)
                thrReport.Start();
        }

        public bool Process
        {
            get
            {
                return process;
            }
        }

        public Dictionary<string, XmlDocument> XMLs
        {
            get
            {
                return xmls;
            }
        }

        public List<string> Disposables
        {
            get
            {
                return disposables;
            }
        }

        internal Logger Logger
        {
            get
            {
                return logger;
            }
        }

        public List<string> Pass
        {
            get
            {
                return pass;
            }
        }

        public string[] CurrentInfo
        {
            
            get
            {
                return currentInfo;
            }
            set
            {
                lock (lockProperties)
                    currentInfo = value;
            }
        }

        public int CurrentProgress
        {
            get
            {
                return currentProgress;
            }

            set
            {
                currentProgress = value;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
            Directory.SetCurrentDirectory(Path.GetDirectoryName(Application.ExecutablePath));
            LoadLog();
            process = settings.RunOnStart;
            if (process)
            {
                Thread.Sleep(1000);
                thrFiles.Start();
                Thread.Sleep(500);
                thrUnarch.Start();
                Thread.Sleep(500);
                thrXML.Start();
                Thread.Sleep(1000);
                thrReport.Start();
            }
            timer1.Enabled = true;
        }

        private void ShowCurrentInfo()
        {
            txtFileName.Text = currentInfo[0];
            txtFileSize.Text = currentInfo[1];
            txtINN.Text = currentInfo[2];
            txtSenderName.Text = currentInfo[3];
            if (currentInfo[4] != "")
                txtXMLDay.Text = string.Format("{0}.{1}.{2}",
                    currentInfo[4].Substring(6), currentInfo[4].Substring(4, 2), currentInfo[4].Substring(0, 4));
            txtBeginning.Text = currentInfo[8];
            txtPointsCount.Text = currentInfo[5];
            txtValuesCount.Text = currentInfo[6];
            if (string.IsNullOrEmpty(currentInfo[7]))
                txtCompleted.Text = "0";
            else
                txtCompleted.Text = (int.Parse(currentInfo[7]) - 1).ToString();
            txtStatus.Text = currentInfo[10];
        }

        private void UpdateProgress()
        {
            txtCompleted.Text = CurrentProgress.ToString();
        }

        private void LoadLog()
        {
            dgvLog.Rows.Clear();
            string[] lines = logger.WorkingLogLines.Reverse().ToArray();
            foreach (string line in lines)
                dgvLog.Rows.Add(line.Split(';'));
            logDirty = false;
        }

        public void MarkLogChanged()
        {
            lock (lockProperties)
            {
                logDirty = true;
            }
        }

        public string[] ThreadsStat()
        {
            int threadsCount = 4;
            string[] result = new string[threadsCount];
            result[0] = "Файловый: " + thrFiles.ThreadState.ToString();
            result[1] = "Распаковка: " + thrUnarch.ThreadState.ToString();
            result[2] = "Обработка XML: " + thrXML.ThreadState.ToString();
            result[3] = "Самодиагностика: " + thrReport.ThreadState.ToString();
            return result;
        }


    }
}
