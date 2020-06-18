using Entities;
using System.Collections.Generic;

namespace DalContract
{
    public interface IContractClientDAO : IContractEntitesDAO<Client>
    {
        Client GetByNumberKey(int keyInnerId);
        List<Client> GetByFeature(Feature feature);
    }
}
