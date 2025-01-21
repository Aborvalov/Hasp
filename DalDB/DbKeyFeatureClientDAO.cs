using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DalDB
{
    public class DbKeyFeatureClientDAO : IContractKeyFeatureClientDAO, IDisposable
    {
        private readonly EntitesContext db;
        private bool disposed = false;
        public Logging logger;

        public DbKeyFeatureClientDAO(IEntitesContext db)
        {
            this.db = (EntitesContext)db ?? throw new ArgumentNullException(nameof(db));
            logger = new Logging(this.db);
            logger.LoggingEvent += OnLoggingEvent;
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

        private void OnLoggingEvent(object sender, LogEventArgs e)
        {
            logger.UpdateLog(e.TableName, e.Action, e.Id);
        }

        public int Add(KeyFeatureClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var keyFeatureClient = db.KeyFeatureClients.Add(entity);

            db.SaveChanges();

            logger.OnLogging("KeyFeatureClients", "добавлено", entity.Id);

            return keyFeatureClient.Id;
        }

        public List<KeyFeatureClient> GetAll() => db.KeyFeatureClients.ToList();

        public KeyFeatureClient GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var keyFeatureClient = db.KeyFeatureClients
                                     .SingleOrDefault(kfc => kfc.Id == id);

            return keyFeatureClient;
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var keyFeatureClient = GetById(id);
            if (keyFeatureClient == null)
                return false;

            db.KeyFeatureClients.Remove(keyFeatureClient);

            db.SaveChanges();

            logger.OnLogging("KeyFeatureClients", "удалено", id);

            return true;
        }

        public bool Update(KeyFeatureClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var keyFeatureClient = GetById(entity.Id);
            if (keyFeatureClient == null)
                return false;

            keyFeatureClient.IdClient     = entity.IdClient;
            keyFeatureClient.IdKeyFeature = entity.IdKeyFeature;
            keyFeatureClient.Note         = entity.Note;
            keyFeatureClient.Initiator    = entity.Initiator;

            db.SaveChanges();

            logger.OnLogging("KeyFeatureClients", "обновлено", entity.Id);

            return true;
        }

        public bool ContainsDB(KeyFeatureClient entity)
        {
            var kfc = db.KeyFeatureClients
                        .SingleOrDefault(x =>
                                         x.IdKeyFeature == entity.IdKeyFeature &&
                                         x.IdClient     == entity.IdClient &&
                                         x.Initiator    == entity.Initiator &&
                                         x.Note         == entity.Note);
            return kfc != null;
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