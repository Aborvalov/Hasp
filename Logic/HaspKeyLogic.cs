using DalContract;
using Entities;
using LogicContract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class HaspKeyLogic : IHaspKeyLogic
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

            if (id < 1)
                throw new InvalidOperationException("Не удалсь создать HASP-ключ.");
            else
                return true; ;
        }

        public bool Update(HaspKey entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            var duplicate = GetAll().Where(key => key.Id      != entity.Id &&
                                                  key.InnerId == entity.InnerId &&
                                                  key.Number  == entity.Number &&
                                                  key.TypeKey == entity.TypeKey &&
                                                  key.IsHome  == entity.IsHome);

            if (duplicate.Any())
                return false;

            return haspKeyDAO.Update(entity);                    
        }
        public List<HaspKey> GetByActive() => haspKeyDAO.GetByActive();
        public List<HaspKey> GetAll() => haspKeyDAO.GetAll();
        
        public HaspKey GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return haspKeyDAO.GetById(id);
        }

        public List<HaspKey> GetByPastDue() => haspKeyDAO.GetByPastDue();
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
