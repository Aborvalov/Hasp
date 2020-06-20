using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    public interface IClientLogic : IEntitesLogic<Client>
    {
        List<Client> GetByFeature(Feature feature);
        Client GetByNumberKey(int keyInnerId);
    }
}
