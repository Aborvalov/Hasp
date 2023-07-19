using ModelEntities;
using System;
using System.Collections.Generic;

namespace Presenter
{
    public interface IKeyFeatureClientPresenter : IDisposable
    {
        void DisplayClient();
        void DisplayHaspKeyAtClient(int idClient);
        void Edit(List<ModelViewKeyFeatureClient> keyClient);
        bool CheckInputData(List<ModelViewKeyFeatureClient> item);
        bool CheckInputData(ModelViewKeyFeatureClient item, int numverRow);
        bool CheckSelected(ModelViewKeyFeatureClient item);
    }
}
