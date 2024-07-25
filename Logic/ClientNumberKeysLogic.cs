using DalContract;
using DalDB;
using Entities;
using LogicContract;
using System;
using System.Collections.Generic;

namespace Logic
{
    internal class ClientNumberKeysLogic : IClientNumberKeysLogic
    {
        private readonly IContractClientNumberKeysDAO clientNumberKeysDAO;
        public ClientNumberKeysLogic(IContractClientNumberKeysDAO clientNumberKeysDAO)
        {
            this.clientNumberKeysDAO = clientNumberKeysDAO ?? throw new ArgumentNullException(nameof(clientNumberKeysDAO));
        }
        public List<ClientNumberKeys> GetAll() => clientNumberKeysDAO.GetAll();

        public ClientNumberKeys GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return clientNumberKeysDAO.GetById(id);
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return clientNumberKeysDAO.Remove(id);
        }

        public bool Save(ClientNumberKeys entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            int id;
            if (!clientNumberKeysDAO.ContainsDB(entity))
                id = clientNumberKeysDAO.Add(entity);
            else
                return false;

            return id > 0;
        }

        public bool Update(ClientNumberKeys entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            return !clientNumberKeysDAO.ContainsDB(entity) && clientNumberKeysDAO.Update(entity);
        }
        private void CheckArgument(ClientNumberKeys entity)
        {
            if (entity.Id < 1)
                throw new ArgumentException(nameof(entity.Id));
            if (string.IsNullOrWhiteSpace(entity.Name))
                throw new ArgumentException(nameof(entity.Name));
        }
    }
}
