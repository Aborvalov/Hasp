using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    interface IHaspKeyLogic
    {
        HaspKey Save(string number, TypeKey type, Feature feature, Client client, string other);
        HaspKey GetById(int id);
        List<HaspKey> GetAll();
        bool Remove(int id);
        HaspKey Update(int id, string number, TypeKey type, Feature feature, Client client, string other);
        List<HaspKey> GetByCompany(Client client);
        List<HaspKey> GetByPastDue();
        List<HaspKey> GaetByActive();
    }
}
