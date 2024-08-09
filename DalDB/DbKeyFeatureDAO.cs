using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DalDB
{
    public class DbKeyFeatureDAO : IContractKeyFeatureDAO
    {
        private readonly EntitesContext db;

        public DbKeyFeatureDAO(IEntitesContext db)
        {
            this.db = (EntitesContext)db ?? throw new ArgumentNullException(nameof(db));
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

        public int Add(KeyFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var keyFeature = db.KeyFeatures.Add(entity);

            db.SaveChanges();

            UpdateLog("KeyFeatures", "добавлено", entity.Id);

            return keyFeature.Id;
        }

        public List<KeyFeature> GetAll() => db.KeyFeatures.ToList();

        public KeyFeature GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var keyFeature = db.KeyFeatures
                               .SingleOrDefault(kf => kf.Id == id);

            return keyFeature;
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            KeyFeature keyFeature = GetById(id);
            if (keyFeature == null)
                return false;

            var keyFeatureClient = db.KeyFeatureClients
                                     .Where(kfc => kfc.IdKeyFeature == id)
                                     .ToList();

            db.KeyFeatures.Remove(keyFeature);
            db.KeyFeatureClients.RemoveRange(keyFeatureClient);

            db.SaveChanges();

            UpdateLog("KeyFeatures", "удалено", id);

            return true;
        }
                
        public bool Update(KeyFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var keyFeature = GetById(entity.Id);
            if (keyFeature == null)
                return false;

            keyFeature.IdFeature = entity.IdFeature;
            keyFeature.IdHaspKey = entity.IdHaspKey;
            keyFeature.StartDate = entity.StartDate;
            keyFeature.EndDate   = entity.EndDate;

            db.SaveChanges();

            UpdateLog("KeyFeatures", "обновлено", entity.Id);

            return true;
        }

        public bool ContainsDB(KeyFeature entity)
        {
            var keyFeature = db.KeyFeatures
                       .SingleOrDefault(x =>
                                        x.IdHaspKey == entity.IdHaspKey &&
                                        x.IdFeature == entity.IdFeature &&
                                        x.StartDate == entity.StartDate &&
                                        x.EndDate   == entity.EndDate);
            return keyFeature != null;
        }
    }
}
