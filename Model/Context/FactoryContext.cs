using Entities;

namespace Model
{
    internal class FactoryContext : IFactoryContext
    {       
        public IEntitesContext CreateWorkContext() => new WorkContext();
    }
}
