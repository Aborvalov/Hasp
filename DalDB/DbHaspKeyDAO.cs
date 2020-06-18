using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DalDB
{
    public class DbHaspKeyDAO : IContractHaspKeyDAO
    {
        private readonly EntitesContext db;
        private readonly DateTime date = DateTime.Now.Date;

        public DbHaspKeyDAO(EntitesContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }
                       
        public int Add(HaspKey entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            HaspKey haspKey = db.HaspKeys.Add(entity);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return -1;
            }
            catch 
            {
                throw;
            }

            return haspKey.Id;
        }
               
        public List<HaspKey> GetByActive()
        {
            var haspKeys = new List<HaspKey>();
            HaspKey hk;

            var keyFeature = db.KeyFeatures
                               .Where(kf => kf.EndDate >= date)
                               .ToList();

            foreach (var kf in keyFeature)
            {
                hk = GetById(kf.IdHaspKey);
                if (!haspKeys.Contains(hk))
                    haspKeys.Add(hk);
            }
            return haspKeys;
        }

        public List<HaspKey> GetAll() => db.HaspKeys.ToList();
               
        public List<HaspKey> GetByPastDue()
        {
            var keyFeatures = db.KeyFeatures.ToList();
            
            var haspKeysPastDue = (from haspKey in GetAll()
                                   join keyFeature in keyFeatures
                                     on haspKey.Id equals keyFeature.IdHaspKey
                                  where keyFeature.EndDate == (from keyFea in keyFeatures
                                                              where keyFea.IdHaspKey == haspKey.Id
                                                             select keyFea)
                                                              .Max(x => x.EndDate) &&
                                        keyFeature.EndDate < date
                                  select new HaspKey
                                  {
                                      Id       = haspKey.Id,
                                      InnerId  = haspKey.InnerId,
                                      Number   = haspKey.Number,
                                      Location = haspKey.Location,
                                      TypeKey  = haspKey.TypeKey,
                                  })
                                  .Distinct().ToList();

            #region SQL запрос.

            /*
             *
            select * 
            from HaspKeys as hk inner join KeyFeatures as kf
                 on hk.Id = kf.IdHaspKey
            where EndDate = (select max(EndDate)
                                from keyFeatures
                                where IdHaspKey = hk.Id) and
                EndDate < date()

            */

            #endregion

            return haspKeysPastDue;
        }
                
        public List<HaspKey> GetByClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            var keyFeatures      = db.KeyFeatures.ToList();
            var keyFeatureCliets = db.KeyFeatureClients.ToList();

            var haspKeys = (from keyFeatureCk in keyFeatureCliets
                            join keyFeat in keyFeatures
                              on keyFeatureCk.IdKeyFeature equals keyFeat.Id
                            join jaspKey in GetAll()
                              on keyFeat.IdHaspKey equals jaspKey.Id
                            where keyFeatureCk.IdClient == client.Id
                            select new HaspKey
                            {
                                Id       = jaspKey.Id,
                                InnerId  = jaspKey.InnerId,
                                Number   = jaspKey.Number,
                                Location = jaspKey.Location,
                                TypeKey  = jaspKey.TypeKey,
                            }) 
                         .Distinct().ToList();


            #region SQL запрос.
            /*
              select distinct hk.*
                from KeyFeatureClients as kfc join KeyFeatures as kf
                     on kfc.IdKeyFeature = kf.Id
                     join HaspKeys as hk on kf.IdHaspKey = hk.Id
                 where kfc.IdClient = 1
             */
            #endregion

            return haspKeys;
        }

        public HaspKey GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.",nameof(id));

            var haspKey = db.HaspKeys.SingleOrDefault(hs => hs.Id == id);

            return haspKey;
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            HaspKey haspKey = GetById(id);
            if (haspKey == null)
                return false;

            var keyFeature = db.KeyFeatures
                               .Where(kf => kf.IdHaspKey == id)
                               .ToList();

            var keyFeatureClients = new List<KeyFeatureClient>();
            
            db.HaspKeys.Remove(haspKey);

            foreach (var kf in keyFeature)
            {
                db.KeyFeatures.Remove(kf);

                keyFeatureClients = db.KeyFeatureClients
                                      .Where(kefFeatureClient => kefFeatureClient.IdKeyFeature == kf.Id)
                                      .ToList();

                foreach (var kfc in keyFeatureClients)
                    db.KeyFeatureClients.Remove(kfc);
            }
                
            db.SaveChanges();            
            
            return true;
        }
                
        public bool Update(HaspKey entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            HaspKey haspKey = GetById(entity.Id);
            if (haspKey == null)
                return false;

            haspKey.InnerId  = entity.InnerId;
            haspKey.Number   = entity.Number;
            haspKey.TypeKey  = haspKey.TypeKey;
            haspKey.Location = haspKey.Location;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }
            catch
            {
                throw;
            }

            return true;
        }
        /// <summary>
        /// Проверка на дубли.
        /// </summary>
        /// <param name="entity">HASP-ключ</param>
        /// <returns>Результат проверки.</returns>
        public bool ContainsDB(HaspKey entity)
        {
            HaspKey key = db.HaspKeys
                       .SingleOrDefault(hk =>
                                        hk.InnerId  == entity.InnerId &&
                                        hk.Number   == entity.Number &&
                                        hk.TypeKey  == entity.TypeKey &&
                                        hk.Location == entity.Location );

            return key != null;
        }
    }
}
