using Entities;
using ModelEntities;

namespace Model
{
    internal static class Context
    {
        internal static IEntitesContext GetContext()
        {
            return new EntitesContext();
        }        
    }
}
