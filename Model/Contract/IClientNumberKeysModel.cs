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
        //List<ModelViewClientNumberKeys> GetAll();
        
        
        List<ModelViewClientNumberKeys> NumberKeys();
        
        
        
        bool Update(IEnumerable<ModelViewClientNumberKeys> keyClient, out string error);
        bool Remove(IEnumerable<int> idKeyClient, out string error);
        bool Remove(int id);
        bool Update(ModelViewClientNumberKeys entity);
    }
}
