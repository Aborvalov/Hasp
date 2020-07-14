using Entities;
using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IKeyFeatureModel : IDisposable
    {
        List<ModelViewKeyFeature> GetAll();
        List<ModelViewKeyFeature> GetAll(int idKey);
        List<KeyFeature> GetAllKeyFeature();
       
        bool Remove(IEnumerable<int> idFeatureKey, out string error);
        bool Add(List<ModelViewKeyFeature> keyFeat, out string error);
        bool Update(List<ModelViewKeyFeature> keyFeat, out string error);
    }
}
