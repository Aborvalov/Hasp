using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    interface IHaspKeyLogic
    {
        HaspKey Save(HaspKey haspKey);
        HaspKey GetById(int id);
        List<HaspKey> GetAll();
        bool Remove(int id);
        HaspKey Update(HaspKey haspKey);
        List<HaspKey> GetByCompany(Client client);
        List<HaspKey> GetByPastDue();
        List<HaspKey> GaetByActive();
    }
}
