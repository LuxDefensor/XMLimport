using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XMLimport
{
    class Settings
    {
        private const string fName = "XMLimport.ini";
        private const string ignoreFile = "IgnoreStatus.lst";
        private static string exportFile = "ExportToXLS.lst";
        private static string codesFile = "XMLCodes.lst";
        private string server;
        private string database;
        private string userName;
        private string password;
        private bool runOnStart;
        private string inboxFolder;
        private string archiveFolder;
        private string exportFolder;
        private bool ignoreNonCommercialStatus;
        private bool rewrite;
        private int storeDepthMonths;
        private bool packArchive;
        private string archiveProgram;
        private string[] ignoreList;       
        private int maxErrorLogLines;
        private bool calculateSeason;
        private int season;

        #region Properties

        public static string CodesFile
        {
        get
            {
                return codesFile;
            }
        }

        public static string ExportFile
        {
        get
            {
                return exportFile;
            }
        }

        public string Server
        {
            get
            {
                return server;
            }
        }

        public string Database
        {
            get
            {
                return database;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
        }

        public bool RunOnStart
        {
            get
            {
                return runOnStart;
            }
        }

        public string InboxFolder
        {
            get
            {
                return inboxFolder;
            }
        }

        public string ArchiveFolder
        {
            get
            {
                return archiveFolder;
            }
        }

        public bool IgnoreNonCommercialStatus
        {
            get
            {
                return ignoreNonCommercialStatus;
            }
        }

        public bool Rewrite
        {
            get
            {
                return rewrite;
            }
        }

        public int StoreDepthMonths
        {
            get
            {
                return storeDepthMonths;
            }
        }

        public bool PackArchive
        {
            get
            {
                return packArchive;
            }
        }

        public string ArchiveProgram
        {
            get
            {
                return archiveProgram;
            }
        }

        public string[] IgnoreList
        {
            get
            {
                return ignoreList;
            }
        }

         public int MaxErrorLogLines
        {
            get
            {
                return maxErrorLogLines;
            }
        }

        public bool CalculateSeason
        {
            get
            {
                return calculateSeason;
            }
        }

        public int Season
        {
            get
            {
                return season;
            }
        }

        public string ExportFolder
        {
            get
            {
                return exportFolder;
            }
        }

        #endregion

        public Settings()
        {
            if (!File.Exists(fName))
            {
                throw new FileNotFoundException("Не найден INI-файл", fName);
            }
            try
            {
                string[] lines = File.ReadAllLines(fName);
                Dictionary<string, string> s = lines.ToDictionary<string, string, string>((string inp) => inp.Split('=')[0].Trim(),
                                                                                  (string el) => el.Split('=')[1].Trim());
                server = s["Server"];
                database = s["Database"];
                userName = s["UserName"];
                password = s["Password"];
                runOnStart = s["RunOnStart"] == "1";
                inboxFolder = s["InboxFolder"];
                if (!Directory.Exists(inboxFolder))
                {
                    throw new Exception("В INI-файле неверно задана папка для входящих XML");
                }
                archiveFolder = s["ArchiveFolder"];
                if (!Directory.Exists(archiveFolder))
                {
                    throw new Exception("В INI-файле неверно задана папка для архивов XML");
                }
                exportFolder = s["ExportFolder"];
                if (!Directory.Exists(exportFolder))
                {
                    throw new Exception("В INI-файле неверно задана папка для задач экспорта");
                }
                ignoreNonCommercialStatus = s["IgnoreNonCommercialStatus"] == "1";
                rewrite = s["Rewrite"] == "1";
                if (!int.TryParse(s["StoreDepthMonths"], out storeDepthMonths))
                    throw new Exception("Неверный формат параметра StoreDepthMonths в INI-файле");
                packArchive = s["PackArchive"] == "1";
                archiveProgram = s["ArchiveProgram"];             
                if (!int.TryParse(s["MaxErrorLogLines"], out maxErrorLogLines))
                    throw new Exception("Неверный формат параметра MaxErrorLogLines в INI-файле");
                calculateSeason = s["CalculateSeason"] == "1";
                if (calculateSeason)
                    season = GetSeason();
                else
                {
                    if (!int.TryParse(s["Season"], out season))
                        throw new Exception("Неверный флрмат параметра Season в INI-файле");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Невозможно прочитать настройки" + Environment.NewLine + ex.Message, ex);
            }
            if (!File.Exists(ignoreFile))
                ignoreList = new string[0];
            else
                try
                {
                    ignoreList = File.ReadAllLines(ignoreFile).ToArray();
                }
                catch (Exception ex)
                {
                    throw new Exception("Невозможно прочитать список исключений", ex);
                }
        }

        public void SaveSettings(string server, string database, string userName, string password,
            string inbox, string archive, string exportFolder, bool autoStart, bool ignoreStatus,
            bool rewrite, string storeDepth, bool packArchive, string archiver, string maxErrorLogLines)
        {
            string[] lines = new string[13];
            this.server = server;
            lines[0] = "Server=" + server;
            this.database = database;
            lines[1] = "Database" + database;
            this.userName = userName;
            lines[2] = "UserName=" + userName;
            this.password = password;
            lines[3] = "Password=" + password;
            this.runOnStart = autoStart;
            lines[4] = "RunOnStart" + (autoStart ? "1" : "0");
            this.inboxFolder = inbox;
            lines[5] = "InboxFolder=" + inbox;
            this.archiveFolder = archive;
            lines[6] = "ArchiveFolder=" + archive;
            this.exportFolder = exportFolder;
            lines[7] = "ExportFolder=" + exportFolder;
            this.ignoreNonCommercialStatus = ignoreStatus;
            lines[8] = "IgnoreNonCommercialStatus=" + (ignoreStatus ? "1" : "0");
            this.rewrite = rewrite;
            lines[9] = "Rewrite=" + (rewrite ? "1" : "0");
            if (!int.TryParse(storeDepth, out storeDepthMonths))
                throw new Exception("Неверный параметр: Глубина хранения архивов. Требуется целое число");
            lines[10] = "StoreDepthMonths=" + storeDepth;
            this.packArchive = packArchive;
            lines[11] = "PackArchive=" + packArchive;
            this.archiveProgram = archiver;
            lines[12] = "ArchiveProgram=" + archiver;
            if (!int.TryParse(maxErrorLogLines, out this.maxErrorLogLines))
                throw new Exception("Неверный параметр: Максимальный размер журнала ошибок. Требуется целое число");
            lines[13] = "MaxErrorLogLines=" + maxErrorLogLines;
            File.WriteAllLines(fName, lines);
        }

        public void SaveIgnoreList(string[] list)
        {
            try
            {
                ignoreList = list;
                File.WriteAllLines(ignoreFile, list);
            }
            catch (Exception ex)
            {
                throw new Exception("Невозможно сохранить список исключений. " + Environment.NewLine + ex.Message, ex);
            }
        }

        private int GetSeason()
        {
            DateTime springSwitch, autumnSwitch;
            int corr;
            springSwitch = new DateTime(2016, 3, 31);
            while (springSwitch.DayOfWeek != DayOfWeek.Sunday)
                springSwitch = springSwitch.AddDays(-1);
            autumnSwitch = new DateTime(2016, 10, 31);
            while (autumnSwitch.DayOfWeek != DayOfWeek.Sunday)
                autumnSwitch = autumnSwitch.AddDays(-1);
            if (DateTime.Today <= springSwitch)
                corr = 0;
            else if (DateTime.Today <= autumnSwitch)
                corr = 1;
            else
                corr = 2;
            return DateTime.Today.Year * 2 + corr;
        }
    }
}
