using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace XMLimport
{
    public partial class formCheck : Form
    {
        private OpenFileDialog dlg;
        private Settings settings;
        private Model m;
        private int presentPoints, presentChannels;
        private string objSpecCode, channelSpecCode;
        private string deviceCode, subdeviceCode, sensorCode;
        private string pointName;

        public formCheck()
        {
            InitializeComponent();
            settings = new Settings();
            m = new Model(settings.Server, settings.Database, settings.UserName, settings.Password, settings.Season);
            this.Load += FormCheck_Load;
            btnOpen.Click += BtnOpen_Click;
            btnStart.Click += BtnStart_Click;
        }

        public formCheck(string xmlToCheck)
            :this()
        {
            txtXML.Text = xmlToCheck;
        }

        private void FormCheck_Load(object sender, EventArgs e)
        {
            dgvPoints.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPoints.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dgvChannels.Columns)
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            ClearStats();
            ClearResults();
            this.Cursor = Cursors.WaitCursor;
            if (string.IsNullOrEmpty(txtXML.Text) || !System.IO.File.Exists(txtXML.Text))
                return;
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(txtXML.Text);
            }
            catch
            {
                MessageBox.Show("Невозможно загрузить XML из файла " + txtXML.Text + Environment.NewLine +
                    "Возможно, файл повреждён", "Ошибка загрузки XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearStats();
                this.Cursor = Cursors.Default;
                return;
            }
            try
            {
                txtFileSize.Text = xml.InnerXml.Length.ToString(); // File size
                txtINN.Text = xml.SelectNodes("/message/sender/inn[1]")[0].FirstChild.Value; // INN
                txtSender.Text = xml.SelectNodes("/message/sender/name[1]")[0].FirstChild.Value; // Sender name
                txtDate.Text = xml.SelectNodes("/message/datetime/day[1]")[0].FirstChild.Value; // XML day
                txtPointsCount.Text = xml.SelectNodes("/message//measuringpoint").Count.ToString(); // Count of measuring points
                txtChannelsCount.Text = xml.SelectNodes("/message//measuringchannel").Count.ToString(); // Count of measuring channels
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтения XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearStats();
                this.Cursor = Cursors.Default;
                return;
            }            
            try
            {
                foreach (XmlNode nodePoint in xml.SelectNodes("/message//measuringpoint"))
                {                    
                    objSpecCode = nodePoint.Attributes["code"].Value;
                    pointName = nodePoint.Attributes["name"].Value;
                    Tuple<string, string> dev_subdev;
                    try
                    {
                        dev_subdev = m.FullSubdevice(objSpecCode);
                    }
                    catch
                    {
                        dgvPoints.Rows.Add(objSpecCode, pointName);
                        continue;
                    }
                    deviceCode = dev_subdev.Item1;
                    subdeviceCode = dev_subdev.Item2;
                    if (m.CheckMeasuringPoint(nodePoint.Attributes["code"].Value))
                    {
                        presentPoints++;
                        txtPointsInDB.Text = presentPoints.ToString();
                        foreach (XmlNode nodeChannel in nodePoint.SelectNodes("child::measuringchannel"))
                        {
                            channelSpecCode = nodeChannel.Attributes["code"].Value;
                            if (m.CheckMeasuringChannel(channelSpecCode, deviceCode, subdeviceCode))
                            {
                                presentChannels++;
                                txtChannelsInDB.Text = presentChannels.ToString();
                            }
                            else
                            {
                                dgvChannels.Rows.Add(objSpecCode, deviceCode, pointName, 
                                    channelSpecCode, nodeChannel.Attributes["desc"].Value);
                            }
                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        dgvPoints.Rows.Add(objSpecCode, pointName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтения XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearStats();
                ClearResults();
                this.Cursor = Cursors.Default;
                return;
            }
            txtPointsListCount.Text = dgvPoints.Rows.Count.ToString();
            txtChannelsListCount.Text = dgvChannels.Rows.Count.ToString();
            this.Cursor = Cursors.Default;
        }

        private void ClearStats()
        {
            presentPoints = 0;
            presentChannels = 0;
            txtSender.Text = string.Empty;
            txtINN.Text = string.Empty;
            txtFileSize.Text = string.Empty;
            txtDate.Text = string.Empty;
            txtPointsCount.Text = "0";
            txtPointsInDB.Text = "0";
            txtChannelsCount.Text = "0";
            txtChannelsInDB.Text = "0";
            txtPointsListCount.Text = "0";
            txtChannelsListCount.Text = "0";
        }

        private void ClearResults()
        {
            dgvPoints.Rows.Clear();
            dgvChannels.Rows.Clear();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            dlg = new OpenFileDialog();
            dlg.InitialDirectory = settings.ArchiveFolder;
            dlg.Title = "Выберите файл XML";
            dlg.Filter = "XML|*.xml";
            dlg.RestoreDirectory = true;
            do
            {
                if (dlg.ShowDialog(this.Owner) == DialogResult.OK)
                {
                    txtXML.Text = dlg.FileName;
                    ClearStats();
                    ClearResults();
                }
            } while (dlg.InitialDirectory == settings.InboxFolder);
        }


    }
}
