using Entities;
using System.Collections.Generic;

namespace DalContract
{
    public interface IContractHaspKeyDAO  : IContractEntitesDAO<HaspKey>
    {
        List<HaspKey> GetByClient(Client client);
        List<HaspKey> GetByPastDue(Client Client);
        List<HaspKey> GetAllInCompany(Client Client);
        List<HaspKey> GetActiveInCompany(Client Client);
        List<HaspKey> GetByActive();
    }
}
