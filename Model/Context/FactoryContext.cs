using Entities;

namespace Model
{
    internal class FactoryContext : IFactoryContext
    {
        public IEntitesContext CreateTestContext() => new TestContext();        
        public IEntitesContext CreateWorkContext() => new WorkContext();
    }
}
