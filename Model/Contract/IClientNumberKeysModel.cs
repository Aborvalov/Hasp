using Entities;
using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IClientNumberKeysModel : IDisposable
    {
        bool Add(IEnumerable<ModelViewClientNumberKeys> keyClient, out string error);
        bool Add(ModelViewClientNumberKeys entity);
        List<ModelViewClientNumberKeys> NumberKeys(); 
        bool Update(IEnumerable<ModelViewClientNumberKeys> keyClient, out string error);
        bool Remove(IEnumerable<ModelViewClientNumberKeys> idKeyClient, out string error);
        bool Remove(int id);
        bool Update(ModelViewClientNumberKeys entity);
        List<ModelViewClientNumberKeys> GetByFeature(ModelViewFeature feature);
        List<ModelViewClientNumberKeys> GetByInnerId(int id);
    }
}
