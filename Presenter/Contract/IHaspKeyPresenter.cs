using ModelEntities;

namespace Presenter
{
    public interface IHaspKeyPresenter : IEntitiesPresenter<ModelViewHaspKey>
    {
        void GetByClient(ModelViewClient client);
        /// <summary>
        /// Поиск просроченных ключей.
        /// </summary>
        /// <returns>Список просроченных ключей.</returns>
        void GetByPastDue(ModelViewClient id);
        void GetAllInCompany(ModelViewClient id);
        void GetActiveInCompany(ModelViewClient id);
        
        /// <summary>
        /// Поиск действующих ключей.
        /// </summary>
        /// <returns>Список действующих ключей.</returns>
        void GetByActive();        
    }
}
