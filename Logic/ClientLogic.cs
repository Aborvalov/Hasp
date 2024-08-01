using DalContract;
using Entities;
using LogicContract;
using System;
using System.Collections.Generic;

namespace Logic
{
    internal class ClientLogic : IClientLogic
    {
        private readonly IContractClientDAO clientDAO;
        public ClientLogic(IContractClientDAO clientDAO)
        {
            this.clientDAO = clientDAO ?? throw new ArgumentNullException(nameof(clientDAO));
        }
        public List<Client> GetAll() => clientDAO.GetAll();

        public List<Client> GetByFeature(Feature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            return clientDAO.GetByFeature(feature);
        }

        public Client GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return clientDAO.GetById(id);
        }

        public Client GetByNumberKey(int keyInnerId)
        {
            if (keyInnerId < 1)
                throw new ArgumentException(nameof(keyInnerId));

            return clientDAO.GetByNumberKey(keyInnerId);
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return clientDAO.Remove(id);
        }

        public bool Save(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            int id;
            if (!clientDAO.ContainsDB(entity))
                id = clientDAO.Add(entity);
            else
                return false;

           return id > 0;
        }

        public bool Update(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            return !clientDAO.ContainsDB(entity) && clientDAO.Update(entity);
        }

        private void CheckArgument(Client client)
        {
            if (string.IsNullOrWhiteSpace(client.Name))
                throw new ArgumentException(nameof(client.Name));
        }
    }
}
