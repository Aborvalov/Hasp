using Entities;
using System.Collections.Generic;

namespace DalContract
{
    public interface IContractHaspKeyDAO  : IContractEntitesDAO<HaspKey>
    {
        List<HaspKey> GetByClient(Client client);
        /// <summary>
        /// Поиск просроченных ключей.
        /// </summary>
        /// <returns>Список просроченных ключей.</returns>
        List<HaspKey> GetByPastDue(Client id);
        List<HaspKey> GetAllInCompany(Client id);
        List<HaspKey> GetActiveInCompany(Client id);
        
        /// <summary>
        /// Поиск действующих ключей.
        /// </summary>
        /// <returns>Список действующих ключей.</returns>
        List<HaspKey> GetByActive();
        //List<HaspKey> GetAllInCompany(int id);
    }
}
