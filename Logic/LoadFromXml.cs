using System.IO;
using System.Reflection;
using System.Xml;

namespace Logic
{
    public class LoadFromXml
    {
        private static readonly string filePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + @"\Common\days.xml";
        private const int defaultValue = 30;
        public static void Save(int item)
        {
            var xmlDoc = new XmlDocument();
            var rootElement = xmlDoc.CreateElement("Data");
            var userElement = xmlDoc.CreateElement("UserValue");
            if (item > 0)
                userElement.InnerText = item.ToString();
            else 
                userElement.InnerText = defaultValue.ToString();

            rootElement.AppendChild(userElement);
            xmlDoc.AppendChild(rootElement);
            xmlDoc.Save(filePath);
        }
        public static int GetItem()
        {
            var xDoc = new XmlDocument();
            xDoc.Load(filePath);
            var userValue = xDoc.SelectSingleNode("/Data/UserValue").InnerText;
            try
            {
                return int.Parse(userValue);
            }
            catch 
            { 
                return defaultValue; 
            }
        }
    }
}
