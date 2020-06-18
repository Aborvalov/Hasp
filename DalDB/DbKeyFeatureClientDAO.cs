using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DalDB
{
    public class DbKeyFeatureClientDAO : IContractKeyFeatureClientDAO
    {
        private readonly EntitesContext db;

        public DbKeyFeatureClientDAO(EntitesContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public int Add(KeyFeatureClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var keyFeatureClient = db.KeyFeatureClients.Add(entity);

            db.SaveChanges();
            
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
            
            return true;
        }

        public bool Update(KeyFeatureClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var keyFeatureClient = GetById(entity.Id);
            if (keyFeatureClient == null)
                return false;

            keyFeatureClient.IdClient     = entity.IdKeyFeature;
            keyFeatureClient.IdKeyFeature = entity.IdKeyFeature;
            keyFeatureClient.Note         = entity.Note;
            keyFeatureClient.Initiator    = entity.Initiator;

            db.SaveChanges();
            
            return true;
        }
        /// <summary>
        /// Проверка на дубли связи (ключ-фича)-клиент.
        /// </summary>
        /// <param name="entity">Связь (ключ-фича)-клиент.</param>
        /// <returns>Результат проверки.</returns>
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
    }
}