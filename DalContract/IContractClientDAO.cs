using Entities;
using System.Collections.Generic;

namespace DalContract
{
    public interface IContractClientDAO : IContractEntitesDAO<Client>
    {
        Client GetByNumberKey(int KeyInnerId);
        List<Client> GetByFeature(Feature feature);
    }
}
