using Entities;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class HomeModel : IHomeModel
    {
        private List<Home> homes = null;
        private readonly DateTime date = DateTime.Now.Date;
        public event EventHandler<HomeEventArgs> ProjectUpdated = delegate { };

        public HomeModel() => homes = GetHomes();       
        private List<Home> GetHomes()
        {
            var logic = new Logics();
            List<KeyFeatureClient> keyFeatureClients;
            List<KeyFeature> keyFeatures;
            List<Client> clients;
            List<Feature> features;
            List<HaspKey> haspKeys;

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
                       select new Home
                       {
                           Id           = keyFeatCl.Id,
                           IdKeyFeature = keyFeatCl.IdKeyFeature,
                           IdClient     = keyFeatCl.IdClient,
                           Client       = cl.Name + " - " + cl.Address,
                           Initiator    = keyFeatCl.Initiator,
                           EndDate      = keyFeat.EndDate,
                           Note         = keyFeatCl.Note,
                           Feature      = feature.Name,
                           NumberKey    = key.InnerId.ToString() + " - " + key.Number,
                       };            

            return item.ToList();
        }
        public Home GetById(int Id) => homes.SingleOrDefault(x => x.Id == Id);

        public List<Home> GetAll() => homes;

        public void UpdateHome(Home project)
        {
            if (project == null)
                throw new ArgumentNullException(nameof(project));

            ProjectUpdated(this, new HomeEventArgs(project)); 
        }
    }
}
