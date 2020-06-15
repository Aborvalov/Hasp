using Entities;
using System.Collections.Generic;

namespace DalContract
{
    public interface IContractHaspKeyDAO : IContractEntitesDAO<HaspKey>
    {
        IEnumerable<HaspKey> GetByClient(Client client);
        /// <summary>
        /// Поиск просроченных ключей.
        /// </summary>
        /// <returns>Список просроченных ключей.</returns>
        IEnumerable<HaspKey> GetByPastDue();
        /// <summary>
        /// Поиск действующих ключей.
        /// </summary>
        /// <returns>Список действующих ключей.</returns>
        IEnumerable<HaspKey> GaetByActive();
    }
}
