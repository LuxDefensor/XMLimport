using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XMLimport
{
    class Reporter
    {
        private formMain main;
        private Settings s;
        private XElement currentRoot;
        private string reprot;

        public Reporter(formMain main)
        {
            this.main = main;
            s = new Settings();
        }

        public void ParseTasks(XDocument xml)
        {

        }


        #region Report tasks
        private bool IsRunning()
        {
            // If this method executes at all it is enough to prove that the program is running
            return true;
        }

        private string[] ThreadsStat()
        {
            return main.ThreadsStat();
        }

        private string[] LastResults()
        {
            string[] result = new string[3];
            string[] log;
            string[] currentLine;
            lock (main.Logger)
            {
                log = main.Logger.WorkingLogLines;
            }
            for (int i = 0; i < 3; i++)
            {
                currentLine = log[log.Length - 1 - i].Split(';');
                result[i] = string.Format("Начало: {0}, конец: {1}, результат={2}",
                    currentLine[8], currentLine[9], currentLine[10]);
            }
            return result;
        }

        private string LastError()
        {
            string result;
            lock (main.Logger)
            {
                result = main.Logger.LastError;
            }
            return result;
        }

        private string[] InboxFiles()
        {
            string[] result;
            result = System.IO.Directory.GetFiles(s.InboxFolder).Select(
                        file => System.IO.Path.GetFileName(file)).ToArray();
            return result;
        }

        private string MailboxStatus()
        {
            return "No idea";
            // Maybe return the last line of th log of fetch.py script?
        }

        private string SchedulerStatus()
        {
            string result;
            System.Diagnostics.Process[] processes =
                System.Diagnostics.Process.GetProcessesByName("schedule.exe");
            switch (processes.Length)
            {
                case 0:
                    result = "Планировщик не запущен";
                    break;
                case 1:
                    result = processes[0].Responding ? "Планировщик работает" : "Планировщик не отвечает";
                    break;
                default:
                    result = "Запущено больше одного экземпляра планировщика";
                    break;
            }
            return result;
        }
        #endregion
    }
}
