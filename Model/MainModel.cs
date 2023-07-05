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
        private readonly DateTime date = DateTime.Now.Date;

        private readonly IFactoryLogic logic;
        private  IEntitesContext db;
        
        public MainModel(IFactoryLogic factoryLogic)
        {
            logic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));
            db = Context.GetContext();
            if (db == null)
                throw new ArgumentNullException(nameof(db));           
        }       
        public void Dispose() => db.Dispose();


        public List<ModelViewMain> GetAll()
        {
            try
            {
                using (db = Context.GetContext())
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

                               select new ModelViewMain
                               {
                                   Client = cl.Name + (string.IsNullOrEmpty(cl.Address)
                                                            ? string.Empty : " - " + cl.Address),
                                   IdClient = cl.Id,
                                   EndDate = keyFeat.EndDate,
                                   Feature = feature.Name,
                                   NumberKey = key.InnerId.ToString() + " - \"" + key.Number + "\"",
                               };

                    return item.OrderBy(x => x.Client).ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<ModelViewMain> GetActiveKeys() 
            => GetAll().Where(x => x.EndDate >= date).ToList();

        public List<ModelViewMain> GetByClient(ModelViewClient client)
            => GetActiveKeys().Where(x => x.IdClient == client.Id).ToList();

        public List<ModelViewMain> ShowExpiredKeys()
            => GetAll().Where(x => x.EndDate < date).ToList();

    }
}
