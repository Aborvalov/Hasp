using Logic;
using Model;
using System;
using View;

namespace Presenter
{
    public class PresenterMain : IPresenterMain
    {
        private readonly IMainModel mainModel;
        private readonly IMainView mainView;
        private const string nullDB = "База данных не найдена.";

        public PresenterMain(IMainView homeView)
        {            
            this.mainView = homeView ?? throw new System.ArgumentNullException(nameof(homeView));
                        
            try
            {
                mainModel = new MainModel(new Logics());
            }
            catch (ArgumentNullException)
            {
                mainView.MessageError(nullDB);
            }
            Views();
        }

        public void Dispose() => mainModel.Dispose();

        public void Views() => mainView.Bind(mainModel.GetAll());
    }
}
