using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public class FeatureModel : IEntitiesModel<ModelViewFeature>
    {
        private readonly IFactoryLogic logic;
        private IFeatureLogic featLogic;

        public FeatureModel(IFactoryLogic factoryLogic)
        {
            logic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));
        }

        public bool Add(ModelViewFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Feature feature = new Feature
            {
                Name = entity.Name,
                Number = entity.Number,
                Description = entity.Description,
            };

            using (var db = new EntitesContext())
            {
                featLogic = logic.CreateFeature(db);
                return featLogic.Save(feature);
            }
        }

        public List<ModelViewFeature> GetAll()
        {
            List<Feature> features;
            using (var db = new EntitesContext())
            {
                featLogic = logic.CreateFeature(db);
               features = featLogic.GetAll();
            }

            return Convert(features);
        }

        public ModelViewFeature GetById(int id)
        {
            Feature feature;
            using (var db = new EntitesContext())
            {
                featLogic = logic.CreateFeature(db);
                feature = featLogic.GetById(id);
            }
            return new ModelViewFeature(feature);
        }

        public bool Remove(int id)
        {
            using (var db = new EntitesContext())
            {
                featLogic = logic.CreateFeature(db);
                return featLogic.Remove(id);
            }
        }

        public bool Update(ModelViewFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            Feature feature = new Feature
            {
                Id = entity.Id,
                Name = entity.Name,
                Number = entity.Number,
                Description = entity.Description,
            };

            using (var db = new EntitesContext())
            {
                featLogic = logic.CreateFeature(db);
                return featLogic.Update(feature);
            }
        }
        private List<ModelViewFeature> Convert(List<Feature> Features)
        {
            var viewFeatures = new List<ModelViewFeature>();
            int i = 1;
            foreach (var feat in Features)
            {
                var featModel = new ModelViewFeature(feat);
                featModel.SerialNumber = i++;
                viewFeatures.Add(featModel);
            }

            return viewFeatures;
        }
    }
}
