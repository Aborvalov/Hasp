using Logic;
using Model;
using View;

namespace Presenter
{
    public class PresenterMain : IPresenterMain
    {
        private readonly IMainModel homeModel;
        private readonly IMainView homeView;

        public PresenterMain(IMainView homeView)
        {            
            this.homeView = homeView ?? throw new System.ArgumentNullException(nameof(homeView));

            homeModel = new MainModel(new Logics());
            Views();
        }
        public void Views() => homeView.Bind(homeModel.GetAll());

    }
}
