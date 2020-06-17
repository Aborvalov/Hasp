using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    public interface IClientLogic
    {
        Client Save(Client client);
        Client Update(Client client);
        Client GetById(int id);
        bool Remove(int id);
        List<Client> GetAll();       
        List<Client> GetByFeature(Feature feature);
        Client GetByNumberKey(int KeyInnerId);
    }
}
