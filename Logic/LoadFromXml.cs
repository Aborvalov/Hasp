using System.Xml;

namespace Logic
{
    public class LoadFromXml
    {
        public static readonly string filePath = "C:\\Users\\User\\Hasp\\HASPKey\\Common\\days.xml";
        public static int Load()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);
            var item = xDoc.SelectSingleNode("/Data/UserValue").InnerText;
            return int.Parse(item);
        }
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
    }
}
