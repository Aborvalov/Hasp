using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    public interface IHaspKeyLogic
    {
        bool Save(HaspKey haspKey);
        HaspKey GetById(int id);
        List<HaspKey> GetAll();
        bool Remove(int id);
        bool Update(HaspKey haspKey);       
        List<HaspKey> GetByClient(Client client);
        /// <summary>
        /// Поиск просроченных ключей.
        /// </summary>
        /// <returns>Список просроченных ключей.</returns>
        List<HaspKey> GetByPastDue();
        /// <summary>
        /// Поиск действующих ключей.
        /// </summary>
        /// <returns>Список действующих ключей.</returns>
        List<HaspKey> GetByActive();
    }
}
