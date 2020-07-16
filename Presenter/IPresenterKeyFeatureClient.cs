using ModelEntities;
using System;
using System.Collections.Generic;

namespace Presenter
{
    public interface IPresenterKeyFeatureClient : IDisposable
    {
        void DisplayClient();
        void DisplayHaspKeyAtClient(int idClient);
        void Edit(List<ModelViewKeyFeatureClient> keyClient);
        bool CheckInputData(List<ModelViewKeyFeatureClient> item);
        bool CheckInputData(ModelViewKeyFeatureClient item, int numverRow);
    }
}
