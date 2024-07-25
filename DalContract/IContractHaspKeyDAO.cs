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
        List<HaspKey> GetByPastDue(Client сlient);
        List<HaspKey> GetAllInCompany(Client сlient);
        List<HaspKey> GetActiveInCompany(Client сlient);
        
        /// <summary>
        /// Поиск действующих ключей.
        /// </summary>
        /// <returns>Список действующих ключей.</returns>
        List<HaspKey> GetByActive();
    }
}
