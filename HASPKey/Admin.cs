using System.Security.Principal;
using System.Xml;

namespace HASPKey
{
        internal static class Admin
        {
            internal static bool IsAdmin()
            {
                XmlDocument xDoc = new XmlDocument();
                try
                {
                    xDoc.Load(@".\Common\users.xml");
                }
                catch
                {
                    return false;
                }
                foreach (XmlNode xnode in xDoc.DocumentElement)
                {
                    if (xnode.Attributes == null)
                        continue;

                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null && attr.Value == WindowsIdentity.GetCurrent().Name)
                    {
                        return true;
                    }
                }
                return false;
            }
        
    }
}
