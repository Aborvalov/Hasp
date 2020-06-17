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

            if(ContainsDb(entity) != -1)
                throw new Exception("Данная запись имеется в базе.");

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

            var keyFeatureClient = CheckKeyFeatureClientInDb(id);

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

            if (ContainsDb(entity) != -1)
                throw new Exception("Данная запись имеется в базе.");

            var keyFeatureClient = CheckKeyFeatureClientInDb(entity.Id);

            keyFeatureClient.IdClient     = entity.IdKeyFeature;
            keyFeatureClient.IdKeyFeature = entity.IdKeyFeature;
            keyFeatureClient.Note         = entity.Note;
            keyFeatureClient.Initiator    = entity.Initiator;

            Db.SaveChanges();

            return true;
        }

        /// <summary>
        /// Проверка наличия записи в базе. (Связь (ключ-фича)-клиент)
        /// </summary>
        /// <param name="id">id записи связи.</param>
        /// <returns>Связь (ключ-фича)-клиент.</returns>
        private KeyFeatureClient CheckKeyFeatureClientInDb(int id)
        {
            var keyFeatureClient = GetById(id);
            if (keyFeatureClient == null)
                throw new NullReferenceException("Объект не найден в базе, " + nameof(keyFeatureClient));

            return keyFeatureClient;
        }

        /// <summary>
        /// Проверка на дубли связи (ключ-фича)-клиент.
        /// </summary>
        /// <param name="entity">Связь (ключ-фича)-клиент.</param>
        /// <returns>Результат проверки.</returns>
        private int ContainsDb(KeyFeatureClient entity)
        {
            int id = Db.KeyFeatureClients
                       .SingleOrDefault(kfc =>
                                        kfc.IdKeyFeature == entity.IdKeyFeature &&
                                        kfc.IdClient     == entity.IdClient)
                       ?.Id ?? -1;
            return id;
        }
    }
}