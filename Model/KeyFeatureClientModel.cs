using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class KeyFeatureClientModel : IKeyFeatureClientModel
    {
        private readonly EntitesContext db;
        private readonly IFactoryLogic factoryLogic;
        private readonly IClientLogic clientLogic;
        private readonly IKeyFeatureClientLogic keyFeatureClientLogic;
        private readonly IHaspKeyLogic haspKeyLogic;
        private readonly IFeatureLogic featureLogic;
        private readonly IKeyFeatureLogic keyFeatureLogic;


        private const string errorAdd = "Не удалось создать данную запись: ";
        private const string errorDelete = "Не удалось удалить запись: ";
        private const string errorUpdate = "Не удалось удалось запись: ";

        public KeyFeatureClientModel(IFactoryLogic factoryLogic)
        {
            this.factoryLogic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));

            db = new EntitesContext();
            clientLogic = this.factoryLogic.CreateClient(db);
            keyFeatureClientLogic = this.factoryLogic.CreateKeyFeatureClient(db);
            haspKeyLogic = this.factoryLogic.CreateHaspKey(db);
            keyFeatureLogic = this.factoryLogic.CreateKeyFeature(db);
            featureLogic = this.factoryLogic.CreateFeature(db);
        }

        public bool Add(IEnumerable<ModelViewKeyFeatureClient> keyClient, out string error)
        {
            if (keyClient == null)
                throw new ArgumentNullException(nameof(keyClient));

            error = string.Empty;
            foreach (var item in keyClient)
                if (!keyFeatureClientLogic.Save(item.KeyFeatureClient))
                    error += errorAdd + item.Client + " - " + item.NumberKey + '\n';

            return string.IsNullOrEmpty(error);
        }

        public void Dispose() => db.Dispose();

        public List<ModelViewKeyFeatureClient> GetAllAtClient(int idClient)
        {
            var keyFeatureClient = new List<ModelViewKeyFeatureClient>();

            var listKeyFeatureClient = keyFeatureClientLogic.GetAll()
                                        .Where(x => x.IdClient == idClient).ToList();

            var kf = from key in haspKeyLogic.GetAll()
                     join keyFeat in keyFeatureLogic.GetAll()
                     on key.Id equals keyFeat.IdHaspKey
                     join feature in featureLogic.GetAll()
                     on keyFeat.IdFeature equals feature.Id
                     select new
                     {
                         IdHaspKey = key.Id,
                         key.InnerId,
                         key.TypeKey,
                         IdFeature = feature.Id,
                         feature.Number,
                         feature.Name,
                         IdKeyFeature = keyFeat.Id,
                         keyFeat.StartDate,
                         keyFeat.EndDate,
                     };




            var features = featureLogic.GetAll();

            foreach (var keyFeature in listKeyFeatureClient)
            {                
                keyFeatureClient.Add(new ModelViewKeyFeatureClient(keyFeature));
                var item = kf.FirstOrDefault(x => x.IdKeyFeature == keyFeature.IdKeyFeature);

                keyFeatureClient.Last().Feature = item.Name;
                keyFeatureClient.Last().TypeKey = item.TypeKey;
                keyFeatureClient.Last().NumberKey = item.InnerId.ToString() + " - \"" + item.Number + "\"";
                keyFeatureClient.Last().EndDate = item.EndDate;
            }



            return keyFeatureClient;
        }

        public List<KeyFeatureClient> GetAllKeyClient() => keyFeatureClientLogic.GetAll();

        public bool Remove(IEnumerable<int> idKeyClient, out string error)
        {
            if (idKeyClient == null)
                throw new ArgumentNullException(nameof(idKeyClient));

            error = string.Empty;

            foreach (var id in idKeyClient)
                if (!keyFeatureClientLogic.Remove(id))
                    error += errorDelete + id.ToString() + '\n';

            return string.IsNullOrEmpty(error);
        }

        public bool Update(IEnumerable<ModelViewKeyFeatureClient> keyClient, out string error)
        {
            if (keyClient == null)
                throw new ArgumentNullException(nameof(keyClient));

            error = string.Empty;
            var allKeyAtClient = GetAllAtClient(keyClient.First().IdClient);
            foreach (var item in keyClient)
            {
                if (allKeyAtClient
                    .Any(x => x.Equals(item.KeyFeatureClient)))
                    continue;

                if(!keyFeatureClientLogic.Update(item.KeyFeatureClient))
                    error += errorUpdate + item.Client + " - " + item.NumberKey + '\n';
            }

            return string.IsNullOrEmpty(error);
        }
    }
}
