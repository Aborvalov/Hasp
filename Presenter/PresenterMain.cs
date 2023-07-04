using System;
using ViewContract;
using ModelEntities;
using Model;
using Logic;

namespace Presenter
{
    public class PresenterMain : IPresenterMain
    {
        private readonly IMainModel mainModel;
        private readonly IMainView mainView;
        private const string nullDB = "База данных не найдена.";
        private const string errorDB = "Ошибка базы данных.";

        public PresenterMain(IMainView homeView)
        {
            this.mainView = homeView ?? throw new ArgumentNullException(nameof(homeView));

            try
            {
                mainModel = new MainModel(new Logics());
            }
            catch (ArgumentNullException)
            {
                mainView.MessageError(nullDB);
                mainView.ErrorDataBase = true;
            }

            Views();
        }

        public void Dispose() => mainModel?.Dispose();
        public void Views()
        {
            try
            {
                mainView.Bind(mainModel?.GetActuallKeys());
            }
            catch
            {
                mainView.MessageError(errorDB);
                mainView.ErrorDataBase = true;
            }
        }

        public void GetByClient(ModelViewClient client)
            => mainView.Bind(mainModel?.GetByClient(client));

        public void ShowOldKeys()
            => mainView.Bind(mainModel?.ShowOldKeys());
    }
}
