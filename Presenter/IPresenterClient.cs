using ModelEntities;

namespace Presenter
{
    public interface IPresenterClient : IPresenterEntities<ModelViewClient>
    {
        void GetByFeature(ModelViewFeature feature);
        void GetByNumberKey(int keyInnerId);
    }
}
