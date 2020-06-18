using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DalDB
{
    public class DbKeyFeatureDAO : IContractKeyFeatureDAO
    {
        private readonly EntitesContext db;
        public DbKeyFeatureDAO(EntitesContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public int Add(KeyFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var keyFeature = db.KeyFeatures.Add(entity);

            db.SaveChanges();
            
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

            foreach (var kfc in keyFeatureClient)
                db.KeyFeatureClients.Remove(kfc);

            db.SaveChanges();
           
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
            
            return true;
        }
        /// <summary>
        /// Проверка на дубли связи ключ-фича.
        /// </summary>
        /// <param name="entity">Связь ключ-фича.</param>
        /// <returns>Результат проверки.</returns>
        public bool ContainsDB(KeyFeature entity)
        {
            var kf = db.KeyFeatures
                       .SingleOrDefault(x =>
                                        x.IdHaspKey == entity.IdHaspKey &&
                                        x.IdFeature == entity.IdFeature &&
                                        x.StartDate == entity.StartDate &&
                                        x.EndDate   == entity.EndDate);
            return kf != null;
        }
    }
}
