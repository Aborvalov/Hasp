using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    public interface IClientLogic
    {
        Client Save(string name, string address, string phone, string contactPerson);
        Client Update(int id, string name, string address, string phone, string contactPerson);
        Client GetById(int id);
        bool Remove(int id);
        List<Client> GetAll();
        Client GetByNumberKey(string numberKey);
        Client GetByFeature(Feature feature);
    }
}
