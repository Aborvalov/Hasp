using System.IO;
using System.Reflection;
using System.Xml;

namespace Logic
{
    public class LoadFromXml
    {
        public static readonly string filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Common\days.xml";
        public static void Save(string item)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement rootElement = xmlDoc.CreateElement("Data");
            XmlElement userElement = xmlDoc.CreateElement("UserValue");
            if (int.TryParse(item, out _))
                userElement.InnerText = item;
            else 
                userElement.InnerText = "0";
            rootElement.AppendChild(userElement);
            xmlDoc.AppendChild(rootElement);
            xmlDoc.Save(filePath);
        }
        public static int GetItem()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);

            foreach (XmlNode xnode in xDoc.DocumentElement)
            {
                if (xnode.Attributes == null)
                    continue;

                XmlNode attr = xnode.Attributes.GetNamedItem("UserValue");
                if (attr != null)
                {
                    return int.Parse(attr.Value);
                }
            }
            return 0;
        }
    }
}
