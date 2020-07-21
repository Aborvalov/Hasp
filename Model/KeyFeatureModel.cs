using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class KeyFeatureModel : IKeyFeatureModel
    {
        private readonly IEntitesContext db;
        private readonly IFeatureLogic featLogic;
        private readonly IKeyFeatureLogic keyFeatureLogic;
        private readonly IFactoryLogic factoryLogic;
        private ModelViewKeyFeature model;
        private readonly DateTime date = DateTime.Now.Date;

        private const string errorAdd = "Не удалось создать запись с данной функциональностью: ";
        private const string errorUpdate = "Не удалось обновить запись с данной функциональностью: ";
        private const string errorDelete = "Не удалось удалить запись: ";

        public KeyFeatureModel(IFactoryLogic factoryLogic)
        {
            this.factoryLogic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));

            db = Context.GetContext();
            if (db == null)
                throw new ArgumentNullException(nameof(db));

            featLogic = this.factoryLogic.CreateFeature(db);
            keyFeatureLogic = this.factoryLogic.CreateKeyFeature(db);
        }

        public bool Add(IEnumerable<ModelViewKeyFeature> keyFeat, out string error)
        {
            if (keyFeat == null)
                throw new ArgumentNullException(nameof(keyFeat));

            error = string.Empty;

            foreach (var item in keyFeat)
            {
                var keyFeature = new KeyFeature()
                {
                    IdFeature = item.IdFeature,
                    IdHaspKey = item.IdKey,
                    StartDate = item.StartDate ?? DateTime.MinValue,
                    EndDate = item.EndDate ?? DateTime.MinValue,
                };

                if (!this.keyFeatureLogic.Save(keyFeature))
                    error += errorAdd + item.Feature + '\n';
            }

            return string.IsNullOrEmpty(error);
        }

        public void Dispose() => db.Dispose();
               
        public List<ModelViewKeyFeature> GetAllFeatureAtKey(int idKey)
        {
            var listKeyFeat = keyFeatureLogic.GetAll()
                              .Where(x => x.IdHaspKey == idKey);

            var viewFeature = new List<ModelViewKeyFeature>();
            foreach (var item in featLogic.GetAll())
            {
                model = new ModelViewKeyFeature(item)
                {
                    IdKey = idKey,
                };

                var itemKeyFeature = listKeyFeat
                                     .LastOrDefault(x => x.IdFeature == item.Id &&
                                                         x.EndDate >= date);

                if (itemKeyFeature != null)
                {
                    model.Selected = true;
                    model.StartDate = itemKeyFeature.StartDate;
                    model.EndDate = itemKeyFeature.EndDate;
                    model.IdKeyFeature = itemKeyFeature.Id;                 
                }                

                viewFeature.Add(model);
            }
            return viewFeature;
        }

        public bool Remove(IEnumerable<int> idFeatureKey, out string error)
        {
            if (idFeatureKey == null)
                throw new ArgumentNullException(nameof(idFeatureKey));

            error = string.Empty;

            foreach (var id in idFeatureKey)
                if (!keyFeatureLogic.Remove(id))
                    error += errorDelete + id.ToString() + '\n';

            return string.IsNullOrEmpty(error);
        }

        public bool Update(IEnumerable<ModelViewKeyFeature> keyFeat, out string error)
        {
            if (keyFeat == null)
                throw new ArgumentNullException(nameof(keyFeat));

            error = string.Empty;
            var allFeatureAtKey = GetAllFeatureAtKey(keyFeat.First().IdKey);
            foreach (var item in keyFeat)
            {
                if (allFeatureAtKey
                    .Any(x => x.IdKeyFeature == item.IdKeyFeature &&
                              x.Selected == item.Selected &&
                              x.EndDate == item.EndDate &&
                              x.StartDate == item.StartDate))
                    continue;
                
                var keyFeature = new KeyFeature()
                {
                    Id = item.IdKeyFeature,
                    IdFeature = item.IdFeature,
                    IdHaspKey = item.IdKey,
                    StartDate = (DateTime)item.StartDate,
                    EndDate = (DateTime)item.EndDate,
                };

                if (!this.keyFeatureLogic.Update(keyFeature))
                    error += errorUpdate + item.Feature.Name + '\n';                
            }

            return string.IsNullOrEmpty(error);
        }

        public List<KeyFeature> GetAllKeyFeature() 
            => keyFeatureLogic.GetAll();
    }
}
