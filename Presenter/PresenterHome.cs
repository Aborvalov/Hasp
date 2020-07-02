using Logic;
using Model;
using View;

namespace Presenter
{
    public class PresenterHome : IPresenterHome
    {
        private readonly IHomeModel homeModel;
        private readonly IHomeView homeView;

        public PresenterHome(IHomeView homeView)
        {            
            this.homeView = homeView ?? throw new System.ArgumentNullException(nameof(homeView));

            homeModel = new HomeModel(new Logics());
            Views();
        }
        public void Views() => homeView.Build(homeModel.GetAll());
    }
}
