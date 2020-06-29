using Entities;
using Logic;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class HomeModel : IHomeModel
    {
        private readonly DateTime date = DateTime.Now.Date;
        private readonly IFactoryLogic logic;

        public HomeModel(IFactoryLogic factoryLogic)
        {
            logic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));
        }
        public List<ModelViewHome> GetAll()
        {
            List<KeyFeatureClient> keyFeatureClients;
            List<KeyFeature> keyFeatures;
            List<Client> clients;
            List<Feature> features;
            List<HaspKey> haspKeys;
            int i = 1;
            using (var db = new EntitesContext())
            {
                keyFeatureClients = logic.CreateKeyFeatureClient(db).GetAll();
                keyFeatures       = logic.CreateKeyFeature(db).GetAll();
                clients           = logic.CreateClient(db).GetAll();
                features          = logic.CreateFeature(db).GetAll();
                haspKeys          = logic.CreateHaspKey(db).GetByActive();
            }

            var item = from keyFeatCl in keyFeatureClients
                       join keyFeat in keyFeatures
                            on keyFeatCl.IdKeyFeature equals keyFeat.Id
                       join cl in clients
                            on keyFeatCl.IdClient equals cl.Id
                       join feature in features
                            on keyFeat.IdFeature equals feature.Id
                       join key in haspKeys
                            on keyFeat.IdHaspKey equals key.Id
                       select new ModelViewHome
                       {
                           Id           = keyFeatCl.Id,
                           SerialNumber = i++,
                           IdKeyFeature = keyFeatCl.IdKeyFeature,
                           IdClient     = keyFeatCl.IdClient,
                           Client       = cl.Name + " - " + cl.Address ,
                           Initiator    = keyFeatCl.Initiator,
                           EndDate      = keyFeat.EndDate,
                           Note         = keyFeatCl.Note,
                           Feature      = feature.Name,
                           NumberKey    = key.InnerId.ToString() + " - \"" + key.Number + "\"",
                       };            

            return item.ToList();
        }
        public ModelViewHome GetById(int Id) => GetAll().SingleOrDefault(x => x.Id == Id);
             
        public void UpdateHome(ModelViewHome project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project));


            /*
             * 
             * 
             * 
             * */


        }
    }
}
