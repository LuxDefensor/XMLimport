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
        private string filter;
        private bool isRunning;

        public Unarchive(formMain mainForm, string inboxFolder)
        {
            main = mainForm;
            inbox = inboxFolder;
            filter = @"\w+.zip|\w+.rar";
        }

        public void EndProcess()
        {
            isRunning = false; 
        }

        public void StartProcess()
        {
            isRunning = true;
            Regex regex = new Regex(filter);
            Process p;
            while (isRunning)
            {
                if (main.Process)
                {
                    foreach (string f in Directory.GetFiles(inbox))
                    {
                        if (regex.IsMatch(f))
                        {
                            try
                            {
                                p = new Process();
                                p.StartInfo = new ProcessStartInfo("rar.exe", "e -y " + f + " " + inbox);
                                p.Start();
                                p.WaitForExit();
                                if (p.ExitCode == 0)
                                {
                                    Thread.Sleep(500);
                                    File.Delete(f);
                                }
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
    }
}
