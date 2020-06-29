using Logic;
using Model;
using ModelEntities;
using System;
using System.Collections.Generic;
using View;

namespace Presenter
{
    public class PresenterHaspKey : IPresenterHaspKey
    {
        private readonly IHaspKeyModel haspKeyModel;
        private readonly IEntitesView<ModelViewHaspKey> entitesView;

        public PresenterHaspKey(IEntitesView<ModelViewHaspKey> entitesView)
        {
            this.entitesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            haspKeyModel = new HaspKeyModel(new Logics());
            View();
        }

        public bool Add(ModelViewHaspKey entity) => haspKeyModel.Add(entity);

        public void GetByActive() => this.entitesView.Build(haspKeyModel.GetByActive());
               
        public void GetByPastDue() => this.entitesView.Build(haspKeyModel.GetByPastDue());

        public bool Remove(int id) => haspKeyModel.Remove(id);

        public bool Update(ModelViewHaspKey entity) => haspKeyModel.Update(entity);

        public void View() => this.entitesView.Build(haspKeyModel.GetAll());
    }
}
