﻿using ModelEntities;
using System;
using System.Collections.Generic;

namespace Presenter
{
    public interface IKeyFeaturePresenter : IDisposable
    {        
        void DisplayHaspKey();
        void DisplayFeatureAtKey(int idKey);
        void Edit(List<ModelViewKeyFeature> keyFeatModel);
        bool CheckInputData(List<ModelViewKeyFeature> item);
        bool CheckInputData(ModelViewKeyFeature item, int numverRow);
        bool CheckSelected(ModelViewKeyFeature item);       
        bool CheckKey(ModelViewHaspKey item);
        
    }
}
