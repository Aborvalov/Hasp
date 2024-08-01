using Model;
using ModelEntities;
using System;
using System.Collections.Generic;
using ViewContract;

namespace Presenter
{
    public interface IClientNumberKeysPresenter: IEntitiesPresenter<ModelViewClientNumberKeys>
    {
        bool CheckInputData(List<ModelViewClientNumberKeys> item);   
        void Edit(List<ModelViewClientNumberKeys> item);
        void GetByFeature(int id);
        void GetByInnerId(int id);
    }
}
