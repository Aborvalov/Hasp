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
        private readonly EntitesContext db;
        private IHaspKeyLogic keyLogic;

        public HaspKeyModel(IFactoryLogic factoryLogic)
        {
            if (factoryLogic == null)
                throw new ArgumentNullException(nameof(factoryLogic));

            db = new EntitesContext();
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
        
        public List<ModelViewHaspKey> GetByPastDue() => Convert(keyLogic.GetByPastDue());

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
            int i = 1;
            foreach (var key in haspKeys)
            {
                var keyModel = new ModelViewHaspKey(key)
                {
                    SerialNumber = i++
                };
                viewHaspKeys.Add(keyModel);
            }

            return viewHaspKeys;
        }
    }
}
