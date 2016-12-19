using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace XMLimport
{
    class Archiver
    {
        private Settings s;
        private bool isRunning;
        private formMain main;

        public Archiver(formMain main)
        {
            s = new Settings();
            this.main = main;
        }

        public void EndProcess()
        {
            isRunning = false;
        }

        public void StartProcess()
        {
            isRunning = true;
            Process p;
            FileInfo file;
            while (isRunning)
            {
                if (main.Process)
                {
                    foreach (string f in Directory.GetFiles(s.ArchiveFolder))
                    {
                        file = new FileInfo(f);
                        if (file.LastWriteTime.AddMonths(2) < DateTime.Today && Path.GetExtension(f) == ".xml")
                        {
                            try
                            {
                                p = new Process();
                                p.StartInfo = new ProcessStartInfo("rar.exe a -df -y " + DateTime.Today.ToString("arcMMyyyy") + ".zip " + f);
                                p.Start();
                                p.WaitForExit();

                            }
                            catch (Exception ex)
                            {
                                lock (main.Logger)
                                {
                                    main.Logger.WriteError("Ошибка архивирования файла " + f +
                                        Environment.NewLine + ex.Message);
                                }
                                file.MoveTo(Path.Combine(s.ArchiveFolder + Path.GetFileNameWithoutExtension(f) + ".error"));
                            }
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }
    }
}
