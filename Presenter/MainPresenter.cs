﻿using System;
using ViewContract;
using ModelEntities;
using Model;
using Logic;
using System.Collections.Generic;
using System.Linq;

namespace Presenter
{
    public class MainPresenter : IMainPresenter
    {
        private readonly IMainModel mainModel;
        private readonly IMainView mainView;
        private const string nullDB = "База данных не найдена.";
        private const string errorDB = "Ошибка базы данных.";
        public MainPresenter(IMainView homeView)
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
                mainView.Bind(DXConverterTo(mainModel?.GetActiveKeys()));
            }
            catch
            {
                mainView.MessageError(errorDB);
                mainView.ErrorDataBase = true;
            }
        }
        public void GetByClient(ModelViewClient client)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }
            mainView.Bind(ConverterTo(mainModel?.GetByClient(client)));
        }
        public void ShowExpiredKeys()
            => mainView.Bind(ConverterTo(mainModel?.ShowExpiredKeys()));
        private List<ModelViewMain> ConverterTo(List<ModelMain> models)
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
                        Date = model.EndDate,
                        EndDate = model.EndDate.ToString("dd.MM.yyyy"),
                    });
            }
            return result;
        }
        private List<DXModelClient> DXConverterTo(List<ModelMain> models)
        {
            if (models is null)
            {
                throw new ArgumentNullException(nameof(models));
            }
            var result = new List<DXModelClient>();
            foreach (var model in models)
            {
                var convertedModel = new DXModelClient()
                {
                    Client = model.Client,
                    Features = new List<DXModelFeature>(),
                };
                var tmp = models.GroupBy(x => x.Client)
                    .SelectMany(g => g
                    .GroupBy(x => x.Feature)).ToList();
                result.Add(convertedModel);
            }
            return result;
        }

    }
}
