using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Timers;

namespace XMLimport
{
    class Logger
    {
        private string errorLogPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "Errors.log");
        private string workingLogPrefix = Directory.GetCurrentDirectory() + @"\Logs\";
        private string currentWorkingLog;
        private int maxErrorLines;
        private Timer t;

        private object lockFiles = new object();

        public Logger(int maxErrorLines)
        {
            DateTime today;
            if (!Directory.Exists("Logs"))
                Directory.CreateDirectory("Logs");
            if (!File.Exists(errorLogPath))
                File.Create(errorLogPath);
            today = DateTime.Today.Date;
            currentWorkingLog = workingLogPrefix + today.Year + today.Month.ToString("00") + "01.csv";
            if (!File.Exists(currentWorkingLog))
            {
                var f = File.Create(currentWorkingLog);
                f.Close();
            }
            this.maxErrorLines = maxErrorLines;
            t = new Timer(3600000);
            t.Elapsed += T_Elapsed;
            t.Start();
        }

        private void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            DateTime today = DateTime.Today.Date;
            string newWorkingLog = workingLogPrefix + today.Year + today.Month.ToString("00") + "01.csv";
            if (newWorkingLog != currentWorkingLog)
            {
                currentWorkingLog = newWorkingLog;
                if (!File.Exists(currentWorkingLog))
                {
                    var f = File.Create(currentWorkingLog);
                    f.Close();
                }
            }
        }

        public void WriteError(string message)
        {
            lock (lockFiles)
            {
                string[] currentLog = File.ReadAllLines(errorLogPath);
                string[] newLog;
                if (currentLog.Length >= maxErrorLines)
                {
                    newLog = new string[maxErrorLines];
                    currentLog.CopyTo(newLog, 1);
                    newLog[maxErrorLines - 1] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + message;
                }
                else
                {
                    newLog = new string[currentLog.Length + 1];
                    currentLog.CopyTo(newLog, 0);
                    newLog[currentLog.Length] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + message;
                }
                File.WriteAllLines(errorLogPath, newLog);
            }

        }

        public void WriteWorkingLog(string[] info)
        {
            // BUG: Если открыть этот лог в Excel, появляется проблема с кодировкой
            lock (lockFiles)
            {
                StreamWriter writer = File.AppendText(currentWorkingLog);
                writer.WriteLine(string.Join(";", info));
                writer.Close();
            }
        }
        

        public string WorkingLog
        {
            get
            {
                lock (lockFiles)
                {
                    string[] lines = File.ReadAllLines(currentWorkingLog);
                    return string.Join(Environment.NewLine, lines.Reverse()).Replace(";", "\t");
                }
            }
        }

        public string[] WorkingLogLines
        {
            get
            {
                lock (lockFiles)
                {
                    string[] lines = File.ReadAllLines(currentWorkingLog);
                    return lines;
                }
            }
        }

        public string ErrorLog
        {
            get
            {
                lock (lockFiles)
                {
                    string[] lines = File.ReadAllLines(errorLogPath);
                    return string.Join(Environment.NewLine, lines.Reverse()).Replace(";", "\t");
                }
            }
        }

        public string[] ErrorLogLines
        {
            get
            {
                lock (lockFiles)
                {
                    string[] lines = File.ReadAllLines(errorLogPath);
                    return lines;
                }
            }
        }

        public string LastError
        {
            get
            {
                lock (lockFiles)
                    return File.ReadAllLines(errorLogPath).Last();
            }
        }
    }
}
