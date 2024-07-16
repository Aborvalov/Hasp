using Entities;
using ModelEntities;

namespace Model
{
    internal static class Context
    {
        private static IFactoryContext FactoryContext { get; }
        static Context()
        {
            FactoryContext = new FactoryContext();
        }

        internal static IEntitesContext GetContext()
        {
            return FactoryContext.CreateWorkContext();
        }        
    }
}
