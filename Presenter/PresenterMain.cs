using System;
using ViewContract;
using ModelEntities;
using Model;
using Logic;
using System.Collections.Generic;

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
                mainView.Bind(Converter(mainModel?.GetActiveKeys()));
            }
            catch
            {
                mainView.MessageError(errorDB);
                mainView.ErrorDataBase = true;
            }
        }

        public void GetByClient(ModelViewClient client)
            => mainView.Bind(Converter(mainModel?.GetByClient(client)));

        public void ShowExpiredKeys()
            => mainView.Bind(Converter(mainModel?.ShowExpiredKeys()));

        private List<ModelViewMain> Converter(List<ModelMain> models)
        {
            if (models is null)
            {
                throw new ArgumentNullException(nameof(models));
            }

            var result = new List<ModelViewMain>();
            foreach (var model in models) 
            {
                result.Add(
                    new ModelViewMain()
                    {
                        IdClient = model.IdClient,
                        NumberKey = model.NumberKey,
                        Feature = model.Feature,
                        Client = model.Client,
                        EndDate = model.EndDate.ToString(),
                    });
            }

            return result;
        }
    }
}
