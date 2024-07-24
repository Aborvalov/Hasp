using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class ClientNumberKeysModel : IClientNumberKeysModel
    {
        public IClientNumberKeysLogic clientNumberKeysLogic;
        private readonly IKeyFeatureClientLogic keyFeatureClientLogic;
        private readonly IKeyFeatureLogic keyFeatureLogic;
        private readonly IEntitesContext db;

        private const string errorAdd = "Не удалось создать данную запись: ";
        private const string errorDelete = "Не удалось удалить запись: ";
        private const string errorUpdate = "Не удалось обновить запись: ";

        public ClientNumberKeysModel(IFactoryLogic factoryLogic)
        {
            if (factoryLogic == null)
            {
                throw new ArgumentNullException(nameof(factoryLogic));
            }
            var db = Context.GetContext();
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }
            clientNumberKeysLogic = factoryLogic.CreateClientNumberKeys(db);
            keyFeatureClientLogic = factoryLogic.CreateKeyFeatureClient(db);
            keyFeatureLogic = factoryLogic.CreateKeyFeature(db);
        }

        public bool Remove(int id) => clientNumberKeysLogic.Remove(id);

        public bool Add(IEnumerable<ModelViewClientNumberKeys> keyClient, out string error)
        {
            if (keyClient == null)
                throw new ArgumentNullException(nameof(keyClient));

            error = string.Empty;
            foreach (var item in keyClient)
                if (!clientNumberKeysLogic.Save(item.ClientNumberKeys))
                    error += errorAdd + item.Id + " - " + item.Name + '\n';

            return string.IsNullOrEmpty(error);
        }

        public List<ModelViewClientNumberKeys> NumberKeys()
        {
            var CNK = clientNumberKeysLogic.GetAll();
            var KFC = keyFeatureClientLogic.GetAll();
            var KF = keyFeatureLogic.GetAll();

           
            var validKeys = from kfc in KFC
                            join kf in KF on kfc.IdKeyFeature equals kf.Id
                            where kf.EndDate >= DateTime.Now
                            group kf by new { kfc.IdClient, kf.IdHaspKey } into g
                            select new
                            {
                                IdClient = g.Key.IdClient,
                                IdHaspKey = g.Key.IdHaspKey,
                                ClosestEndDate = g.Min(k => k.EndDate)
                            };

           
            var clientKeyFeatureCounts = from kfc in KFC
                                         join kf in KF on kfc.IdKeyFeature equals kf.Id
                                         join vk in validKeys on new { kf.IdHaspKey, kfc.IdClient } equals new { vk.IdHaspKey, vk.IdClient } into vkJoin
                                         from vk in vkJoin.DefaultIfEmpty()
                                         group new { kfc, kf, vk } by kfc.IdClient into g
                                         select new
                                         {
                                             IdClient = g.Key,
                                             ValidKeyCount = g.Select(x => x.vk?.IdHaspKey).Distinct().Count(x => x != null),
                                             ValidFeatureCount = g.Sum(x => x.kf.EndDate >= DateTime.Now ? 1 : 0)
                                         };

            
            var result = from ckfc in clientKeyFeatureCounts
                         join c in CNK on ckfc.IdClient equals c.Id
                         join vk in validKeys on ckfc.IdClient equals vk.IdClient into vkJoin
                         from vk in vkJoin.DefaultIfEmpty()
                         group vk by new { ckfc.IdClient, c.Name, ckfc.ValidKeyCount, ckfc.ValidFeatureCount } into g
                         select new ModelViewClientNumberKeys
                         {
                             Id = g.Key.IdClient,
                             Name = g.Key.Name,
                             NumberKeys = g.Key.ValidFeatureCount == 0 ? 0 : g.Key.ValidKeyCount,
                             NumberFeatures = g.Key.ValidFeatureCount,
                             EndDate = g.Select(x => x?.ClosestEndDate).FirstOrDefault()?.ToString("yyyy-MM-dd") ?? "нет активных"
                         };

            return result.ToList();
        }

        public bool Update(ModelViewClientNumberKeys entity)
        {
            if (entity == null) 
            {
                throw new ArgumentNullException(nameof(entity));
            }
            return clientNumberKeysLogic.Update(entity.ClientNumberKeys);
        }

        public void Dispose() => db.Dispose();



        //public List<ModelViewClientNumberKeys> GetAll() => NumberKeys();

        public bool Add(ModelViewClientNumberKeys entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return clientNumberKeysLogic.Save(entity.ClientNumberKeys);
        }

        public bool Update(IEnumerable<ModelViewClientNumberKeys> keyClient, out string error)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IEnumerable<int> idKeyClient, out string error)
        {
            throw new NotImplementedException();
        }
    }
}
