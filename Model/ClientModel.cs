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
        private IClientLogic clientLogic;
        private readonly IEntitesContext db;
        public ClientModel(IFactoryLogic factoryLogic)
        {
            if (factoryLogic == null)
                throw new ArgumentNullException(nameof(factoryLogic));

            db = Context.GetContext();
            if (db == null)
                throw new ArgumentNullException(nameof(db));

            clientLogic = factoryLogic.CreateClient(db);
        }

        public bool Add(ModelViewClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return clientLogic.Save(entity.Client);
        }

        public void Dispose() => db.Dispose();

        public List<ModelViewClient> GetAll() => Convert(clientLogic.GetAll());
        
        public List<ModelViewClient> GetByFeature(ModelViewFeature feature)
        {
            var tmp = feature;
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));
                        
            return Convert(clientLogic.GetByFeature(feature.Feature));
        }

        public ModelViewClient GetById(int id) => 
            new ModelViewClient(clientLogic.GetById(id));

        public ModelViewClient GetByNumberKey(int keyInnerId)
        {
            Client client = clientLogic.GetByNumberKey(keyInnerId);

            if (client == null)
                return null;
            return new ModelViewClient(client);
        }

        public bool Remove(int id) => clientLogic.Remove(id);

        public bool Update(ModelViewClient entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return clientLogic.Update(entity.Client);
        }
        private List<ModelViewClient> Convert(List<Client> clients)
        {
            var viewClients = new List<ModelViewClient>();           
            foreach (var cl in clients)
                viewClients.Add(new ModelViewClient(cl));
            return viewClients;
        }
    }
}
