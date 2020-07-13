using ModelEntities;
using System;
using System.Collections.Generic;

namespace Presenter
{
    public interface IPresenterKeyFeature : IDisposable
    {        
        void DisplayHaspKey();
        void DisplayFeatureAtKey(int idKey);
        void Edit(List<ModelViewFeatureForEditKeyFeat> keyFeatModel);
        bool CheckInputData(List<ModelViewFeatureForEditKeyFeat> item);
        bool CheckInputData(ModelViewFeatureForEditKeyFeat item, int numverRow);
    }
}
