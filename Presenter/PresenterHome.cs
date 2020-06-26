using Logic;
using Model;
using ModelEntities;
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
        public List<Home> HomeViews() => homeModel.GetAll();
    }
}
