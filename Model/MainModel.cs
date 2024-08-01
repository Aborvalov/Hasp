using Entities;
using Logic;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class MainModel : IMainModel
    {
        private readonly DateTime dateNow = DateTime.Now.Date;
        private const string yearInEternalKey = "2111";
        private readonly IFactoryLogic logic;
        private readonly int days = LoadFromXml.GetItem();

        public MainModel(IFactoryLogic factoryLogic)
        {
            logic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));
        }
        public void Dispose() => Context.GetContext().Dispose();
        public List<ModelMain> GetAll()
        {
            try
            {
                using (var db = Context.GetContext())
                {
                    if (db == null)
                        throw new ArgumentNullException(nameof(db));

                    List<KeyFeatureClient> keyFeatureClients = logic.CreateKeyFeatureClient(db).GetAll();
                    List<KeyFeature> keyFeatures = logic.CreateKeyFeature(db).GetAll();
                    List<Client> clients = logic.CreateClient(db).GetAll();
                    List<Feature> features = logic.CreateFeature(db).GetAll();
                    List<HaspKey> haspKeys = logic.CreateHaspKey(db).GetAll(); ;

                    var item = from keyFeatCl in keyFeatureClients
                               join keyFeat in keyFeatures
                                    on keyFeatCl.IdKeyFeature equals keyFeat.Id
                               join cl in clients
                                    on keyFeatCl.IdClient equals cl.Id
                               join feature in features
                                    on keyFeat.IdFeature equals feature.Id
                               join key in haspKeys
                                    on keyFeat.IdHaspKey equals key.Id

                               select new ModelMain
                               {
                                   Client = cl.Name + (string.IsNullOrEmpty(cl.Address)
                                                            ? string.Empty : " - " + cl.Address),
                                   IdClient = cl.Id,
                                   EndDate = keyFeat.EndDate,
                                   Feature = feature.Name,
                                   NumberKey = key.InnerId.ToString() + " - \"" + key.Number + "\"",
                               };
                    return item
                            .GroupBy(x => x.Client)
                            .SelectMany(g => g
                            .GroupBy(x => x.Feature)
                            .SelectMany(f => f.OrderBy(x => x.EndDate)))
                            .ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<ModelMain> GetActiveKeys()
        => GetAll()
            .Where(x => x.EndDate.ToString().IndexOf(yearInEternalKey) >= 0 ||
            x.EndDate >= dateNow)
            .ToList();

        public List<ModelMain> GetKeysNextNDays()
        => GetAll()
            .Where(x => x.EndDate.ToString().IndexOf(yearInEternalKey) >= 0 ||
            (dateNow <= x.EndDate &&
            x.EndDate <= dateNow.AddDays(days))).ToList();

        public List<ModelMain> GetKeysPastNDays()
        => GetAll()
            .Where(x => x.EndDate.ToString().IndexOf(yearInEternalKey) < 0 &&
            dateNow > x.EndDate &&
            x.EndDate > dateNow.AddDays(-days))
            .ToList();

        public List<ModelMain> GetByClient(ModelViewClient client)
            => GetActiveKeys()
            .Where(x => x.IdClient == client.Id)
            .ToList();

        public List<ModelMain> ShowExpiredKeys()
            => GetAll()
            .Where(x => x.EndDate.ToString().IndexOf(yearInEternalKey) < 0 &&
            x.EndDate < dateNow)
            .ToList();
    }
}