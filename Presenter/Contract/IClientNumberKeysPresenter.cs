using Model;
using ModelEntities;
using System;
using System.Collections.Generic;
using ViewContract;

namespace Presenter
{
    public interface IClientNumberKeysPresenter : IEntitiesPresenter<ModelViewClient>
    {
        bool CheckInputData(List<ModelViewClient> item);
        void Edit(List<ModelViewClient> item);
        void GetByFeature(int id);
        void GetByInnerId(int id);
    }
}
