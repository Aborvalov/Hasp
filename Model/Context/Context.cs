using Entities;
using ModelEntities;

namespace Model
{
    internal static class Context
    {
        private static IEntitesContext context = new EntitesContext();


        internal static IEntitesContext GetContext()
        {
            return context;
        }        
    }
}
