using DalContract;
using Entities;
using LogicContract;
using System;
using System.Collections.Generic;

namespace Logic
{
    internal class KeyFeatureClientLogic : IKeyFeatureClientLogic
    {
        private readonly IContractKeyFeatureClientDAO keyFeatureClientDAO;
        public KeyFeatureClientLogic(IContractKeyFeatureClientDAO keyFeatureClientDAO)
        {
            this.keyFeatureClientDAO = keyFeatureClientDAO ?? throw new ArgumentNullException(nameof(keyFeatureClientDAO));
        }
        public List<KeyFeatureClient> GetAll() => keyFeatureClientDAO.GetAll();

        public KeyFeatureClient GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return keyFeatureClientDAO.GetById(id);
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return keyFeatureClientDAO.Remove(id);
        }

        public bool Save(KeyFeatureClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            int id;
            if (!keyFeatureClientDAO.ContainsDB(entity))
                id = keyFeatureClientDAO.Add(entity);
            else
                return false;

            return id > 0;
        }
        public bool Update(KeyFeatureClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            return !keyFeatureClientDAO.ContainsDB(entity) ? keyFeatureClientDAO.Update(entity) : false;
        }
        private void CheckArgument(KeyFeatureClient entity)
        {
            if (entity.IdClient < 1)
                throw new ArgumentException(nameof(entity.IdClient));
            if (entity.IdKeyFeature < 1)
                throw new ArgumentException(nameof(entity.IdKeyFeature));
            if(string.IsNullOrWhiteSpace(entity.Initiator))
                throw new ArgumentException(nameof(entity.Initiator));
        }
    }
}
