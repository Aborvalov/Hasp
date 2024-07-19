using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public class HaspKeyModel : IHaspKeyModel
    {
        private readonly IEntitesContext db;
        private readonly IHaspKeyLogic keyLogic;

        public HaspKeyModel(IFactoryLogic factoryLogic)
        {
            if (factoryLogic == null)
                throw new ArgumentNullException(nameof(factoryLogic));

            db = Context.GetContext(); if (db == null)
                throw new ArgumentNullException(nameof(db));

            keyLogic = factoryLogic.CreateHaspKey(db);
        }
        public bool Add(ModelViewHaspKey entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return keyLogic.Save(entity.HaspKey);
        }

        public void Dispose() => db.Dispose();

        public List<ModelViewHaspKey> GetAll() => Convert(keyLogic.GetAll());

        public List<ModelViewHaspKey> GetByActive() 
            => Convert(keyLogic.GetByActive());

        public List<ModelViewHaspKey> GetByClient(ModelViewClient client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
                        
            return Convert(keyLogic.GetByClient(client.Client));
        }

        public ModelViewHaspKey GetById(int id) 
            => new ModelViewHaspKey(keyLogic.GetById(id));

        public List<ModelViewHaspKey> GetByPastDue(ModelViewClient client) => Convert(keyLogic.GetByPastDue(client.Client));
        public List<ModelViewHaspKey> GetAllInCompany(ModelViewClient client) => Convert(keyLogic.GetAllInCompany(client.Client));
        public List<ModelViewHaspKey> GetActiveInCompany(ModelViewClient client) => Convert(keyLogic.GetActiveInCompany(client.Client));



        public bool Remove(int id) => keyLogic.Remove(id);

        public bool Update(ModelViewHaspKey entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
                       
            return keyLogic.Update(entity.HaspKey);
        }

        private List<ModelViewHaspKey> Convert(List<HaspKey> haspKeys)
        {
            var viewHaspKeys = new List<ModelViewHaspKey>();
            foreach (var key in haspKeys)
                viewHaspKeys.Add(new ModelViewHaspKey(key));

            return viewHaspKeys;
        }
    }
}
