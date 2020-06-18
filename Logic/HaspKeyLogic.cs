using DalContract;
using Entities;
using LogicContract;
using System;
using System.Collections.Generic;

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
                throw new ArgumentException("Неверное значение.", nameof(id));

            try
            {
                return haspKeyDAO.Remove(id);
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Не удалсь удвлить HASP-ключ.", e);
            }
        }

        public bool Save(HaspKey haspKey)
        {
            if (haspKey == null)
                throw new ArgumentNullException(nameof(haspKey));

            CheckArgument(haspKey);

            int id;
            try
            {
                if (haspKeyDAO.ContainsDB(haspKey))
                    id = haspKeyDAO.Add(haspKey);
                else
                    return false;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            
            catch (Exception e)
            {
                throw new InvalidOperationException("Не удалсь создать HASP-ключ.", e);
            }

            return id > 0;
        }

        public bool Update(HaspKey haspKey)
        {
            if (haspKey == null)
                throw new ArgumentNullException(nameof(haspKey));

            CheckArgument(haspKey);

            try
            {
                if (haspKeyDAO.Update(haspKey))
                    return true;
                else throw new InvalidOperationException("Не удалсь обновить HASP-ключ.");
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            
            catch (Exception e)
            {
                throw new InvalidOperationException("Не удалсь обновить HASP-ключ.", e);
            }            
        }
        public List<HaspKey> GetByActive() => haspKeyDAO.GetByActive();
        public List<HaspKey> GetAll() => haspKeyDAO.GetAll();
        
        public HaspKey GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            HaspKey haspKey = haspKeyDAO.GetById(id);
            if (haspKey == null)
                throw new NullReferenceException("Объект не найден в базе, " + nameof(haspKey));

            return haspKey;
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
                throw new ArgumentException("Неправильный внутренний номер ключа.", nameof(haspKey.InnerId));
            if (string.IsNullOrWhiteSpace(haspKey.Number))
                throw new ArgumentException("Неправильный номер ключа.", nameof(haspKey.Number));
            if (!Enum.IsDefined(typeof(TypeKey), haspKey.TypeKey))
                throw new ArgumentException("Неправильный тип ключа.", nameof(haspKey.TypeKey));
        }
    }
}
