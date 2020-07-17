using Logic;
using Model;
using View;

namespace Presenter
{
    public class PresenterMain : IPresenterMain
    {
        private readonly IMainModel mainModel;
        private readonly IMainView mainView;

        public PresenterMain(IMainView homeView)
        {            
            this.mainView = homeView ?? throw new System.ArgumentNullException(nameof(homeView));

            mainModel = new MainModel(new Logics());
            Views();
        }

        public void Dispose() => mainModel.Dispose();

        public void Views() => mainView.Bind(mainModel.GetAll());
    }
}
