using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Threading;
using System.IO;

namespace XMLimport
{
    class XMLFeeder
    {
        private Model m;
        private formMain main;
        private Settings settings;
        private bool isRunning;

        private string[] ignores;

        public XMLFeeder(formMain mainForm)
        {
            settings = new Settings();
            main = mainForm;
            m = new Model(settings.Server, settings.Database, settings.UserName, settings.Password, settings.Season);
            m.PrepareTable();
            ignores = settings.IgnoreList;
        }

        public void EndProcess()
        {
            isRunning = false;
        }

        public void StartProcess()
        {
            ProcessingViaXMLLinq();
        }

        public void DirectProcessing()
        {
            // XML parsing and writing into database
            isRunning = true;
            Dictionary<string, XmlDocument> xmls_copy;
            XmlDocument currentXML;
            string[] info = new string[11];
            bool IgnoreStatus = settings.IgnoreNonCommercialStatus;
            DateTime day;
            DateTime timePoint;
            string extractTime;

            string objSpecCode;
            string channelCode;
            string deviceCode, deviceID, subdeviceCode, subdeviceID, sensorCode;

            bool rewrite = settings.Rewrite;
            float value;

            int completed;

            while (isRunning)
            {
                if (main.Process)
                {
                    lock (main.XMLs)
                    {
                        xmls_copy = new Dictionary<string, XmlDocument>(main.XMLs);
                    }
                    if (xmls_copy.Count > 0)
                    {
                        completed = 0;
                        foreach (KeyValuePair<string, XmlDocument> xml in xmls_copy)
                        {
                            currentXML = xml.Value;
                            try
                            {
                                info[0] = Path.GetFileName(xml.Key); // xml file name
                                info[1] = currentXML.InnerXml.Length.ToString(); // File size
                                info[2] = currentXML.SelectNodes("/message/sender/inn[1]")[0].FirstChild.Value; // INN
                                info[3] = currentXML.SelectNodes("/message/sender/name[1]")[0].FirstChild.Value; // Sender name
                                info[4] = currentXML.SelectNodes("/message/datetime/day[1]")[0].FirstChild.Value; // XML day
                                info[5] = currentXML.SelectNodes("/message//measuringpoint").Count.ToString(); // Count of measuring points
                                info[6] = currentXML.SelectNodes("/message//value").Count.ToString(); // Count of values
                                info[7] = "0"; // Count of processed values
                                info[8] = DateTime.Now.ToString("yyyy-MM-dd HH:mm"); // Process starting time
                                info[9] = ""; // Process ending time
                                info[10] = "работа"; // Status
                            }
                            catch (Exception ex)
                            {
                                lock (main.Logger)
                                {
                                    main.Logger.WriteError("Ошибка прасинга XML: " + info[0] + " " + ex.Message);
                                    info[10] = "ошибка";
                                    main.Logger.WriteWorkingLog(info);
                                }
                                lock (main.XMLs)
                                {
                                    main.XMLs.Remove(xml.Key);
                                    main.Disposables.Add(xml.Key);
                                }
                                continue;
                            }
                            try
                            {
                                IgnoreStatus = IgnoreStatus || settings.IgnoreList.Contains(info[2]); // Is it in the ignore status list
                                day = new DateTime(int.Parse(info[4].Substring(0, 4)),
                                                   int.Parse(info[4].Substring(4, 2)),
                                                   int.Parse(info[4].Substring(6)));
                                main.CurrentInfo = info;
                                main.CurrentProgress = 0;
                                foreach (XmlNode nodePoint in currentXML.SelectNodes("/message//measuringpoint"))
                                {
                                    // Find all identifiers
                                    objSpecCode = nodePoint.Attributes["code"].Value;
                                    Tuple<string, string> dev_subdev;
                                    try
                                    {
                                        dev_subdev = m.FullSubdevice(objSpecCode);
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                    deviceCode = dev_subdev.Item1;
                                    subdeviceCode = dev_subdev.Item2;
                                    foreach (XmlNode nodeChannel in nodePoint.SelectNodes("child::measuringchannel"))
                                    {
                                        channelCode = nodeChannel.Attributes["code"].Value;
                                        try
                                        {
                                            sensorCode = m.ItemCodeFromObject(channelCode, deviceCode, subdeviceCode);
                                        }
                                        catch
                                        {
                                            continue;
                                        }
                                        foreach (XmlNode nodeValue in nodeChannel.SelectNodes("child::period"))
                                        {
                                            extractTime = nodeValue.Attributes["end"].Value;
                                            if (extractTime == "0000")
                                                timePoint = day.AddDays(1);
                                            else
                                                timePoint = new DateTime(day.Year, day.Month, day.Day,
                                                    int.Parse(extractTime.Substring(0, 2)), int.Parse(extractTime.Substring(2)), 0);
                                            XmlNode val = nodeValue.SelectNodes("child::value")[0];
                                            value = float.Parse(val.FirstChild.Value.Replace(',', '.'), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                                            value *= 2;
                                            if (IgnoreStatus || val.Attributes.Count == 0 || val.Attributes["status"].Value == "0")
                                            {
                                                m.WriteValue(12, timePoint, int.Parse(deviceCode), int.Parse(sensorCode),
                                                    0, value, 0, 0,
                                                    rewrite ? 0 : 1, 0);
                                                completed++;
                                            }
                                            main.CurrentProgress = completed;
                                        }
                                    }
                                }
                                info[7] = (completed - 1).ToString(); // Count of processed values
                                info[9] = DateTime.Now.ToString("HH:mm"); // Process ending time     
                                main.CurrentInfo = info;
                            }
                            catch (Exception ex)
                            {
                                lock (main.Logger)
                                {
                                    main.Logger.WriteError("Ошибка обработки xml " + info[0] + ": " + ex.Message +
                                        Environment.NewLine + ex.InnerException.Message);
                                }
                                lock (main.XMLs)
                                {
                                    main.XMLs.Remove(xml.Key);
                                    main.Disposables.Add(xml.Key);
                                    info[10] = "Ошибка";
                                    main.Logger.WriteWorkingLog(info);
                                    continue;
                                }
                            }
                            info[10] = "OK"; // Process result
                            lock (main.Logger)
                            {
                                main.Logger.WriteWorkingLog(info);
                            }
                            lock (main.XMLs)
                            {
                                main.XMLs.Remove(xml.Key);
                                main.Disposables.Add(xml.Key);
                            }
                            main.CurrentInfo = info;
                        }
                    }
                }
                Thread.Sleep(500);
            }
        }

        public void ProcessingViaDataset()
        {
            // XML parsing and writing into database
            isRunning = true;
            Dictionary<string, XmlDocument> xmls_copy;
            XmlDocument currentXML;
            string[] info = new string[11];
            bool IgnoreStatus = settings.IgnoreNonCommercialStatus;
            DateTime day;
            DateTime timePoint;
            string extractTime;

            string objSpecCode;
            string channelCode;
            string deviceCode, deviceID, subdeviceCode, subdeviceID, sensorCode;

            bool rewrite = settings.Rewrite;
            float value;

            int completed;

            while (isRunning)
            {
                if (main.Process)
                {
                    lock (main.XMLs)
                    {
                        xmls_copy = new Dictionary<string, XmlDocument>(main.XMLs);
                    }
                    if (xmls_copy.Count > 0)
                    {
                        completed = 0;
                        foreach (KeyValuePair<string, XmlDocument> xml in xmls_copy)
                        {
                            currentXML = xml.Value;
                            m.ClearDataSet();
                            try
                            {
                                info[0] = Path.GetFileName(xml.Key); // xml file name
                                info[1] = currentXML.InnerXml.Length.ToString(); // File size
                                info[2] = currentXML.SelectNodes("/message/sender/inn[1]")[0].FirstChild.Value; // INN
                                info[3] = currentXML.SelectNodes("/message/sender/name[1]")[0].FirstChild.Value; // Sender name
                                info[4] = currentXML.SelectNodes("/message/datetime/day[1]")[0].FirstChild.Value; // XML day
                                info[5] = currentXML.SelectNodes("/message//measuringpoint").Count.ToString(); // Count of measuring points
                                info[6] = currentXML.SelectNodes("/message//value").Count.ToString(); // Count of values
                                info[7] = "0"; // Count of processed values
                                info[8] = DateTime.Now.ToString("yyyy-MM-dd HH:mm"); // Process starting time
                                info[9] = ""; // Process ending time
                                info[10] = "работа"; // Status
                            }
                            catch (Exception ex)
                            {
                                lock (main.Logger)
                                {
                                    main.Logger.WriteError("Ошибка прасинга XML: " + info[0] + " " + ex.Message);
                                    info[10] = "ошибка";
                                    main.Logger.WriteWorkingLog(info);
                                }
                                lock (main.XMLs)
                                {
                                    main.XMLs.Remove(xml.Key);
                                    main.Disposables.Add(xml.Key);
                                }
                                continue;
                            }
                            try
                            {
                                IgnoreStatus = IgnoreStatus || settings.IgnoreList.Contains(info[2]); // Is it in the ignore status list
                                day = new DateTime(int.Parse(info[4].Substring(0, 4)),
                                                   int.Parse(info[4].Substring(4, 2)),
                                                   int.Parse(info[4].Substring(6)));
                                main.CurrentInfo = info;
                                main.CurrentProgress = 0;
                                foreach (XmlNode nodePoint in currentXML.SelectNodes("/message//measuringpoint"))
                                {
                                    // Find all identifiers
                                    objSpecCode = nodePoint.Attributes["code"].Value;
                                    Tuple<string, string> dev_subdev;
                                    try
                                    {
                                        dev_subdev = m.FullSubdevice(objSpecCode);
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                    deviceCode = dev_subdev.Item1;
                                    subdeviceCode = dev_subdev.Item2;
                                    foreach (XmlNode nodeChannel in nodePoint.SelectNodes("child::measuringchannel"))
                                    {
                                        channelCode = nodeChannel.Attributes["code"].Value;
                                        try
                                        {
                                            sensorCode = m.ItemCodeFromObject(channelCode, deviceCode, subdeviceCode);
                                        }
                                        catch
                                        {
                                            continue;
                                        }
                                        foreach (XmlNode nodeValue in nodeChannel.SelectNodes("child::period"))
                                        {
                                            extractTime = nodeValue.Attributes["end"].Value;
                                            if (extractTime == "0000")
                                                timePoint = day.AddDays(1);
                                            else
                                                timePoint = new DateTime(day.Year, day.Month, day.Day,
                                                    int.Parse(extractTime.Substring(0, 2)), int.Parse(extractTime.Substring(2)), 0);
                                            XmlNode val = nodeValue.SelectNodes("child::value")[0];
                                            value = float.Parse(val.FirstChild.Value.Replace(',', '.'), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                                            value *= 2;
                                            if (IgnoreStatus || val.Attributes.Count == 0 || val.Attributes["status"].Value == "0")
                                            {
                                                m.WriteValue(12, timePoint, int.Parse(deviceCode), int.Parse(sensorCode),
                                                    0, value, 0, 0,
                                                    rewrite ? 0 : 1, 0);
                                                completed++;
                                            }
                                            main.CurrentProgress = completed;
                                        }
                                    }
                                }
                                info[7] = (completed - 1).ToString(); // Count of processed values
                                info[9] = DateTime.Now.ToString("HH:mm"); // Process ending time     
                                main.CurrentInfo = info;
                            }
                            catch (Exception ex)
                            {
                                lock (main.Logger)
                                {
                                    main.Logger.WriteError("Ошибка обработки xml " + info[0] + ": " + ex.Message +
                                        Environment.NewLine + ex.InnerException.Message);
                                }
                                lock (main.XMLs)
                                {
                                    main.XMLs.Remove(xml.Key);
                                    main.Disposables.Add(xml.Key);
                                    info[10] = "Ошибка";
                                    main.Logger.WriteWorkingLog(info);
                                    continue;
                                }
                            }
                            info[10] = "OK"; // Process result
                            lock (main.Logger)
                            {
                                main.Logger.WriteWorkingLog(info);
                            }
                            lock (main.XMLs)
                            {
                                main.XMLs.Remove(xml.Key);
                                main.Disposables.Add(xml.Key);
                            }
                            main.CurrentInfo = info;
                        }
                    }
                }
                Thread.Sleep(500);
            }
        }

        public void ProcessingViaDatatemp()
        {
            // XML parsing and writing into database
            isRunning = true;
            Dictionary<string, XmlDocument> xmls_copy;
            XmlDocument currentXML;
            string[] info = new string[11];
            bool IgnoreStatus = settings.IgnoreNonCommercialStatus;
            DateTime day;
            DateTime timePoint;
            string extractTime;

            string objSpecCode;
            string channelCode;
            string deviceCode, deviceID, subdeviceCode, subdeviceID, sensorCode;

            bool rewrite = settings.Rewrite;
            float value;

            int completed;

            while (isRunning)
            {
                if (main.Process)
                {
                    lock (main.XMLs)
                    {
                        xmls_copy = new Dictionary<string, XmlDocument>(main.XMLs);
                    }
                    if (xmls_copy.Count > 0)
                    {
                        completed = 0;
                        foreach (KeyValuePair<string, XmlDocument> xml in xmls_copy)
                        {
                            currentXML = xml.Value;
                            try
                            {
                                info[0] = Path.GetFileName(xml.Key); // xml file name
                                info[1] = currentXML.InnerXml.Length.ToString(); // File size
                                info[2] = currentXML.SelectNodes("/message/sender/inn[1]")[0].FirstChild.Value; // INN
                                info[3] = currentXML.SelectNodes("/message/sender/name[1]")[0].FirstChild.Value; // Sender name
                                info[4] = currentXML.SelectNodes("/message/datetime/day[1]")[0].FirstChild.Value; // XML day
                                info[5] = currentXML.SelectNodes("/message//measuringpoint").Count.ToString(); // Count of measuring points
                                info[6] = currentXML.SelectNodes("/message//value").Count.ToString(); // Count of values
                                info[7] = "0"; // Count of processed values
                                info[8] = DateTime.Now.ToString("yyyy-MM-dd HH:mm"); // Process starting time
                                info[9] = ""; // Process ending time
                                info[10] = "работа"; // Status
                            }
                            catch (Exception ex)
                            {
                                lock (main.Logger)
                                {
                                    main.Logger.WriteError("Ошибка прасинга XML: " + info[0] + " " + ex.Message);
                                    info[10] = "ошибка";
                                    main.Logger.WriteWorkingLog(info);
                                }
                                lock (main.XMLs)
                                {
                                    main.XMLs.Remove(xml.Key);
                                    main.Disposables.Add(xml.Key);
                                }
                                continue;
                            }
                            try
                            {
                                IgnoreStatus = IgnoreStatus || settings.IgnoreList.Contains(info[2]); // Is it in the ignore status list
                                day = new DateTime(int.Parse(info[4].Substring(0, 4)),
                                                   int.Parse(info[4].Substring(4, 2)),
                                                   int.Parse(info[4].Substring(6)));
                                main.CurrentInfo = info;
                                main.CurrentProgress = 0;
                                foreach (XmlNode nodePoint in currentXML.SelectNodes("/message//measuringpoint"))
                                {
                                    // Find all identifiers
                                    objSpecCode = nodePoint.Attributes["code"].Value;
                                    Tuple<string, string> dev_subdev;
                                    try
                                    {
                                        dev_subdev = m.FullSubdevice(objSpecCode);
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                    deviceCode = dev_subdev.Item1;
                                    subdeviceCode = dev_subdev.Item2;
                                    foreach (XmlNode nodeChannel in nodePoint.SelectNodes("child::measuringchannel"))
                                    {
                                        channelCode = nodeChannel.Attributes["code"].Value;
                                        try
                                        {
                                            sensorCode = m.ItemCodeFromObject(channelCode, deviceCode, subdeviceCode);
                                        }
                                        catch
                                        {
                                            continue;
                                        }
                                        foreach (XmlNode nodeValue in nodeChannel.SelectNodes("child::period"))
                                        {
                                            extractTime = nodeValue.Attributes["end"].Value;
                                            if (extractTime == "0000")
                                                timePoint = day.AddDays(1);
                                            else
                                                timePoint = new DateTime(day.Year, day.Month, day.Day,
                                                    int.Parse(extractTime.Substring(0, 2)), int.Parse(extractTime.Substring(2)), 0);
                                            XmlNode val = nodeValue.SelectNodes("child::value")[0];
                                            value = float.Parse(val.FirstChild.Value.Replace(',', '.'), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                                            value *= 2;
                                            if (IgnoreStatus || val.Attributes.Count == 0 || val.Attributes["status"].Value == "0")
                                            {
                                                m.WriteOneRecord(12, timePoint, int.Parse(deviceCode), int.Parse(sensorCode),
                                                    0, value.ToString().Replace(',','.'), 0, 0, 0, rewrite);
                                                completed++;
                                            }
                                            main.CurrentProgress = completed;
                                        }
                                    }
                                }
                                info[7] = (completed - 1).ToString(); // Count of processed values
                                m.WriteAllFromTemp(rewrite);
                                info[9] = DateTime.Now.ToString("HH:mm"); // Process ending time     
                                main.CurrentInfo = info;
                            }
                            catch (Exception ex)
                            {
                                lock (main.Logger)
                                {
                                    main.Logger.WriteError("Ошибка обработки xml " + info[0] + ": " + ex.Message +
                                        Environment.NewLine + ex.InnerException.Message);
                                }
                                lock (main.XMLs)
                                {
                                    main.XMLs.Remove(xml.Key);
                                    main.Disposables.Add(xml.Key);
                                    info[10] = "Ошибка";
                                    main.Logger.WriteWorkingLog(info);
                                    continue;
                                }
                            }
                            info[10] = "OK"; // Process result
                            lock (main.Logger)
                            {
                                main.Logger.WriteWorkingLog(info);
                            }
                            lock (main.XMLs)
                            {
                                main.XMLs.Remove(xml.Key);
                                main.Disposables.Add(xml.Key);
                            }
                            main.CurrentInfo = info;
                        }
                    }
                }
                Thread.Sleep(500);
            }
        }

        public void ProcessingViaXMLLinq()
        {
            // XML parsing and writing into database
            isRunning = true;
            Dictionary<string, XmlDocument> xmls_copy;
            XDocument currentXML;
            string[] info = new string[11];
            bool IgnoreStatus = settings.IgnoreNonCommercialStatus;
            DateTime day;
            DateTime timePoint;
            string extractTime;

            string objSpecCode;
            string channelCode;
            string deviceCode, deviceID, subdeviceCode, subdeviceID, sensorCode;

            bool rewrite = settings.Rewrite;
            float value;

            int completed;

            while (isRunning)
            {
                if (main.Process)
                {
                    lock (main.XMLs)
                    {
                        xmls_copy = new Dictionary<string, XmlDocument>(main.XMLs);
                    }
                    if (xmls_copy.Count > 0)
                    {
                        foreach (KeyValuePair<string, XmlDocument> xml in xmls_copy)
                        {
                            completed = 0;
                            currentXML = XDocument.Load(xml.Key);
                            try
                            {
                                info[0] = Path.GetFileName(xml.Key); // xml file name
                                info[1] = new FileInfo(xml.Key).Length.ToString(); // File size
                                info[2] = currentXML.Descendants("sender").First().Descendants("inn").First().Value; // INN
                                info[3] = currentXML.Descendants("sender").First().Descendants("name").First().Value; // Sender name
                                info[4] = currentXML.Descendants("datetime").First().Descendants("day").First().Value; // XML day
                                info[5] = currentXML.Descendants("measuringpoint").Count().ToString(); // Count of measuring points
                                info[6] = currentXML.Descendants("value").Count().ToString(); // Count of values
                                info[7] = "0"; // Count of processed values
                                info[8] = DateTime.Now.ToString("yyyy-MM-dd HH:mm"); // Process starting time
                                info[9] = ""; // Process ending time
                                info[10] = "работа"; // Status
                            }
                            catch (Exception ex)
                            {
                                lock (main.Logger)
                                {
                                    main.Logger.WriteError("Ошибка прасинга XML: " + info[0] + " " + ex.Message);
                                    info[10] = "ошибка";
                                    main.Logger.WriteWorkingLog(info);
                                }
                                lock (main.XMLs)
                                {
                                    main.XMLs.Remove(xml.Key);
                                    main.Disposables.Add(xml.Key);
                                }
                                continue;
                            }
                            try
                            {
                                IgnoreStatus = IgnoreStatus || settings.IgnoreList.Contains(info[2]); // Is it in the ignore status list
                                day = new DateTime(int.Parse(info[4].Substring(0, 4)),
                                                   int.Parse(info[4].Substring(4, 2)),
                                                   int.Parse(info[4].Substring(6)));
                                main.CurrentInfo = info;
                                main.CurrentProgress = 0;
                                foreach (XElement nodePoint in currentXML.Descendants("measuringpoint"))
                                {
                                    // Find all identifiers
                                    objSpecCode = nodePoint.Attributes("code").First().Value;
                                    Tuple<string, string> dev_subdev;
                                    try
                                    {
                                        dev_subdev = m.FullSubdevice(objSpecCode);
                                    }
                                    catch
                                    {
                                        continue;
                                    }
                                    deviceCode = dev_subdev.Item1;
                                    subdeviceCode = dev_subdev.Item2;
                                    foreach (XElement nodeChannel in nodePoint.Descendants("measuringchannel"))
                                    {
                                        channelCode = nodeChannel.Attributes("code").First().Value;
                                        try
                                        {
                                            sensorCode = m.ItemCodeFromObject(channelCode, deviceCode, subdeviceCode);
                                        }
                                        catch
                                        {
                                            continue;
                                        }
                                        foreach (XElement nodeValue in nodeChannel.Descendants("period"))
                                        {
                                            extractTime = nodeValue.Attributes("end").First().Value;
                                            if (extractTime == "0000")
                                                timePoint = day.AddDays(1);
                                            else
                                                timePoint = new DateTime(day.Year, day.Month, day.Day,
                                                    int.Parse(extractTime.Substring(0, 2)), int.Parse(extractTime.Substring(2)), 0);
                                            XElement val = nodeValue.Descendants("value").First();
                                            value = float.Parse(val.Value.Replace(',', '.'), System.Globalization.CultureInfo.GetCultureInfo("en-US"));
                                            value *= 2;
                                            if (IgnoreStatus || val.Attributes("status").Count() == 0 || val.Attributes("status").First().Value == "0")
                                            {
                                                m.WriteOneRecord(12, timePoint, int.Parse(deviceCode), int.Parse(sensorCode),
                                                    0, value.ToString().Replace(',', '.'), 0, 0, 0, rewrite);
                                                completed++;
                                            }
                                            main.CurrentProgress = completed;
                                        }
                                    }
                                }
                                info[7] = (completed - 1).ToString(); // Count of processed values
                                m.WriteAllFromTemp(rewrite);
                                info[9] = DateTime.Now.ToString("HH:mm"); // Process ending time     
                                main.CurrentInfo = info;
                            }
                            catch (Exception ex)
                            {
                                lock (main.Logger)
                                {
                                    main.Logger.WriteError("Ошибка обработки xml " + info[0] + ": " + ex.Message +
                                        Environment.NewLine + ex.InnerException.Message);
                                }
                                lock (main.XMLs)
                                {
                                    main.XMLs.Remove(xml.Key);
                                    main.Disposables.Add(xml.Key);
                                    info[10] = "Ошибка";
                                    main.Logger.WriteWorkingLog(info);
                                    continue;
                                }
                            }
                            info[10] = "OK"; // Process result
                            lock (main.Logger)
                            {
                                main.Logger.WriteWorkingLog(info);
                            }
                            lock (main.XMLs)
                            {
                                main.XMLs.Remove(xml.Key);
                                main.Disposables.Add(xml.Key);
                            }
                            main.CurrentInfo = info;
                        }
                    }
                }
                Thread.Sleep(500);
            }
        }
    }
}
