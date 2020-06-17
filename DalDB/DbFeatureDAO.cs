using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DalDB
{
    public class DbFeatureDAO : IContractFeatureDAO
    {
        private EntitesContext Db { get; }

        public DbFeatureDAO(EntitesContext db)
        {
            this.Db = db ?? throw new ArgumentNullException(nameof(db));  
        }

        public int Add(Feature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (ContainsDB(entity) != -1)
                throw new Exception("Данный функционал имеется в базе.");

            var feature = Db.Features.Add(entity);
            Db.SaveChanges();

            return feature.Id;
        }

        public List<Feature> GetAll() => Db.Features.ToList();

        public Feature GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var feature = Db.Features.SingleOrDefault(f => f.Id == id);
            return feature;
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            Feature feature = CheckFeatureInDb(id);

            List<KeyFeature> keyFeatures = Db.KeyFeatures
                                             .Where(kf => kf.IdFeature == id)
                                             .ToList();

            List<KeyFeatureClient> keyFeatureClients;

            try
            {
                Db.Features.Remove(feature);

                foreach (var kf in keyFeatures)
                {
                    Db.KeyFeatures.Remove(kf);

                    keyFeatureClients = Db.KeyFeatureClients
                                          .Where(kfc => kfc.IdKeyFeature == kf.Id)
                                          .ToList();

                    foreach (var kfc in keyFeatureClients)
                        Db.KeyFeatureClients.Remove(kfc);
                }

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

        public bool Update(Feature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (ContainsDB(entity) != -1)
                throw new Exception("Данный функционал имеется в базе.");

            Feature feature = CheckFeatureInDb(entity.Id);

            feature.Number      = entity.Number;
            feature.Name        = entity.Name;
            feature.Description = entity.Description;

            Db.SaveChanges();

            return true;
        }

        /// <summary>
        /// Проверка фичи на наличе в баазе.
        /// </summary>
        /// <param name="id">id фичи.</param>
        /// <returns>Фича.</returns>
        private Feature CheckFeatureInDb(int id)
        {
            var feature = GetById(id);
            if (feature == null)
                throw new NullReferenceException("Объект не найден в базе, " + nameof(feature));
            return feature;
        }
        /// <summary>
        /// Проверка на дубли.(При)
        /// </summary>
        /// <param name="entity">Функционал.</param>
        /// <returns>Результат проверки.</returns>
        private int ContainsDB(Feature entity)
        {
            int id = Db.Features
                       .SingleOrDefault(f =>
                                        f.Number == entity.Number &&
                                        f.Name   == entity.Name)
                       ?.Id ?? -1;

            return id;
        }
    }
}