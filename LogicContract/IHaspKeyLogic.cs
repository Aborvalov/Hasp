using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    public interface IHaspKeyLogic : IEntitesLogic<HaspKey>
    {
        List<HaspKey> GetByClient(Client client);
        List<HaspKey> GetByPastDue(Client client);
        List<HaspKey> GetAllInCompany(Client client);
        List<HaspKey> GetActiveInCompany(Client client);
        List<HaspKey> GetByActive();
    }
}
