using ModelEntities;
using System;
using System.Collections.Generic;

namespace Presenter
{
    public interface IPresenterKeyFeature : IDisposable
    {        
        void DisplayHaspKey();
        void DisplayFeatureAtKey(int idKey);
        void Edit(List<ModelViewFeatureForKeyFeat> keyFeatModel);
        bool CheckInputData(List<ModelViewFeatureForKeyFeat> item);
        bool CheckInputData(ModelViewFeatureForKeyFeat item, int numverRow);
        bool CheckKey(ModelViewHaspKey item);
    }
}
