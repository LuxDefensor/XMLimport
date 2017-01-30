using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Threading;

namespace XMLimport
{
    class Reporter
    {
        private formMain main;
        private Settings s;
        private XElement currentRoot;
        private string report;
        bool isRunning;
        private string filter = @"^request_\w+.xml$";


        public Reporter(formMain main)
        {
            this.main = main;
            s = new Settings();
        }

        public void EndProcess()
        {
            isRunning = false;
        }

        public void StartProcess()
        {
            Regex regex = new Regex(filter);
            int stringLength = 40;
            XDocument xml;
            isRunning = true;
            StringBuilder report;
            while (isRunning)
            {
                if (main.Process)
                {
                    foreach (string f in Directory.GetFiles(s.InboxFolder))
                    {
                        if (regex.IsMatch(Path.GetFileName(f)))
                        {
                            Thread.Sleep(500);
                            report = new StringBuilder();
                            report.AppendLine("Отчёт о работоспособности компонентов АИИС КУЭ Пирамида 20000");
                            xml = new XDocument();
                            try
                            {
                                xml = XDocument.Load(f);
                            }
                            catch (Exception ex)
                            {
                                main.Logger.WriteError("Ошибка загрузки XML файла request: " +
                                    ex.Message);
                                File.Move(f, Path.Combine(Path.GetDirectoryName(f),
                                                          "error_" + Path.GetFileNameWithoutExtension(f) +
                                                          Path.GetExtension(f)));
                                continue;
                            }
                            foreach (XElement job in xml.Root.Descendants("job"))
                            {
                                report.AppendLine(new string('=', stringLength));
                                report.AppendLine(new string(' ', 5) + job.Attribute("description").Value);
                                report.AppendLine(new string('-', stringLength));
                                report.AppendLine();
                                switch (job.Attribute("name").Value.ToLower())
                                {
                                    case "isrunning":
                                        report.AppendLine("XMLimport " + (IsRunning() ? "работает" : "не отвечает"));
                                        break;
                                    case "threads":
                                        report.Append(string.Join(Environment.NewLine, ThreadsStat()));
                                        report.AppendLine();
                                        break;
                                    case "lastresult":
                                        report.Append(string.Join(Environment.NewLine, LastResults()));
                                        report.AppendLine();
                                        break;
                                    case "lasterror":
                                        report.AppendLine(LastError());
                                        break;
                                    case "inboxfiles":
                                        report.Append(string.Join(Environment.NewLine, InboxFiles()));
                                        report.AppendLine();
                                        break;
                                    case "mailbox":
                                        string logFolder;
                                        if (job.Attributes("folder").Count() > 0)
                                            logFolder = job.Attribute("folder").Value;
                                        else
                                            logFolder = Environment.CurrentDirectory;
                                        report.AppendLine(MailboxStatus(logFolder));
                                        break;
                                    case "scheduler":
                                        report.AppendLine(SchedulerStatus());
                                        break;
                                    default:
                                        report.AppendLine("Неизвестная задача: " + job.Attribute("name").Value);
                                        break;
                                } //switch (job.Attribute("name").Value.ToLower())
                            } // foreach (XElement job in xml.Root.Descendants("job"))
                            report.AppendLine();
                            report.AppendLine(new string('=', stringLength));
                            report.AppendLine("Отчёт сформирован автоматически по запросу. Время: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                            if (SendMail(report.ToString(), xml.Root.Descendants("address").First().Value))
                            {
                                string[] info =
                                {
                                    f,
                                    new FileInfo(f).Length.ToString(),
                                    "отчёт",
                                    xml.Root.Descendants("address").First().Value,
                                    string.Empty,
                                    xml.Descendants("job").Count().ToString(),
                                    string.Empty,
                                    string.Empty,
                                    string.Empty,
                                    DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"),
                                    "OK"
                                };
                                main.Logger.WriteWorkingLog(info);
                                File.Move(f, Path.Combine(s.ArchiveFolder,
                                                          Path.GetFileNameWithoutExtension(f) + "_arc" +
                                                          DateTime.Now.ToString("yyyyMMdd_HHmmss") +
                                                          Path.GetExtension(f)));
                            }
                            else
                            {
                                File.Move(f, Path.Combine(Path.GetDirectoryName(f),
                                                          "error_" + Path.GetFileNameWithoutExtension(f) +
                                                          Path.GetExtension(f)));
                            }

                        } // end of if (regex.IsMatch(f))
                    } // emd of foreach(string f in Directory.GetFiles(s.InboxFolder))
                } // end of if(main.Process)
                Thread.Sleep(1000);
            } // end of while(isRunning)
        } // end of the method

        public void ParseTasks(XDocument xml)
        {

        }


        private bool SendMail(string report, string addressTo)
        {
            MailMessage msg = new MailMessage(s.AddressFrom, addressTo,
                "Отчет о работоспособности компонентов ИВК «Пирамида 2000» от " + DateTime.Now.ToShortDateString(),
                report);
            try
            {
                SmtpClient smtp = new SmtpClient(s.SMTPServer, s.SMTPPort);
                if (s.UseSSL)
                    smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(s.SMTPUserName, s.SMTPPassword);
                smtp.Send(msg);

            }
            catch (Exception ex)
            {
                main.Logger.WriteError("Не удалось отправить отчет на " + addressTo + ": " + ex.Message);
                return false;
            }
            return true;
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
            log = main.Logger.WorkingLogLines;
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
            result = main.Logger.LastError;
            return result;
        }

        private string[] InboxFiles()
        {
            string[] result;
            result = System.IO.Directory.GetFiles(s.InboxFolder).Select(
                        file => System.IO.Path.GetFileName(file)).ToArray();
            return result;
        }

        private string MailboxStatus(string fetchMailLog)
        {
            string result;
            try
            {
                string[] log = File.ReadAllLines(fetchMailLog);
                result = log.Last();
            }
            catch (Exception ex)
            {
                result = "Не удалось получить статус почтового ящика. " + ex.Message;
            }
            return result;
        }

        private string SchedulerStatus()
        {
            string result;
            System.Diagnostics.Process[] processes =
                System.Diagnostics.Process.GetProcessesByName("Schedule");
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
