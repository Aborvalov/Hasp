using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using LogicContract;
using DalContract;
using DalDB;

namespace Logic
{
    public class HaspKeyLogic : IHaspKeyLogic
    {
        private IContractHaspKeyDAO haspKeyDAO { get; }
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
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Не удалсь удвлить HASP-ключ.", e);
            }
        }

        public HaspKey Save(HaspKey haspKey)
        {
            if (haspKey == null)
                throw new ArgumentNullException(nameof(haspKey));

            CheckArgument(haspKey);

            int id;
            try
            {
                id = haspKeyDAO.Add(haspKey);
            }
            catch (ArgumentNullException e)
            {
                throw;
            }
            catch (DuplicateException e)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Не удалсь создать HASP-ключ.", e);
            }

            return GetById(id);
        }

        public HaspKey Update(HaspKey haspKey)
        {
            if (haspKey == null)
                throw new ArgumentNullException(nameof(haspKey));

            CheckArgument(haspKey);

            try
            {
                if (haspKeyDAO.Update(haspKey))
                    return haspKey;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Не удалсь обновить HASP-ключ.", e);
            }

            throw new InvalidOperationException("Не удалсь обновить HASP-ключ.");
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
