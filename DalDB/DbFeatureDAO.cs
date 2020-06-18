using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DalDB
{
    public class DbFeatureDAO : IContractFeatureDAO
    {
        private readonly EntitesContext db;

        public DbFeatureDAO(EntitesContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));  
        }

        public int Add(Feature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var feature = db.Features.Add(entity);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return -1;
            }
            catch
            {
                throw;
            }

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
                                .Where(kf => kf.IdFeature == id)
                                .ToList();

            List<KeyFeatureClient> keyFeatureClients;

            db.Features.Remove(feature);

            foreach (var kf in keyFeatures)
            {
                db.KeyFeatures.Remove(kf);

                keyFeatureClients = db.KeyFeatureClients
                                      .Where(kfc => kfc.IdKeyFeature == kf.Id)
                                      .ToList();

                foreach (var kfc in keyFeatureClients)
                    db.KeyFeatureClients.Remove(kfc);
            }

            db.SaveChanges();
           
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

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return false;
            }
            catch
            {
                throw;
            }

            return true;
        }
        /// <summary>
        /// Проверка на дубли.(При)
        /// </summary>
        /// <param name="entity">Функционал.</param>
        /// <returns>Результат проверки.</returns>
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