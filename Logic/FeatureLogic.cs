using DalContract;
using Entities;
using LogicContract;
using System;
using System.Collections.Generic;

namespace Logic
{
    internal class FeatureLogic : IFeatureLogic
    {
        private readonly IContractFeatureDAO featureDAO;
        public FeatureLogic(IContractFeatureDAO featureDAO)
        {
            this.featureDAO = featureDAO ?? throw new ArgumentNullException(nameof(featureDAO));
        }
        public List<Feature> GetAll() => featureDAO.GetAll();

        public Feature GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return featureDAO.GetById(id);
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return featureDAO.Remove(id);
        }

        public bool Save(Feature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            int id;
            if (!featureDAO.ContainsDB(entity))
                id = featureDAO.Add(entity);
            else
                return false;

            return id > 0;
        }

        public bool Update(Feature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            return !featureDAO.ContainsDB(entity) ? featureDAO.Update(entity) : false;
        }

            private void CheckArgument(Feature feature)
        {
            if (string.IsNullOrWhiteSpace(feature.Name))
                throw new ArgumentException(nameof(feature.Name));
            if (feature.Number < 1)
                throw new ArgumentException(nameof(feature.Number));
        }
    }
}
