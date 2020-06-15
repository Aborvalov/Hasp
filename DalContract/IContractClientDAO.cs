using Entities;
using System.Collections.Generic;

namespace DalContract
{
    public interface IContractClientDAO : IContractEntites<Client>
    {
        Client GetByNumberKey(int KeyInnerId);
        IEnumerable<Client> GetByFeature(Feature feature);
    }
}
