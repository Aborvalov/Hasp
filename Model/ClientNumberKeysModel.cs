﻿using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Model
{
    public class ClientNumberKeysModel : IClientNumberKeysModel
    {
        public readonly IClientNumberKeysLogic clientNumberKeysLogic;
        private readonly IKeyFeatureClientLogic keyFeatureClientLogic;
        private readonly IKeyFeatureLogic keyFeatureLogic;
        private readonly IFeatureLogic featureLogic;
        private readonly IHaspKeyLogic haspKeyLogic;
        private readonly IEntitesContext db;

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
            featureLogic = factoryLogic.CreateFeature(db);
            haspKeyLogic = factoryLogic.CreateHaspKey(db);
        }

        public bool Remove(int id) => clientNumberKeysLogic.Remove(id);

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

            var result = from c in CNK
                         join ckfc in clientKeyFeatureCounts on c.Id equals ckfc.IdClient into ckfcJoin
                         from ckfc in ckfcJoin.DefaultIfEmpty()
                         orderby c.Name
                         select new ModelViewClientNumberKeys
                         {
                             Id = c.Id,
                             Name = c.Name,
                             NumberKeys = ckfc?.ValidFeatureCount == 0 ? 0 : ckfc?.ValidKeyCount ?? 0,
                             NumberFeatures = ckfc?.ValidFeatureCount ?? 0,
                             EndDate = ckfc?.ClosestEndDate.HasValue ?? false
                                        ? (ckfc.ClosestEndDate.Value.Year == 2111 ? "\u221E" : ckfc.ClosestEndDate.Value.ToString("dd-MM-yyyy"))
                                        : "нет активных"
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

        public bool Add(ModelViewClientNumberKeys entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }
            return clientNumberKeysLogic.Save(entity.ClientNumberKeys);
        }

        public bool Add(IEnumerable<ModelViewClientNumberKeys> keyClient, out string error)
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
                clientNumberKeysLogic.Save(item.ClientNumberKeys);
            }
            return string.IsNullOrEmpty(error);
        }

        public bool Update(IEnumerable<ModelViewClientNumberKeys> keyClient, out string error)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }

            error = string.Empty;

            if (!keyClient.Any())
                return true;

            var allKeyAtClient = NumberKeys();
            var updateList = new List<ModelViewClientNumberKeys>();
            foreach (var item in keyClient)
            {
                if (allKeyAtClient.Any(x => x.ClientNumberKeys.Equals(item.ClientNumberKeys)))
                    continue;
                updateList.Add(item);
                clientNumberKeysLogic.Update(item.ClientNumberKeys);
            }
            return string.IsNullOrEmpty(error);
        }

        public bool Remove(IEnumerable<ModelViewClientNumberKeys> keyClient, out string error)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }

            error = string.Empty;
            var updateList = new List<ModelViewClientNumberKeys>();
            var all = NumberKeys();
            foreach (var item in keyClient)
            {
                if (all.Any(x => x.ClientNumberKeys.Equals(item.ClientNumberKeys)))
                    continue;
                updateList.Add(item);
                clientNumberKeysLogic.Update(item.ClientNumberKeys);
            }
            return string.IsNullOrEmpty(error); ;
        }

        public List<ModelViewClientNumberKeys> GetByFeature(int id)
        {
            var CNK = clientNumberKeysLogic.GetAll();
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

            var result = (from c in CNK
                          join ckfc in clientKeyFeatureCounts on c.Id equals ckfc.IdClient into ckfcJoin
                          from ckfc in ckfcJoin.DefaultIfEmpty()
                          where ckfc != null && ckfc.ValidFeatureCount > 0
                          orderby c.Name
                          select new ModelViewClientNumberKeys
                          {
                              Id = c.Id,
                              Name = c.Name,
                              NumberKeys = ckfc.ValidFeatureCount == 0 ? 0 : ckfc.ValidKeyCount,
                              NumberFeatures = ckfc.ValidFeatureCount,
                              EndDate = ckfc.ClosestEndDate.HasValue
                                         ? (ckfc.ClosestEndDate.Value.Year == 2111 ? "\u221E" : ckfc.ClosestEndDate.Value.ToString("yyyy-MM-dd"))
                                         : "нет активных"
                          }).ToList();

            return result.GroupBy(r => r.Id).Select(g => g.First()).ToList();
        }

        public List<ModelViewClientNumberKeys> GetByInnerId(int id)
        {
            var CNK = clientNumberKeysLogic.GetAll();
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

            var result = (from c in CNK
                          join kfc in KFC on c.Id equals kfc.IdClient
                          join kf in KF on kfc.IdKeyFeature equals kf.Id
                          join hk in HK on kf.IdHaspKey equals hk.Id
                          where hk.InnerId == id
                          join vk in validKeys on new { IdClient = c.Id, kf.IdHaspKey } equals new { vk.IdClient, vk.IdHaspKey } into vkJoin
                          from vk in vkJoin.DefaultIfEmpty()
                          join ckfc in clientKeyFeatureCounts on new { IdClient = c.Id, kf.IdHaspKey } equals new { ckfc.IdClient, ckfc.IdHaspKey } into ckfcJoin
                          from ckfc in ckfcJoin.DefaultIfEmpty()
                          orderby c.Name

                          select new ModelViewClientNumberKeys
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
                            .ToList();

            return result.Distinct().ToList();
        }
    }
}
