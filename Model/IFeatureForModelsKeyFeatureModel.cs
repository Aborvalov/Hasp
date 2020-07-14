using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IFeatureForModelsKeyFeatureModel : IDisposable
    {
        List<ModelViewFeatureForKeyFeat> GetAll();
        List<ModelViewFeatureForKeyFeat> GetAll(int idKey);
        List<ModelViewKeyFeature> GetAllKeyFeature();
        ModelViewKeyFeature GetByIdKeyFeature(int id);

        bool Remove(IEnumerable<int> idFeatureKey, out string error);
        bool Add(List<ModelViewFeatureForKeyFeat> keyFeat, out string error);
        bool Update(List<ModelViewFeatureForKeyFeat> keyFeat, out string error);
    }
}
