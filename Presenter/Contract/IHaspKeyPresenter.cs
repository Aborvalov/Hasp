using ModelEntities;

namespace Presenter
{
    public interface IHaspKeyPresenter : IEntitiesPresenter<ModelViewHaspKey>
    {
        void GetByClient(ModelViewClient client);
        void GetByPastDue(ModelViewClient client);
        void GetAllInCompany(ModelViewClient client);
        void GetActiveInCompany(ModelViewClient client);
        void GetByActive();        
    }
}