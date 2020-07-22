using ModelEntities;

namespace Presenter
{
    public interface IPresenterReference : IPresenterEntities<ModelViewClient>
    {
        void GetByFeature(ModelViewFeature feature);
        void GetByNumberKey(int keyInnerId);
    }
}
