using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DalDB
{
    public class DbHaspKeyDAO : IContractHaspKeyDAO
    {
        private EntitesContext Db { get; }
        private readonly DateTime date = DateTime.Now.Date;

        public DbHaspKeyDAO(EntitesContext db)
        {
            this.Db = db ?? throw new ArgumentNullException(nameof(db));
        }
                       
        public int Add(HaspKey entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (ContainsDB(entity) != -1)
                throw new Exception("Данный ключ имеется в базе.");

            var haspKey = Db.HaspKeys.Add(entity);
            Db.SaveChanges();

            return haspKey.Id;
        }
               
        public IEnumerable<HaspKey> GaetByActive()
        {
            List<HaspKey> haspKeys = new List<HaspKey>();
            HaspKey hk;

            var keyFeature = Db.KeyFeatures
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

        public IEnumerable<HaspKey> GetAll() => Db.HaspKeys.ToList();
                
        public IEnumerable<HaspKey> GetByPastDue()
        {
            var keyFeature = Db.KeyFeatures.ToList();


            var haspKeysPastDue = (from hk in GetAll()
                                   join kf in keyFeature
                                     on hk.Id equals kf.IdHaspKey
                                  where kf.EndDate == (from kf_ in keyFeature
                                                      where kf_.IdHaspKey == hk.Id
                                                     select kf_)
                                                      .Max(x => x.EndDate) &&
                                        kf.EndDate < date
                                  select new HaspKey
                                  {
                                      Id       = hk.Id,
                                      InnerId  = hk.InnerId,
                                      Number   = hk.Number,
                                      Location = hk.Location,
                                      TypeKey  = hk.TypeKey,
                                  })
                                  .ToList();

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
                
        public IEnumerable<HaspKey> GetByClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            var keyFeature = Db.KeyFeatures.ToList();
            var keyFeatureCliet = Db.KeyFeatureClients.ToList();
            var haspKey = GetAll();

            var haspKeys = (from kfc in keyFeatureCliet
                            join kf in keyFeature
                              on kfc.IdKeyFeature equals kf.Id
                            join hk in haspKey
                              on kf.IdHaspKey equals hk.Id
                            where kfc.IdClient == client.Id
                            select new HaspKey
                            {
                                Id = hk.Id,
                                InnerId = hk.InnerId,
                                Number = hk.Number,
                                Location = hk.Location,
                                TypeKey = hk.TypeKey,
                            }) 
                         .ToList().Distinct();


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

            var haspKey = Db.HaspKeys.SingleOrDefault(hs => hs.Id == id);

            return haspKey;
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            HaspKey haspKey = CheckHaspKeyInDb(id);

            List<KeyFeature> keyFeature = Db.KeyFeatures
                                            .Where(kf => kf.IdHaspKey == id)
                                            .ToList();

            List<KeyFeatureClient> keyFeatureClients;

            try
            {
                Db.HaspKeys.Remove(haspKey);

                foreach (var kf in keyFeature)
                {
                    Db.KeyFeatures.Remove(kf);

                    keyFeatureClients = Db.KeyFeatureClients
                                          .Where(kfc => kfc.IdKeyFeature == kf.Id)
                                          .ToList();

                    foreach (var kfc in keyFeatureClients)
                        Db.KeyFeatureClients.Remove(kfc);
                }
                
                Db.SaveChanges();
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch
            {
                throw;
            }
            
            return true;
        }
                
        public bool Update(HaspKey entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (ContainsDB(entity) != -1)
                throw new Exception("Данный ключ имеется в базе.");

            HaspKey haspKey = CheckHaspKeyInDb(entity.Id);

            haspKey.InnerId  = entity.InnerId;
            haspKey.Number   = entity.Number;
            haspKey.TypeKey  = haspKey.TypeKey;
            haspKey.Location = haspKey.Location;
            
            Db.SaveChanges();
            return true;
        }
        /// <summary>
        /// Проверка ключа на наличие в базе.
        /// </summary>
        /// <param name="id">id ключа.</param>
        /// <returnsКлюч.></returns>
        private HaspKey CheckHaspKeyInDb(int id)
        {
            var haspKey = GetById(id);
            if (haspKey == null)
                throw new NullReferenceException("Объект не найден в базе, " + nameof(haspKey));
            return haspKey;
        }

        /// <summary>
        /// Проверка на дубли.
        /// </summary>
        /// <param name="entity">HASP-ключ</param>
        /// <returns>Результат проверки.</returns>
        private int ContainsDB(HaspKey entity)
        {
            int id = Db.HaspKeys
                       .SingleOrDefault(hk => 
                                        hk.InnerId == entity.InnerId)
                       ?.Id ?? -1;

            return id;
        }
    }
}
