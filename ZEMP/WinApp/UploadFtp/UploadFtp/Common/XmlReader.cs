using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace UploadFtp.Common
{
    class XmlReader
    {
        XmlDataDocument xmldoc = new XmlDataDocument();
        public XmlReader()
        {
            try
            {
                FileStream fs = new FileStream("UploadConfig.xml", FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        public string getTagValue(string strParentTag, string strTagName)
        {
            string strValue = "";
            XmlNodeList xmlnode;
            xmlnode = xmldoc.GetElementsByTagName(strParentTag);
            for (int i = 0; i <= xmlnode[0].ChildNodes.Count - 1; i++)
            {
                xmlnode[0].ChildNodes.Item(i).InnerText.Trim();
                if (xmlnode[0].ChildNodes.Item(i).Name == strTagName)
                {
                    strValue = xmlnode[0].ChildNodes.Item(i).InnerText.Trim();
                    break;
                }
            }
            return strValue;
        }
    }
}
