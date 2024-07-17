using System;
using ViewContract;
using ModelEntities;
using Model;
using Logic;
using System.Collections.Generic;
using System.Linq;
using Entities;
using System.Runtime.InteropServices.ComTypes;

namespace Presenter
{
    public class MainPresenter : IMainPresenter
    {
        private readonly IMainModel mainModel;
        private readonly IMainView mainView;
        private DateTime NowDate = DateTime.Now;
        private const string nullDB = "База данных не найдена.";
        private const string errorDB = "Ошибка базы данных.";
        public event Action DataUpdated;

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

        public void DataChange() => DataUpdated?.Invoke();
        public void Dispose() => mainModel?.Dispose();
        public void Views()
        {
            try
            {
                mainView.Bind(DXConverterTo(mainModel?.GetKeysNextNDays()));
                mainView.BindForm(DXConverterTo(mainModel?.GetKeysPastNDays()));
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

        private string CountDays(DateTime model, DateTime now) 
        {
            if (model.ToString().IndexOf("2111") > -1)
            {
                return "\u221E";
            }
            else 
            {
                return ((int)(model - NowDate).TotalDays).ToString();
            }          
        }
        private List<DXModelClient> DXConverterTo(List<ModelMain> models)
        {
            return models
                .GroupBy(model => model.Client)
                .OrderBy(group => group.Key) // Sort by Client
                .Select(group => new DXModelClient
                {
                    Client = group.Key,
                    Keys = group
                        .GroupBy(model => model.NumberKey)
                        .Select(featureGroup => new DXModelKeys
                        {
                            Name = featureGroup.Key,
                            Feature = featureGroup
                                .Select(model => new DXModelFeature
                                {
                                    Name = model.Feature,
                                    EndDate = model.EndDate.ToString(),
                                    //RemainedDays = CountDays(model.EndDate, NowDate)
                                })
                                .ToList()
                        })
                        .ToList()
                })
                .ToList();
        }

    }
}
