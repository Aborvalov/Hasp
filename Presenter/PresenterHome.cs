using Logic;
using Model;
using Presenter;
using System.Collections.Generic;
using View;

namespace Presenter
{
    public class PresenterHome : IPresenterHome
    {
        private readonly IHomeModel homeModel;
        private readonly IHomeView homeView;

        public PresenterHome(IHomeView homeView)
        {
            homeModel = new HomeModel(new Logics());
            this.homeView = homeView;

            homeView.Build(HomeViews());
        }
        public List<HomeView> HomeViews() => homeModel.GetAll();
    }
}
