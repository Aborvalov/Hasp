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
        private readonly IFactoryLogic logic;
        private IHaspKeyLogic keyLogic;

        public HaspKeyModel(IFactoryLogic factoryLogic)
        {
            logic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));
        }
        public bool Add(ModelViewHaspKey entity)
        {
            using (var db = new EntitesContext())
            {
                keyLogic = logic.CreateHaspKey(db);
                return keyLogic.Save(entity);
            }
        }

        public List<ModelViewHaspKey> GetAll()
        {
            List<HaspKey> haspKeys;            
            using (var db = new EntitesContext())
            {
                keyLogic = logic.CreateHaspKey(db);
                haspKeys = keyLogic.GetAll();
            }
            return Convert(haspKeys);
        }

        public List<ModelViewHaspKey> GetByActive()
        {
            List<HaspKey> haspKeys;            
            using (var db = new EntitesContext())
            {
                keyLogic = logic.CreateHaspKey(db);
                haspKeys = keyLogic.GetByActive();
            }

            return Convert(haspKeys);
        }

        public List<ModelViewHaspKey> GetByClient(Client client)
        {
            List<HaspKey> haspKeys;
            using (var db = new EntitesContext())
            {
                keyLogic = logic.CreateHaspKey(db);
                haspKeys = keyLogic.GetByClient(client);
            }

            return Convert(haspKeys);
        }

        public ModelViewHaspKey GetById(int id)
        {
            HaspKey haspKeys;
            using (var db = new EntitesContext())
            {
                keyLogic = logic.CreateHaspKey(db);
                haspKeys = keyLogic.GetById(id);
            }
            
            return new ModelViewHaspKey(haspKeys);
        }

        public List<ModelViewHaspKey> GetByPastDue()
        {
            List<HaspKey> haspKeys;
            using (var db = new EntitesContext())
            {
                keyLogic = logic.CreateHaspKey(db);
                haspKeys = keyLogic.GetByPastDue();
            }

            return Convert(haspKeys);
        }

        public bool Remove(int id)
        {
            using (var db = new EntitesContext())
            {
                keyLogic = logic.CreateHaspKey(db);
                return keyLogic.Remove(id);
            }
        }

        public bool Update(ModelViewHaspKey entity)
        {
            using (var db = new EntitesContext())
            {
                keyLogic = logic.CreateHaspKey(db);
                return keyLogic.Update(entity);
            }
        }

        private List<ModelViewHaspKey> Convert(List<HaspKey> haspKeys)
        {
            var viewHaspKeys = new List<ModelViewHaspKey>();
            int i = 1;
            foreach (var key in haspKeys)
            {
                var keyModel = new ModelViewHaspKey(key);
                keyModel.SerialNumber = i++;
                viewHaspKeys.Add(keyModel);
            }

            return viewHaspKeys;
        }
    }
}
