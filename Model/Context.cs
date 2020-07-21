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
            IItemModel<TypeDateBase> test = new SelectedDataBaseModel();
            var dateBase = test.GetItem();

            switch (dateBase)
            {
                case TypeDateBase.Test:
                    return FactoryContext.CreateTestContext();
                case TypeDateBase.Work:
                    return FactoryContext.CreateWorkContext();
            }

            return null;
        }
    }
}
