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
        private readonly DateTime date = DateTime.Now.Date;

        private const string errorAdd = "Не удалось создать данную запись: ";
        private const string errorDelete = "Не удалось удалить запись: ";
        private const string errorUpdate = "Не удалось обновить запись: ";

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
            ListKeyAtClient(idClient, keyFeatureClient);
            ListKeyFeatureAvailableClient(keyFeatureClient, idClient);

            return keyFeatureClient
                        .OrderBy(x => x.NumberKey)
                        .OrderByDescending(x => x.Selected)
                        .Distinct()
                        .ToList();
        }
        /// <summary>
        /// Список ключей у клиента.
        /// </summary>
        /// <param name="idClient"></param>
        /// <param name="keyFeatureClient"></param>
        private void ListKeyAtClient(int idClient, List<ModelViewKeyFeatureClient> keyFeatureClient)
        {            
            if (keyFeatureClient == null)
                throw new ArgumentNullException(nameof(keyFeatureClient));

            var allKeyFeature = keyFeatureLogic.GetAll();
            var listKeyFeatureClient = keyFeatureClientLogic.GetAll()
                                                    .Where(x => x.IdClient == idClient);
                        
            var listIdHaspKeyAtClient = from keyFeatCl in listKeyFeatureClient
                                        join keyActFeat in allKeyFeature
                                             on keyFeatCl.IdKeyFeature equals keyActFeat.Id
                                        select keyActFeat.IdHaspKey;

            var listKeyFeatureAtClient = from keyFeat in allKeyFeature
                                         join keyInCl in listIdHaspKeyAtClient
                                              on keyFeat.IdHaspKey equals keyInCl
                                         where keyFeat.EndDate >= date
                                         select keyFeat;

            var kyeFeature = from keyFeat in listKeyFeatureAtClient.Distinct()
                             join key in haspKeyLogic.GetAll()
                                  on keyFeat.IdHaspKey equals key.Id
                             join feature in featureLogic.GetAll()
                                  on keyFeat.IdFeature equals feature.Id
                             where keyFeat.EndDate >= date
                             select new ModelViewKeyFeatureClient
                             {                                 
                                 IdClient = idClient,
                                 IdKeyFeature = keyFeat.Id,                                 
                                 Feature = feature.Name,                                
                                 NumberKey = key.InnerId.ToString() + " - \"" + key.Number + "\"",
                                 EndDate = keyFeat.EndDate,
                                 TypeKey = key.TypeKey
                             };

            foreach (var item in kyeFeature)
            {
                var client = listKeyFeatureClient.FirstOrDefault(x => x.IdKeyFeature == item.IdKeyFeature);
                if (client != null)
                {
                    item.Id = client.Id;
                    item.Selected = true;
                    item.Initiator = client.Initiator;
                    item.Note = client.Note;
                }

                keyFeatureClient.Add(item);
            }
        }
        /// <summary>
        /// Список доступных ключей.
        /// </summary>
        /// <param name="keyFeatureClient"></param>
        /// <param name="idClient"></param>
        private void ListKeyFeatureAvailableClient(List<ModelViewKeyFeatureClient> keyFeatureClient, int idClient)
        {
            if (keyFeatureClient == null)
                throw new ArgumentNullException(nameof(keyFeatureClient));

            var listKeyFeatureNoyClient = new List<KeyFeature>();
            var allListKeyFeat = keyFeatureLogic.GetAll();
            var features = featureLogic.GetAll();
            var haspKeys = haspKeyLogic.GetAll();

            var listIdKeyFeatAtClient = keyFeatureClientLogic.GetAll()
                                                    .Select(x => x.IdKeyFeature)
                                                    .Distinct();

            var listActiveKeyFeature = allListKeyFeat
                                        .Where(x => x.EndDate >= date)
                                        .ToList();

            var listIdHaspKeyAtClient = from client in listIdKeyFeatAtClient
                       join keyFeature in listActiveKeyFeature
                            on client equals keyFeature.Id
                       select new
                       {
                           keyFeature.IdHaspKey,
                       };

            foreach (var keyFeat in allListKeyFeat.Where(x => x.EndDate >= date))
                if (!listIdHaspKeyAtClient.Any(x => x.IdHaspKey == keyFeat.IdHaspKey))
                    listKeyFeatureNoyClient.Add(keyFeat);
            
            var item = from keyFeat in listKeyFeatureNoyClient
                        join feature in features
                             on keyFeat.IdFeature equals feature.Id
                        join key in haspKeys
                             on keyFeat.IdHaspKey equals key.Id
                        where keyFeat.EndDate >= date
                        select new ModelViewKeyFeatureClient
                        {
                            IdKeyFeature = keyFeat.Id,
                            EndDate = keyFeat.EndDate,
                            Feature = feature.Name,
                            NumberKey = key.InnerId.ToString() + " - \"" + key.Number + "\"",
                            IdClient = idClient,
                        };

            keyFeatureClient.AddRange(item);
        }
        public List<KeyFeatureClient> GetAllKeyClient() 
            => keyFeatureClientLogic.GetAll();

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

            if (!keyClient.Any())
                return true;

            var allKeyAtClient = GetAllAtClient(keyClient.First().IdClient); ;
            foreach (var item in keyClient)
            {
                if (allKeyAtClient
                    .Any(x => x.KeyFeatureClient.Equals(item.KeyFeatureClient)))
                    continue;

                if(!keyFeatureClientLogic.Update(item.KeyFeatureClient))
                    error += errorUpdate + item.Client + " - " + item.NumberKey + '\n';
            }

            return string.IsNullOrEmpty(error);
        }
    }
}
