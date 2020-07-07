using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public class ClientModel : IClientModel
    {
        private readonly IFactoryLogic logic;
        private IClientLogic clientLogic;
        public ClientModel(IFactoryLogic factoryLogic)
        {
            logic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));
        }
        public bool Add(ModelViewClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            using (var db = new EntitesContext())
            {
                clientLogic = logic.CreateClient(db);
                return clientLogic.Save(entity.Client);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<ModelViewClient> GetAll()
        {
            List<Client> clients;
            using (var db = new EntitesContext())
            {
                clientLogic = logic.CreateClient(db);
                clients = clientLogic.GetAll();
            }
            return Convert(clients);
        }
        
        public List<ModelViewClient> GetByFeature(ModelViewFeature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            List<Client> clients;
            using (var db = new EntitesContext())
            {
                clientLogic = logic.CreateClient(db);
                clients = clientLogic.GetByFeature(feature.Feature);
            }
            return Convert(clients);
        }

        public ModelViewClient GetById(int id)
        {
            Client client;
            using (var db = new EntitesContext())
            {
                clientLogic = logic.CreateClient(db);
                client = clientLogic.GetById(id);
            }
            return new ModelViewClient(client);
        }

        public ModelViewClient GetByNumberKey(int keyInnerId)
        {
            Client client;
            using (var db = new EntitesContext())
            {
                clientLogic = logic.CreateClient(db);
                client = clientLogic.GetByNumberKey(keyInnerId);
            }
            if (client == null)
                return null;
            return new ModelViewClient(client)
                       { SerialNumber = 1};
        }

        public bool Remove(int id)
        {
            using (var db = new EntitesContext())
            {
                clientLogic = logic.CreateClient(db);
                return clientLogic.Remove(id);
            }
        }

        public bool Update(ModelViewClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            using (var db = new EntitesContext())
            {
                clientLogic = logic.CreateClient(db);
                return clientLogic.Update(entity.Client);
            }
        }
        private List<ModelViewClient> Convert(List<Client> clients)
        {
            var viewClients = new List<ModelViewClient>();
            int i = 1;
            foreach (var cl in clients)
            {
                var clintModel = new ModelViewClient(cl)
                {
                    SerialNumber = i++
                };
                viewClients.Add(clintModel);
            }
            return viewClients;
        }
    }
}
