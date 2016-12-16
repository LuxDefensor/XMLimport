using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XMLimport
{
    class Logger
    {
        private string errorLogPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs", "Errors.log");
        private string workingLogPrefix = Directory.GetCurrentDirectory() + @"\Logs\";
        private string currentWorkingLog;
        private int maxErrorLines;

        public Logger(int maxErrorLines)
        {
            DateTime today;
            if (!Directory.Exists("Logs"))
                Directory.CreateDirectory("Logs");
            if (!File.Exists(errorLogPath))
                File.Create(errorLogPath);
            today = DateTime.Today.Date;
            currentWorkingLog = workingLogPrefix + today.Year + today.Month + "01.csv";
            if (!File.Exists(currentWorkingLog))
            {
                var f = File.Create(currentWorkingLog);
                f.Close();
            }
            this.maxErrorLines = maxErrorLines;
        }

        public void WriteError(string message)
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

        public void WriteWorkingLog(string[] info)
        {
            StreamWriter writer = File.AppendText(currentWorkingLog);
            writer.WriteLine(string.Join(";", info));
            writer.Close();
        }

        public string WorkingLog
        {
        get
            {
                string[] lines = File.ReadAllLines(currentWorkingLog);
                return string.Join(Environment.NewLine, lines.Reverse()).Replace(";"," - ");
            }
        }

    }
}
