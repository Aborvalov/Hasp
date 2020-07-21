using System.Security.Principal;
using System.Xml;

namespace HASPKey
{
    internal static class Admin
    {
        internal static bool IsAdmin { get; } = false;

        static Admin()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(@".\users.xml");
            foreach (XmlNode xnode in xDoc.DocumentElement)
            {
                if (xnode.Attributes == null)
                    continue;

                XmlNode attr = xnode.Attributes.GetNamedItem("name");
                if (attr != null && attr.Value == WindowsIdentity.GetCurrent().Name)
                {
                    IsAdmin = true;
                    break;
                }
            }
        }
    }
}
