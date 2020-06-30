using ModelEntities;

namespace Presenter
{
    public interface IPresenterClient : IPresenterEntites<ModelViewClient>
    {
        void GetByFeature(ModelViewFeature feature);
        void GetByNumberKey(int keyInnerId);
    }
}
