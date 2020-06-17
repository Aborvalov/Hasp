using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DalDB
{
    public class DbKeyFeatureDAO : IContractKeyFeatureDAO
    {
        private EntitesContext Db { get; }
        public DbKeyFeatureDAO(EntitesContext db)
        {
            this.Db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public int Add(KeyFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (ContainsDB(entity))
                throw new Exception("Данная запись имеется в базе.");

            var keyFeature = Db.KeyFeatures.Add(entity);
            Db.SaveChanges();

            return keyFeature.Id;
        }

        public List<KeyFeature> GetAll() => Db.KeyFeatures.ToList();

        public KeyFeature GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var keyFeature = Db.KeyFeatures
                               .SingleOrDefault(kf => kf.Id == id);

            return keyFeature;
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            KeyFeature keyFeature = CheckKeyFeatureInDb(id);

            List<KeyFeatureClient> keyFeatureClient = Db.KeyFeatureClients
                                                        .Where(kfc => kfc.IdKeyFeature == id)
                                                        .ToList();

            try
            {
                Db.KeyFeatures.Remove(keyFeature);

                foreach (var kfc in keyFeatureClient)
                    Db.KeyFeatureClients.Remove(kfc);

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
                
        public bool Update(KeyFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (ContainsDB(entity))
                throw new Exception("Данная запись имеется в базе.");

            KeyFeature keyFeature = CheckKeyFeatureInDb(entity.Id);

            keyFeature.IdFeature = entity.IdFeature;
            keyFeature.IdHaspKey = entity.IdHaspKey;
            keyFeature.StartDate = entity.StartDate;
            keyFeature.EndDate   = entity.EndDate;

            Db.SaveChanges();

            return true;
        }
        /// <summary>
        /// Проверка на дубли связи ключ-фича.
        /// </summary>
        /// <param name="entity">Связь ключ-фича.</param>
        /// <returns>Результат проверки.</returns>
        private bool ContainsDB(KeyFeature entity)
        {
            KeyFeature kf = Db.KeyFeatures
                       .SingleOrDefault(x =>
                                        x.IdHaspKey == entity.IdHaspKey &&
                                        x.IdFeature == entity.IdFeature &&
                                        x.StartDate == entity.StartDate &&
                                        x.EndDate   == entity.EndDate);
            return kf != null;
        }
        /// <summary>
        /// Проверка наличия записи в базе. (Связь ключ-фича)
        /// </summary>
        /// <param name="id">id записи связи.</param>
        /// <returns>Связь ключ-фича.</returns>
        private KeyFeature CheckKeyFeatureInDb(int id)
        {
            var keyFeature = GetById(id);
            if (keyFeature == null)
                throw new NullReferenceException("Объект не найден в базе, " + nameof(keyFeature));

            return keyFeature;
        }
    }
}
