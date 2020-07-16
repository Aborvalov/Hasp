using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        private readonly DateTime date = DateTime.Now.Date;

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
                                        .Where(x=>x.IdClient == idClient);

            var listActiveKeyFeature = keyFeatureLogic.GetAll()
                                        .Where(x => x.EndDate >= date)
                                        .ToList();

            // Список ключей у клиента. 
            foreach (var keyFeatCl in listKeyFeatureClient)
            {
                var item = listActiveKeyFeature
                            .FirstOrDefault(x => x.Id == keyFeatCl.IdKeyFeature);

                var kf = from keyFeat in keyFeatureLogic.GetAll()
                         join key in haspKeyLogic.GetAll()
                         on keyFeat.IdHaspKey equals key.Id
                         join feature in featureLogic.GetAll()
                         on keyFeat.IdFeature equals feature.Id
                         where keyFeat.IdHaspKey == item.IdHaspKey &&
                               keyFeat.EndDate >= date
                         select new ModelViewKeyFeatureClient
                         {
                             Id = keyFeatCl.Id,
                             IdClient = idClient,
                             Initiator = keyFeatCl.Initiator,
                             Feature = feature.Name,
                             Note = keyFeatCl.Note,
                             NumberKey = key.InnerId.ToString() + " - \"" + key.Number + "\"",
                             EndDate = keyFeat.EndDate,
                             TypeKey = key.TypeKey,
                             Selected = keyFeat.Id == item.Id,
                         };

                keyFeatureClient.AddRange(kf);
            }
            // Список доступных ключей.







                




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
