using DalContract;
using Entities;
using LogicContract;
using System;
using System.Collections.Generic;

namespace Logic
{
    internal class HaspKeyLogic : IHaspKeyLogic
    {
        private readonly IContractHaspKeyDAO haspKeyDAO;
        public HaspKeyLogic(IContractHaspKeyDAO haspKeyDAO)
        {
            this.haspKeyDAO = haspKeyDAO ?? throw new ArgumentNullException(nameof(haspKeyDAO));
        }
        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return haspKeyDAO.Remove(id);           
        }

        public bool Save(HaspKey entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);
                        
            int id;
            if (!haspKeyDAO.ContainsDB(entity))
                id = haspKeyDAO.Add(entity);
            else
                return false;

            return id > 0;
        }

        public bool Update(HaspKey entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            return !haspKeyDAO.ContainsDB(entity) ? haspKeyDAO.Update(entity) : false;
        }
        public List<HaspKey> GetByActive() => haspKeyDAO.GetByActive();
        public List<HaspKey> GetAll() => haspKeyDAO.GetAll();

        public List<HaspKey> GetAllInCompany(Client id) => haspKeyDAO.GetAllInCompany(id);
        public List<HaspKey> GetActiveInCompany(Client id) => haspKeyDAO.GetActiveInCompany(id);
        


        public HaspKey GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return haspKeyDAO.GetById(id);
        }

        public List<HaspKey> GetByPastDue(Client id) => haspKeyDAO.GetByPastDue(id);
        public List<HaspKey> GetByClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            return haspKeyDAO.GetByClient(client);
        }
       
        private void CheckArgument(HaspKey haspKey)
        {
            if (haspKey.InnerId < 0)
                throw new ArgumentException(nameof(haspKey.InnerId));
            if (string.IsNullOrWhiteSpace(haspKey.Number))
                throw new ArgumentException(nameof(haspKey.Number));
            if (!Enum.IsDefined(typeof(TypeKey), haspKey.TypeKey))
                throw new ArgumentException(nameof(haspKey.TypeKey));
        }
    }
}
