using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class FeatureForMpdelJeyFeatureModel : IFeatureForModelKeyFeatureModel
    {
        private readonly EntitesContext db;
        private IFeatureLogic featLogic;
        private IKeyFeatureLogic keyFeature;
        private ModelViewFeatureForKeyFeat model;
        private readonly DateTime date = DateTime.Now.Date;

        private const string errorAdd = "Не удалось создать запись с данной функциональностью: ";
        private const string errorUpdate = "Не удалось обновить запись с данной функциональностью: ";
        private const string errorDelete = "Не удалось удалить запись: ";


        public FeatureForMpdelJeyFeatureModel(IFactoryLogic factoryLogic)
        {
            if (factoryLogic == null)
                throw new ArgumentNullException(nameof(factoryLogic));

            db = new EntitesContext();
            featLogic = factoryLogic.CreateFeature(db);
            keyFeature = factoryLogic.CreateKeyFeature(db);
        }

        public bool Add(List<ModelViewFeatureForKeyFeat> keyFeat, out string error)
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
                    StartDate = (DateTime)item.StartDate,
                    EndDate = (DateTime)item.EndDate,
                };

                if (!this.keyFeature.Save(keyFeature))
                    error += errorAdd + item.Feature + '\n';
            }

            return error == string.Empty;
        }

        public void Dispose() => db.Dispose();

        public List<ModelViewFeatureForKeyFeat> GetAll()
        {
            var viewFeature = new List<ModelViewFeatureForKeyFeat>();
            int i = 1;
            foreach (var item in featLogic.GetAll())
            {
                var model = new ModelViewFeatureForKeyFeat(item)
                {
                    SerialNumber = i++,
                };
                viewFeature.Add(model);
            }
            return viewFeature;
        }

        public List<ModelViewFeatureForKeyFeat> GetAll(int idKey)
        {
            var listKeyFeat = keyFeature.GetAll()
                              .Where(x => x.IdHaspKey == idKey);

            var viewFeature = new List<ModelViewFeatureForKeyFeat>();
            int i = 1;
            foreach (var item in featLogic.GetAll())
            {
                model = new ModelViewFeatureForKeyFeat(item)
                {
                    SerialNumber = i++,
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
                    model.IdKeyFeaure = itemKeyFeature.Id;                 
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
                if (!keyFeature.Remove(id))
                    error += errorDelete + id.ToString() + '\n';
            
            return error == string.Empty;                 
        }

        public bool Update(List<ModelViewFeatureForKeyFeat> keyFeat, out string error)
        {
            if (keyFeat == null)
                throw new ArgumentNullException(nameof(keyFeat));

            error = string.Empty;
            var all = GetAll(keyFeat[0].IdKey);
            foreach (var item in keyFeat)
            {
                if (all
                    .Where(x => x.IdKeyFeaure == item.IdKeyFeaure &&
                                   x.Selected == item.Selected &&
                                   x.EndDate == item.EndDate)
                    .Any())
                    break;
                
                var keyFeature = new KeyFeature()
                {
                    Id = item.IdKeyFeaure,
                    IdFeature = item.IdFeature,
                    IdHaspKey = item.IdKey,
                    StartDate = (DateTime)item.StartDate,
                    EndDate = (DateTime)item.EndDate,
                };

                if (!this.keyFeature.Update(keyFeature))
                    error += errorUpdate + item.Feature.Name + '\n';                
            }

            return error == string.Empty;
        }
    }
}
