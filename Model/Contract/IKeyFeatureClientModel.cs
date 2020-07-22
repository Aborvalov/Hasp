using Entities;
using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IKeyFeatureClientModel : IDisposable
    {
        List<KeyFeatureClient> GetAllKeyClient();
        List<ModelViewKeyFeatureClient> GetAllAtClient(int idClient);
        bool Remove(IEnumerable<int> idKeyClient, out string error);
        bool Add(IEnumerable<ModelViewKeyFeatureClient> keyClient, out string error);
        bool Update(IEnumerable<ModelViewKeyFeatureClient> keyClient, out string error);
    }
}
