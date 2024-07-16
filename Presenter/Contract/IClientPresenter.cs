using ModelEntities;

namespace Presenter
{
    public interface IPresenterReference : IEntitiesPresenter<ModelViewClient>
    {
        void GetByFeature(ModelViewFeature feature);
        void GetByNumberKey(int keyInnerId);
    }
}
