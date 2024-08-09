using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DalDB
{
    public class DbFeatureDAO : IContractFeatureDAO
    {
        private readonly EntitesContext db;
        public Logging logger;

        public DbFeatureDAO(IEntitesContext db)
        {
            this.db = (EntitesContext)db ?? throw new ArgumentNullException(nameof(db));
            logger = new Logging(this.db);
            logger.LoggingEvent += (sender, e) => logger.UpdateLog(e.TableName, e.Action, e.Id);
        }

        public int Add(Feature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var feature = db.Features.Add(entity);

            db.SaveChanges();

            logger.OnLogging("Features", "добавлено", entity.Id); 

            return feature.Id;
        }

        public List<Feature> GetAll() => db.Features.ToList();

        public Feature GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var feature = db.Features.SingleOrDefault(f => f.Id == id);
            return feature;
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var feature = GetById(id);
            if (feature == null)
                return false;

            var keyFeatures = db.KeyFeatures
                                .Where(kf => kf.IdFeature == id);
                        
            db.Features.Remove(feature);
            db.KeyFeatures.RemoveRange(keyFeatures);
            foreach (var kf in keyFeatures)
            {
                var keyFeatureClients = db.KeyFeatureClients
                                      .Where(kfc => kfc.IdKeyFeature == kf.Id);
                    db.KeyFeatureClients.RemoveRange(keyFeatureClients);
            }

            db.SaveChanges();

            logger.OnLogging("Features", "удалено", id);

            return true;
        }        

        public bool Update(Feature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var feature = GetById(entity.Id);
            if (feature == null)
                return false;

            feature.Number      = entity.Number;
            feature.Name        = entity.Name;
            feature.Description = entity.Description;

            db.SaveChanges();

            logger.OnLogging("Features", "обновлено", entity.Id);

            return true;
        }

        public bool ContainsDB(Feature entity)
        {
            var feature = db.Features
                            .SingleOrDefault(f =>
                                        f.Number      == entity.Number &&
                                        f.Name        == entity.Name &&
                                        f.Description == entity.Description);

            return feature != null;
        }
    }
}