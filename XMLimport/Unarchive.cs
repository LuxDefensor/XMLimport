using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

namespace XMLimport
{
    class Unarchive
    {
        private string inbox;
        private formMain main;
        private string appFolder = Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
        private string filterRAR, filterZIP;
        private bool isRunning;

        public Unarchive(formMain mainForm, string inboxFolder)
        {
            main = mainForm;
            inbox = inboxFolder;
            filterRAR = @"\w+.rar$|\w+.zip$";
            //filterZIP = @"\w+.zip$";
            filterZIP = "don't match";
        }

        public void EndProcess()
        {
            isRunning = false; 
        }

        public void StartProcess()
        {
            isRunning = true;
            //Regex regexZIP = new Regex(filterZIP);
            Regex detect = new Regex(filterRAR);
            Process p;
            while (isRunning)
            {
                if (main.Process)
                {
                    foreach (string f in Directory.GetFiles(inbox))
                    {
                        if (detect.IsMatch(f))
                        {
                            try
                            {
                                if (!Extract(f, Path.Combine(appFolder, "rar.exe"), "e -y " + Path.Combine(inbox, f)))
                                    if (!Extract(f, Path.Combine(appFolder, "unzip.exe"), "-q " + Path.Combine(inbox, f)))
                                    {
                                        main.Logger.WriteError("Не удалось распаковать " + f + ": распаковщик вернул ненулевой код");
                                        File.Move(f, f + "_error"); // I deliberately cling it after the extension so that 
                                                                    // program ingore it from now on until a human takes care of the file
                                    }
                            }
                            catch (Exception ex)
                            {
                                main.Logger.WriteError("Не удалось распаковать " + f + ": " + ex.Message);
                                File.Move(f, f + "_error"); // I deliberately cling it after the extension so that 
                                                            // program ingore it from now on until a human takes care of the file
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }

        }

        private bool Extract(string fileName, string command, string args)
        {
            Process p;
            p = new Process();            
            p.StartInfo = new ProcessStartInfo(command, args);
            p.StartInfo.WorkingDirectory = inbox;
            p.Start();
            p.WaitForExit();
            if (p.ExitCode == 0)
            {
                Thread.Sleep(500);
                File.Delete(fileName);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
