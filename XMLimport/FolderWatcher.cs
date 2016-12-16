using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace XMLimport
{
    class FolderWatcher
    {
        private string inbox;
        private string archive;
        private formMain main;
        private string filter;
        private Settings settings;
        bool isRunning;

        public FolderWatcher(formMain mainForm, string inboxFolder,string archiveFolder)
        {
            settings = new Settings();
            main = mainForm;
            inbox = inboxFolder;
            archive = archiveFolder;
            filter = @"800[24]0_\w+.xml";
        }

        public void EndProcess()
        {
            isRunning = false;
        }

        public void StartProcess()
        {
            isRunning = true;
            XmlDocument xml;
            Regex regex = new Regex(filter);
            while (isRunning)
            {
                if (main.Process)
                {
                    lock (main.XMLs)
                    {
                        foreach (string f in Directory.GetFiles(inbox))
                        {
                            if (!main.XMLs.ContainsKey(f) &&
                                !main.Disposables.Contains(f) &&
                                !main.Pass.Contains(f) &&
                                regex.IsMatch(f))
                            {
                                xml = new XmlDocument();
                                try
                                {
                                    xml.Load(f);
                                }
                                catch (Exception ex)
                                {
                                    lock (main.Logger)
                                    {
                                        main.Logger.WriteError("Ошибка загрузки xml " + f + ": " + ex.Message);
                                    }
                                    main.Disposables.Add(f);
                                    continue;
                                }
                                main.XMLs.Add(f, xml);
                            }
                        }
                    }
                    List<string> copy_Disposables;
                    lock (main.Disposables)
                    {
                        copy_Disposables = new List<string>(main.Disposables);
                    }
                    foreach (string f in copy_Disposables)
                    {
                        try
                        {
                            File.Move(f,
                                Path.Combine(archive,
                                    Path.GetFileNameWithoutExtension(f) + "_arc" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + Path.GetExtension(f)));
                        }
                        catch (Exception ex)
                        {
                            lock (main.Logger)
                            {
                                main.Logger.WriteError("Невозможно переместить файл: " + f + ": " + ex.Message);
                                main.Pass.Add(f);
                            }
                        }
                        main.Disposables.Remove(f);
                    }

                }
                Thread.Sleep(1000);
            }

        }
    }
}
