using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DalDB
{
    public class DbKeyFeatureClientDAO : IContractKeyFeatureClientDAO
    {
        private EntitesContext Db { get; }

        public DbKeyFeatureClientDAO(EntitesContext db)
        {
            this.Db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public int Add(KeyFeatureClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var keyFeatureClient = Db.KeyFeatureClients.Add(entity);
            Db.SaveChanges();

            return keyFeatureClient.Id;
        }

        public List<KeyFeatureClient> GetAll() => Db.KeyFeatureClients.ToList();

        public KeyFeatureClient GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var keyFeatureClient = Db.KeyFeatureClients
                                     .SingleOrDefault(kfc => kfc.Id == id);

            return keyFeatureClient;
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var keyFeatureClient = GetById(id);
            if (keyFeatureClient == null)
                throw new NullReferenceException("Объект не найден в базе, " + nameof(keyFeatureClient));

            try
            {
                Db.KeyFeatureClients.Remove(keyFeatureClient);
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

        public bool Update(KeyFeatureClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var keyFeatureClient = GetById(entity.Id);
            if (keyFeatureClient == null)
                throw new NullReferenceException("Объект не найден в базе, " + nameof(keyFeatureClient));

            keyFeatureClient.IdClient     = entity.IdKeyFeature;
            keyFeatureClient.IdKeyFeature = entity.IdKeyFeature;
            keyFeatureClient.Note         = entity.Note;
            keyFeatureClient.Initiator    = entity.Initiator;

            Db.SaveChanges();

            return true;
        }
        /// <summary>
        /// Проверка на дубли связи (ключ-фича)-клиент.
        /// </summary>
        /// <param name="entity">Связь (ключ-фича)-клиент.</param>
        /// <returns>Результат проверки.</returns>
        public bool ContainsDB(KeyFeatureClient entity)
        {
            KeyFeatureClient kfc = Db.KeyFeatureClients
                                   .SingleOrDefault(x =>
                                                    x.IdKeyFeature == entity.IdKeyFeature &&
                                                    x.IdClient     == entity.IdClient &&
                                                    x.Initiator    == entity.Initiator &&
                                                    x.Note         == entity.Note);
            return kfc != null;
        }
    }
}