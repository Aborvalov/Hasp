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
        private readonly EntitesContext db;
        
        public MainModel(IFactoryLogic factoryLogic)
        {
            logic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));
            db = new EntitesContext();
        }
        public void Dispose() => db.Dispose();
        public List<ModelViewMain> GetAll()
        {
            List<KeyFeatureClient> keyFeatureClients;
            List<KeyFeature> keyFeatures;
            List<Client> clients;
            List<Feature> features;
            List<HaspKey> haspKeys;
            int i = 1;
            
            keyFeatureClients = logic.CreateKeyFeatureClient(db).GetAll();
            keyFeatures       = logic.CreateKeyFeature(db).GetAll();
            clients           = logic.CreateClient(db).GetAll();
            features          = logic.CreateFeature(db).GetAll();
            haspKeys          = logic.CreateHaspKey(db).GetByActive();
            
            var item = from keyFeatCl in keyFeatureClients
                       join keyFeat in keyFeatures
                            on keyFeatCl.IdKeyFeature equals keyFeat.Id
                       join cl in clients
                            on keyFeatCl.IdClient equals cl.Id
                       join feature in features
                            on keyFeat.IdFeature equals feature.Id
                       join key in haspKeys
                            on keyFeat.IdHaspKey equals key.Id
                       where keyFeat.EndDate >= date
                       select new ModelViewMain
                       {
                           SerialNumber = i++,                           
                           Client       = cl.Name + (cl.Address == string.Empty || cl.Address == null 
                                                    ? string.Empty : " - " + cl.Address) ,                          
                           EndDate      = keyFeat.EndDate,
                           Feature      = feature.Name,
                           NumberKey    = key.InnerId.ToString() + " - \"" + key.Number + "\"",
                       };            

            return item.ToList();
        }       
    }
}
