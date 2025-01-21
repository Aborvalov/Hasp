using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DalDB
{
    public class DbClientDAO : IContractClientDAO, IDisposable
    {
        private readonly EntitesContext db;
        private bool disposed = false;
        public Logging logger;

        public DbClientDAO(IEntitesContext db)
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

        public int Add(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var client = db.Clients.Add(entity);

            db.SaveChanges();

            logger.OnLogging("Users", "добавлено", entity.Id);

            return client.Id;
        }

        public List<Client> GetAll() => db.Clients.ToList();
        
        public List<Client> GetByFeature(Feature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            var keyFeatures      = db.KeyFeatures.ToList();
            var keyFeatureClients = db.KeyFeatureClients.ToList();

            var clientFeature = (from keyFeatureClient in keyFeatureClients
                                 join keyFeature in keyFeatures
                                   on keyFeatureClient.IdKeyFeature equals keyFeature.Id
                                 join client in GetAll()
                                   on keyFeatureClient.IdClient equals client.Id
                                where keyFeature.IdFeature == feature.Id
                               select new Client
                                 {
                                     Id            = client.Id,
                                     Name          = client.Name,
                                     Address       = client.Address,
                                     ContactPerson = client.ContactPerson,
                                     Phone         = client.Phone,
                                 })
                                 .Distinct().ToList();

            return clientFeature;
            #region SQlзапрос
            /*
             select c.*
               from KeyFeatureClients as kfc join KeyFeatures as kf
                 on kfc.IdKeyFeature = kf.Id
               join Clients as c on c.Id = kfc.IdClient
              where kf.IdFeature = 1
             */
            #endregion
        }

        public Client GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var client = db.Clients.SingleOrDefault(c => c.Id == id);
            return client;
        }
        
        public Client GetByNumberKey(int keyInnerId)
        {
            if (keyInnerId < 1)
                throw new ArgumentException("Неверное значение.", nameof(keyInnerId));

            var haspKey = db.HaspKeys.SingleOrDefault(hk => hk.InnerId == keyInnerId);
            if (haspKey == null)
                return null;

            var keyFeatures      = db.KeyFeatures.ToList();
            var keyFeatureClients = db.KeyFeatureClients.ToList();
            var haspKeys         = db.HaspKeys.ToList();

            int idClient = 0;
            try
            {
                idClient = (from keyFeatureClient in keyFeatureClients
                            join keyFeature in keyFeatures
                              on keyFeatureClient.IdKeyFeature equals keyFeature.Id
                            join key in haspKeys
                              on keyFeature.IdHaspKey equals key.Id
                            where key.InnerId == keyInnerId
                            select keyFeatureClient.IdClient)
                           .Last();
            }
            catch (InvalidOperationException)
            {
                return null;
            }            

            return GetById(idClient);
            #region SQL запрос.
            /*
              select *
                from Clients
                where id = (select distinct kfc.IdClient
                              from KeyFeatureClients as kfc join KeyFeatures as kf
                                   on kfc.IdKeyFeature = kf.Id
                                   join HaspKeys as hk on kf.IdHaspKey = hk.Id
                             where hk.InnerId = 12 )

             */
            #endregion
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var client = GetById(id);
            if (client == null)
                return false;

            var keyFeatureClients = db.KeyFeatureClients
                                      .Where(kfc => kfc.IdClient == id);

            db.Clients.Remove(client);
            db.KeyFeatureClients.RemoveRange(keyFeatureClients);

            db.SaveChanges();

            logger.OnLogging("Clients", "удалено", id);

            return true;
        }

        public bool Update(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var client = GetById(entity.Id);
            if (client == null)
                return false;

            client.Name          = entity.Name;
            client.Address       = entity.Address;
            client.ContactPerson = entity.ContactPerson;
            client.Phone         = entity.Phone;

            db.SaveChanges();

            logger.OnLogging("Clients", "обновлено", entity.Id);

            return true;
        }

        public bool ContainsDB(Client entity)
        {
            var client = db.Clients
                       .SingleOrDefault(c => c.Name          == entity.Name &&
                                             c.Address       == entity.Address &&
                                             c.ContactPerson == entity.ContactPerson &&
                                             c.Phone         == entity.Phone);
            return client != null;
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