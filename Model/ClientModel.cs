using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class ClientModel : IClientModel
    {
        private readonly IKeyFeatureClientLogic keyFeatureClientLogic;
        private readonly IKeyFeatureLogic keyFeatureLogic;
        private readonly IFeatureLogic featureLogic;
        private readonly IHaspKeyLogic haspKeyLogic;
        private readonly IClientLogic clientLogic;
        private readonly IEntitesContext db;

        public ClientModel(IFactoryLogic factoryLogic)
        {
            if (factoryLogic == null)
                throw new ArgumentNullException(nameof(factoryLogic));

            db = Context.GetContext();
            if (db == null)
                throw new ArgumentNullException(nameof(db));

            keyFeatureClientLogic = factoryLogic.CreateKeyFeatureClient(db);
            keyFeatureLogic = factoryLogic.CreateKeyFeature(db);
            featureLogic = factoryLogic.CreateFeature(db);
            haspKeyLogic = factoryLogic.CreateHaspKey(db);
            clientLogic = factoryLogic.CreateClient(db);
        }

        public bool Add(ModelViewClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return clientLogic.Save(entity.Client);
        }

        public void Dispose() => db.Dispose();

        public List<ModelViewClient> GetAll() => Convert(clientLogic.GetAll());
        
        public List<ModelViewClient> GetByFeature(ModelViewFeature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));
                        
            return Convert(clientLogic.GetByFeature(feature.Feature));
        }

        public ModelViewClient GetById(int id) => 
            new ModelViewClient(clientLogic.GetById(id));

        public ModelViewClient GetByNumberKey(int keyInnerId)
        {
            Client client = clientLogic.GetByNumberKey(keyInnerId);

            if (client == null)
                return null;
            return new ModelViewClient(client);
        }

        public bool Remove(int id) => clientLogic.Remove(id);

        public bool Update(ModelViewClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return clientLogic.Update(entity.Client);
        }
        private List<ModelViewClient> Convert(List<Client> clients)
        {
            var viewClients = new List<ModelViewClient>();           
            foreach (var cl in clients)
                viewClients.Add(new ModelViewClient(cl));
            return viewClients;
        }

        public List<ModelViewClient> GetNumberOfKeysAndFeatures()
        {
            var C = clientLogic.GetAll();
            var KFC = keyFeatureClientLogic.GetAll();
            var KF = keyFeatureLogic.GetAll();

            var validKeys = from kfc in KFC
                            join kf in KF on kfc.IdKeyFeature equals kf.Id
                            where kf.EndDate >= DateTime.Now
                            group kf by new { kfc.IdClient, kf.IdHaspKey } into g
                            select new
                            {
                                g.Key.IdClient,
                                g.Key.IdHaspKey,
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
                                             ValidFeatureCount = g.Sum(x => x.kf.EndDate >= DateTime.Now ? 1 : 0),
                                             ClosestEndDate = g.Select(x => x.vk?.ClosestEndDate).FirstOrDefault()
                                         };

            var result = (from c in C
                          join ckfc in clientKeyFeatureCounts on c.Id equals ckfc.IdClient into ckfcJoin
                          from ckfc in ckfcJoin.DefaultIfEmpty()
                          orderby c.Name

                          select new ModelViewClient
                          {
                              Id = c.Id,
                              Name = c.Name,
                              NumberKeys = ckfc?.ValidFeatureCount == 0 ? 0 : ckfc?.ValidKeyCount ?? 0,
                              NumberFeatures = ckfc?.ValidFeatureCount ?? 0,
                              EndDate = ckfc?.ClosestEndDate.HasValue ?? false
                                         ? (ckfc.ClosestEndDate.Value.Year == 2111 ? "\u221E" : ckfc.ClosestEndDate.Value.ToString("dd-MM-yyyy"))
                                         : "нет активных"
                          }).ToList();

            return result;
        }

        public bool Add(IEnumerable<ModelViewClient> keyClient, out string error)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }

            error = string.Empty;

            if (!keyClient.Any())
                return true;

            foreach (var item in keyClient)
            {
                clientLogic.Save(item.Client);
            }
            return string.IsNullOrEmpty(error);
        }

        public bool Update(IEnumerable<ModelViewClient> keyClient, out string error)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }

            error = string.Empty;

            if (!keyClient.Any())
                return true;

            var allKeyAtClient = GetNumberOfKeysAndFeatures();
            var updateList = new List<ModelViewClient>();
            foreach (var item in keyClient)
            {
                if (allKeyAtClient.Any(x => clientLogic.Equals(item.Client)))
                    continue;
                updateList.Add(item);
                clientLogic.Update(item.Client);
            }
            return string.IsNullOrEmpty(error);
        }

        public bool Remove(IEnumerable<ModelViewClient> keyClient, out string error)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }

            error = string.Empty;
            var updateList = new List<ModelViewClient>();
            var all = GetNumberOfKeysAndFeatures();
            foreach (var item in keyClient)
            {
                if (all.Any(x => clientLogic.Equals(item.Client)))
                    continue;
                updateList.Add(item);
                clientLogic.Update(item.Client);
            }
            return string.IsNullOrEmpty(error);
        }

        public List<ModelViewClient> GetByFeature(int id)
        {
            var C = clientLogic.GetAll();
            var KFC = keyFeatureClientLogic.GetAll();
            var KF = keyFeatureLogic.GetAll();
            var F = featureLogic.GetAll();

            var validKeys = from kfc in KFC
                            join kf in KF on kfc.IdKeyFeature equals kf.Id
                            where kf.EndDate >= DateTime.Now
                            group kf by new { kfc.IdClient, kf.IdHaspKey } into g
                            select new
                            {
                                g.Key.IdClient,
                                g.Key.IdHaspKey,
                                ClosestEndDate = g.Min(k => k.EndDate)
                            };

            var clientKeyFeatureCounts = from kfc in KFC
                                         join kf in KF on kfc.IdKeyFeature equals kf.Id
                                         join f in F on kf.IdFeature equals f.Id
                                         join vk in validKeys on new { kf.IdHaspKey, kfc.IdClient } equals new { vk.IdHaspKey, vk.IdClient } into vkJoin
                                         from vk in vkJoin.DefaultIfEmpty()
                                         where f.Id == id
                                         group new { kfc, kf, vk } by kfc.IdClient into g
                                         select new
                                         {
                                             IdClient = g.Key,
                                             ValidKeyCount = g.Select(x => x.vk?.IdHaspKey).Distinct().Count(x => x != null),
                                             ValidFeatureCount = g.Sum(x => x.kf.EndDate >= DateTime.Now ? 1 : 0),
                                             ClosestEndDate = g
                                                 .Select(x => x.vk?.ClosestEndDate)
                                                 .Where(date => date >= DateTime.Now)
                                                 .DefaultIfEmpty(null)
                                                 .Min()
                                         };

            var result = (from c in C
                          join ckfc in clientKeyFeatureCounts on c.Id equals ckfc.IdClient into ckfcJoin
                          from ckfc in ckfcJoin.DefaultIfEmpty()
                          where ckfc != null && ckfc.ValidFeatureCount > 0
                          orderby c.Name

                          select new ModelViewClient
                          {
                              Id = c.Id,
                              Name = c.Name,
                              NumberKeys = ckfc.ValidFeatureCount == 0 ? 0 : ckfc.ValidKeyCount,
                              NumberFeatures = ckfc.ValidFeatureCount,
                              EndDate = ckfc.ClosestEndDate.HasValue
                                         ? (ckfc.ClosestEndDate.Value.Year == 2111 ? "\u221E" : ckfc.ClosestEndDate.Value.ToString("yyyy-MM-dd"))
                                         : "нет активных"
                          }).GroupBy(r => r.Id)
                          .Select(g => g.First())
                          .ToList();

            return result;
        }

        public List<ModelViewClient> GetByInnerId(int id)
        {
            var C = clientLogic.GetAll();
            var KFC = keyFeatureClientLogic.GetAll();
            var KF = keyFeatureLogic.GetAll();
            var HK = haspKeyLogic.GetAll();

            var validKeys = from kfc in KFC
                            join kf in KF on kfc.IdKeyFeature equals kf.Id
                            join hk in HK on kf.IdHaspKey equals hk.Id
                            where kf.EndDate >= DateTime.Now && hk.InnerId == id
                            group kf by new { kfc.IdClient, kf.IdHaspKey } into g
                            select new
                            {
                                g.Key.IdClient,
                                g.Key.IdHaspKey,
                                ClosestEndDate = g.Min(k => k.EndDate)
                            };

            var clientKeyFeatureCounts = from kfc in KFC
                                         join kf in KF on kfc.IdKeyFeature equals kf.Id
                                         join hk in HK on kf.IdHaspKey equals hk.Id
                                         where kf.EndDate >= DateTime.Now && hk.InnerId == id
                                         group kf by new { kfc.IdClient, kf.IdHaspKey } into g
                                         select new
                                         {
                                             g.Key.IdClient,
                                             g.Key.IdHaspKey,
                                             ValidFeatureCount = g.Count()
                                         };

            var result = (from c in C
                          join kfc in KFC on c.Id equals kfc.IdClient
                          join kf in KF on kfc.IdKeyFeature equals kf.Id
                          join hk in HK on kf.IdHaspKey equals hk.Id
                          where hk.InnerId == id
                          join vk in validKeys on new { IdClient = c.Id, kf.IdHaspKey } equals new { vk.IdClient, vk.IdHaspKey } into vkJoin
                          from vk in vkJoin.DefaultIfEmpty()
                          join ckfc in clientKeyFeatureCounts on new { IdClient = c.Id, kf.IdHaspKey } equals new { ckfc.IdClient, ckfc.IdHaspKey } into ckfcJoin
                          from ckfc in ckfcJoin.DefaultIfEmpty()
                          orderby c.Name

                          select new ModelViewClient
                          {
                              Id = c.Id,
                              Name = c.Name,
                              NumberKeys = 1,
                              NumberFeatures = ckfc != null ? ckfc.ValidFeatureCount : 0,
                              EndDate = vk != null && vk.ClosestEndDate != DateTime.MinValue
                             ? (vk.ClosestEndDate.Year == 2111 ? "\u221E" : vk.ClosestEndDate.ToString("yyyy-MM-dd"))
                             : "нет активных"
                          }).GroupBy(x => new { x.Name })
                            .Select(g => g.First())
                            .Distinct()
                            .ToList();

            return result;
        }
    }
}
