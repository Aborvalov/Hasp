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
            IItemModel<TypeDataBase> dataBase = new SelectedDataBaseModel();
            var dateBase = dataBase.GetItem();

            switch (dateBase)
            {
                case TypeDataBase.Test:
                    return FactoryContext.CreateTestContext();
                case TypeDataBase.Work:
                    return FactoryContext.CreateWorkContext();
            }
            return null;
        }        
    }
}
