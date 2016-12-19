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
            filterRAR = @"\w+.rar$";
            filterZIP = @"\w+.zip$";
        }

        public void EndProcess()
        {
            isRunning = false; 
        }

        public void StartProcess()
        {
            isRunning = true;
            Regex regexZIP = new Regex(filterZIP);
            Regex regexRAR = new Regex(filterRAR);
            Process p;
            while (isRunning)
            {
                if (main.Process)
                {
                    foreach (string f in Directory.GetFiles(inbox))
                    {
                        if (regexRAR.IsMatch(f))
                        {
                            try
                            {
                                Extract(f, Path.Combine(appFolder, "rar.exe"), "e -y " + f + " " + inbox);
                            }
                            catch (Exception ex)
                            {
                                lock (main.Logger)
                                {
                                    main.Logger.WriteError("Не удалось распаковать " + f + ": " + ex.Message);
                                }
                                File.Move(f,
                                    f + "_error"); // I deliberately cling it after the extension so that 
                                                   // program ingore it from now on until a human takes care of the file
                            }
                        }
                        else if (regexZIP.IsMatch(f))
                        {
                            try
                            {
                                Extract(f, Path.Combine(appFolder, "unzip.exe"), "-q " + f);
                            }
                            catch (Exception ex)
                            {
                                lock (main.Logger)
                                {
                                    main.Logger.WriteError("Не удалось распаковать " + f + ": " + ex.Message);
                                }
                                File.Move(f,
                                    f + "_error"); // I deliberately cling it after the extension so that 
                                                   // program ingore it from now on until a human takes care of the file
                            }
                        }

                    }
                }
                Thread.Sleep(1000);
            }

        }

        private void Extract(string fileName, string command, string args)
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
            }
        }
    }
}
