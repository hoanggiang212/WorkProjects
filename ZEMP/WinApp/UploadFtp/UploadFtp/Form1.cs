using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using UploadFtp.Common;

namespace UploadFtp
{
    public partial class Form1 : Form
    {
        string srcFolder;
        string ftpFolder;
        string strProxy;
        int iPort;
        string sUserName;
        string sPassword;
        public Form1()
        {
            InitializeComponent();
            ReadConfig();
            SendFile2Ftp();
            timer1.Start();
        }
        private void ReadConfig()
        {
            XmlReader xmlCf = new XmlReader();
            if (xmlCf != null)
            {
                srcFolder = xmlCf.getTagValue("Root", "DataFolder");
                ftpFolder = xmlCf.getTagValue("Root", "FtpFolder");
                strProxy = xmlCf.getTagValue("Root", "ProxyIp");
                iPort = int.Parse(xmlCf.getTagValue("Root", "ProxyPort"));
                sUserName = xmlCf.getTagValue("Root", "Username");
                sPassword = xmlCf.getTagValue("Root", "Password");
            }
        }
        
        private void SendFile2Ftp()
        {
            //check exist directory
            if (!Directory.Exists(srcFolder))
            {
                MessageBox.Show("Folder Data does not exist, please check again.");
                return;
            }

            string[] listFile = Directory.GetFiles(srcFolder);
            foreach(string strFileName in listFile)
            {
                try
                {
                    string sFileName = Path.GetFileName(strFileName);
                    FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(ftpFolder + sFileName);
                    ftp.Credentials = new NetworkCredential(sUserName, sPassword);

                    ftp.KeepAlive = true;
                    ftp.UseBinary = true;

                    var webProxy = new WebProxy(strProxy, iPort);
                    ftp.Proxy = webProxy;
                    ftp.Proxy = null;

                    ftp.Method = WebRequestMethods.Ftp.UploadFile;


                    FileStream fs = File.OpenRead(strFileName);
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();

                    Stream ftpStream = ftp.GetRequestStream();
                    ftpStream.Write(buffer, 0, buffer.Length);
                    ftpStream.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Send file failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SendFile2Ftp();
            timer1.Start();
        }
    }
}
