using Entities;
using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IKeyFeatureModel : IDisposable
    {
        List<ModelViewKeyFeature> GetAllFeatureAtKey(int idKey);
        List<KeyFeature> GetAllKeyFeature();       
        bool Remove(IEnumerable<int> idkeyfeature, out string error);
        bool Add(IEnumerable<ModelViewKeyFeature> keyFeat, out string error);
        bool Update(IEnumerable<ModelViewKeyFeature> keyFeat, out string error);
    }
}
