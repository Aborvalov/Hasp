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
            HaspKey haspKey = new HaspKey
            {
                InnerId = entity.InnerId,
                Number  = entity.Number,
                TypeKey = entity.TypeKey,
                IsHome  = entity.IsHome,
            };

            using (var db = new EntitesContext())
            {
                keyLogic = logic.CreateHaspKey(db);                
                return keyLogic.Save(haspKey);
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

        public List<ModelViewHaspKey> GetByClient(ModelViewClient client)
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
            HaspKey haspKey;
            using (var db = new EntitesContext())
            {
                keyLogic = logic.CreateHaspKey(db);
                haspKey = keyLogic.GetById(id);
            }
            
            return new ModelViewHaspKey(haspKey);
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
            HaspKey haspKey = new HaspKey
            {
                Id      = entity.Id,
                InnerId = entity.InnerId,
                Number  = entity.Number,
                TypeKey = entity.TypeKey,
                IsHome  = entity.IsHome,
            };

            using (var db = new EntitesContext())
            {
                keyLogic = logic.CreateHaspKey(db);
                return keyLogic.Update(haspKey);
            }
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
