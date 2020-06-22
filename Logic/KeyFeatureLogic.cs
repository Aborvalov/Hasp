using DalContract;
using Entities;
using LogicContract;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class KeyFeatureLogic : IKeyFeatureLogic
    {
        private readonly IContractKeyFeatureDAO keyFeatureDAO;
        private readonly DateTime date = DateTime.Now.Date;
        public KeyFeatureLogic(IContractKeyFeatureDAO keyFeatureDAO)
        {
            this.keyFeatureDAO = keyFeatureDAO ?? throw new ArgumentNullException(nameof(keyFeatureDAO));
        }
        public List<KeyFeature> GetAll() => keyFeatureDAO.GetAll();

        public KeyFeature GetById(int id)
        {
            if(id < 1)
                throw new ArgumentException(nameof(id));

            return keyFeatureDAO.GetById(id);
        }

        public bool Remove(int id)
        {
            if(id < 1)
                throw new ArgumentException(nameof(id));

            return keyFeatureDAO.Remove(id);
        }

        public bool Save(KeyFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            entity.StartDate = date;

            int id;
            if (!keyFeatureDAO.ContainsDB(entity))
                id = keyFeatureDAO.Add(entity);
            else
                return false;

            if (id < 1)
                throw new InvalidOperationException("Не удалсь создать связб ключ-фича.");
            else
                return true;
        }        
        public bool Update(KeyFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            return keyFeatureDAO.Update(entity);
        }
        private void CheckArgument(KeyFeature entity)
        {
            if (entity.IdHaspKey < 1)
                throw new ArgumentException(nameof(entity.IdHaspKey));
            if (entity.IdFeature < 1)
                throw new ArgumentException(nameof(entity.IdFeature));
            if (entity.EndDate < DateTime.Now.Date)
                throw new ArgumentException(nameof(entity.EndDate));
        }
    }
}
