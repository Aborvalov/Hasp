using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IFeatureFor__Model : IDisposable
    {
        List<ModelViewFeatureForEditKeyFeat> GetAll();
        List<ModelViewFeatureForEditKeyFeat> GetAll(int idKey);

        bool Remove(IEnumerable<int> idFeatureKey, out string error);
        bool Add(List<ModelViewFeatureForEditKeyFeat> keyFeat, out string error);
        bool Update(List<ModelViewFeatureForEditKeyFeat> keyFeat, out string error);
    }
}
