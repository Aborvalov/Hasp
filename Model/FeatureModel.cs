﻿using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public class FeatureModel : IEntitiesModel<ModelViewFeature>
    {
        private IFeatureLogic featLogic;
        private readonly EntitesContext db;

        public FeatureModel(IFactoryLogic factoryLogic)
        {
            db = new EntitesContext();            
            featLogic = factoryLogic.CreateFeature(db);
        }

        public bool Add(ModelViewFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return featLogic.Save(entity.Feature);
        }

        public void Dispose() => db.Dispose();

        public List<ModelViewFeature> GetAll() => Convert(featLogic.GetAll());

        public ModelViewFeature GetById(int id) => new ModelViewFeature(featLogic.GetById(id));

        public bool Remove(int id) => featLogic.Remove(id);

        public bool Update(ModelViewFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return featLogic.Update(entity.Feature);
        }
        private List<ModelViewFeature> Convert(List<Feature> Features)
        {
            var viewFeatures = new List<ModelViewFeature>();
            int i = 1;
            foreach (var feat in Features)
            {
                var featModel = new ModelViewFeature(feat)
                {
                    SerialNumber = i++
                };
                viewFeatures.Add(featModel);
            }

            return viewFeatures;
        }
    }
}
