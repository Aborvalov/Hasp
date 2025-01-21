using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DalDB
{
    public class DbHaspKeyDAO : IContractHaspKeyDAO, IDisposable
    {
        private readonly EntitesContext db;
        private readonly DateTime date = DateTime.Now.Date;
        private bool disposed = false;
        public Logging logger;

        public DbHaspKeyDAO(IEntitesContext db)
        {
            this.db = (EntitesContext)db ?? throw new ArgumentNullException(nameof(db));
            logger = new Logging(this.db);
            logger.LoggingEvent += OnLoggingEvent;
        }

        private void OnLoggingEvent(object sender, LogEventArgs e)
        {
            logger.UpdateLog(e.TableName, e.Action, e.Id);
        }

        public void UpdateLog(string tableName, string action, int id)
        {
            var latestLog = db.Logs.OrderByDescending(l => l.LogId).FirstOrDefault();
            if (latestLog != null)
            {
                var log = tableName + "-" + action + "-" + id + "; ";
                latestLog.Actions += log;
                db.Entry(latestLog).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public int Add(HaspKey entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var haspKey = db.HaspKeys.Add(entity);

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

            logger.OnLogging("HASPKeys", "добавлено", entity.Id);

            return haspKey.Id;
        }

        public List<HaspKey> GetByActive()
        {
            var haspKeys = new List<HaspKey>();
            HaspKey hk;

            var keyFeature = db.KeyFeatures
                               .Where(kf => kf.EndDate >= date);

            foreach (var kf in keyFeature)
            {
                hk = GetById(kf.IdHaspKey);
                if (!haspKeys.Contains(hk))
                    haspKeys.Add(hk);
            }
            return haspKeys;
        }

        public List<HaspKey> GetAll() => db.HaspKeys.ToList();

        public List<HaspKey> GetAllInCompany(Client client)
        {
            var keyFeatures = db.KeyFeatures;
            var keyFeatureClients = db.KeyFeatureClients;

            var haspKeysAll = (from haspKey in GetAll()

                               join keyFeature in keyFeatures
                                 on haspKey.Id equals keyFeature.IdHaspKey

                               join kfc in keyFeatureClients
                                  on keyFeature.Id equals kfc.IdKeyFeature

                               where (client.Id == kfc.IdClient)

                               select new HaspKey
                               {
                                   Id = haspKey.Id,
                                   InnerId = haspKey.InnerId,
                                   Number = haspKey.Number,
                                   IsHome = haspKey.IsHome,
                                   TypeKey = haspKey.TypeKey,
                               })
                               .Distinct().ToList();

            return haspKeysAll;
        }

        public List<HaspKey> GetActiveInCompany(Client client)
        {
            var keyFeatures = db.KeyFeatures;
            var keyFeatureClients = db.KeyFeatureClients;

            var haspKeysAllActive = (from haspKey in GetAllInCompany(client)

                               join keyFeature in keyFeatures
                                 on haspKey.Id equals keyFeature.IdHaspKey

                               join kfc in keyFeatureClients
                                  on keyFeature.Id equals kfc.IdKeyFeature

                               where keyFeature.EndDate == ((from keyFea in keyFeatures
                                                             where keyFea.IdHaspKey == haspKey.Id
                                                             select keyFea)
                                                             .Max(x => x.EndDate)) &&
                                       (keyFeature.EndDate >= date) && 
                                       (client.Id == kfc.IdClient)

                               select new HaspKey
                               {
                                   Id = haspKey.Id,
                                   InnerId = haspKey.InnerId,
                                   Number = haspKey.Number,
                                   IsHome = haspKey.IsHome,
                                   TypeKey = haspKey.TypeKey,
                               })
                               .Distinct().ToList();

            return haspKeysAllActive;
        }

        public List<HaspKey> GetByPastDue(Client client)
        {
            var keyFeatures = db.KeyFeatures;
            var keyFeatureClients = db.KeyFeatureClients;

            var haspKeysPastDue = (from haspKey in GetAll()

                                   join keyFeature in keyFeatures
                                     on haspKey.Id equals keyFeature.IdHaspKey

                                   join kfc in keyFeatureClients
                                      on keyFeature.Id equals kfc.IdKeyFeature
                                   
                                   

                                   where keyFeature.EndDate == ((from keyFea in keyFeatures
                                                                where keyFea.IdHaspKey == haspKey.Id
                                                                select keyFea)
                                                               .Max(x => x.EndDate)) &&
                                         (keyFeature.EndDate < date) && 
                                         (client.Id == kfc.IdClient)
                                        
                                   select new HaspKey
                                   {
                                       Id = haspKey.Id,
                                       InnerId = haspKey.InnerId,
                                       Number = haspKey.Number,
                                       IsHome = haspKey.IsHome,
                                       TypeKey = haspKey.TypeKey,
                                   })
                                  .Distinct().ToList();

            return haspKeysPastDue;
        }

        public List<HaspKey> GetByClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            var keyFeatures = db.KeyFeatures.ToList();
            var keyFeatureCliets = db.KeyFeatureClients.ToList();

            var haspKeys = (from keyFeatureClient in keyFeatureCliets
                            join keyFeature in keyFeatures
                              on keyFeatureClient.IdKeyFeature equals keyFeature.Id
                            join haspKey in GetAll()
                              on keyFeature.IdHaspKey equals haspKey.Id
                            where keyFeatureClient.IdClient == client.Id
                            select new HaspKey
                            {
                                Id = haspKey.Id,
                                InnerId = haspKey.InnerId,
                                Number = haspKey.Number,
                                IsHome = haspKey.IsHome,
                                TypeKey = haspKey.TypeKey,
                            })
                         .Distinct().ToList();

            return haspKeys;
            #region SQL запрос.
            /*
              select distinct hk.*
                from KeyFeatureClients as kfc join KeyFeatures as kf
                     on kfc.IdKeyFeature = kf.Id
                     join HaspKeys as hk on kf.IdHaspKey = hk.Id
                 where kfc.IdClient = 1
             */
            #endregion
        }

        public HaspKey GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var haspKey = db.HaspKeys.SingleOrDefault(hs => hs.Id == id);

            return haspKey;
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var haspKey = GetById(id);
            if (haspKey == null)
                return false;

            var keyFeature = db.KeyFeatures.Where(kf => kf.IdHaspKey == id);

            db.KeyFeatures.RemoveRange(keyFeature);

            db.HaspKeys.Remove(haspKey);

            foreach (var kf in keyFeature)
            {
                var keyFeatureClients = db.KeyFeatureClients
                                      .Where(kefFeatureClient => kefFeatureClient.IdKeyFeature == kf.Id);

                 db.KeyFeatureClients.RemoveRange(keyFeatureClients);
            }

            db.SaveChanges();

            logger.OnLogging("HASPKeys", "удалено", id);

            return true;
        }

        public bool Update(HaspKey entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var haspKey = GetById(entity.Id);
            if (haspKey == null)
                return false;

            haspKey.InnerId = entity.InnerId;
            haspKey.Number = entity.Number;
            haspKey.TypeKey = entity.TypeKey;
            haspKey.IsHome = entity.IsHome;

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

            logger.OnLogging("HASPKeys", "обновлено", entity.Id);

            return true;
        }

        public bool ContainsDB(HaspKey entity)
        {
            var key = db.HaspKeys
                        .SingleOrDefault(hk => hk.InnerId == entity.InnerId &&
                                               hk.Number  == entity.Number &&
                                               hk.TypeKey == entity.TypeKey &&
                                               hk.IsHome  == entity.IsHome);

            return key != null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    logger.LoggingEvent -= OnLoggingEvent;
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}