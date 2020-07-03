﻿using Logic;
using Model;
using ModelEntities;
using System;
using View;

namespace Presenter
{
    public class PresenterKeyFeature : IPresenterEntities<ModelViewKeyFeature>
    {
        private readonly IEntitiesModel<ModelViewKeyFeature> keyFeatureModel;
        private readonly IEntitiesView<ModelViewKeyFeature> entitesView;

        public PresenterKeyFeature(IEntitiesView<ModelViewKeyFeature> entitesView)
        {
            this.entitesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            keyFeatureModel = new KeyFeatureModel(new Logics());
            View();
        }
        public void Add(ModelViewKeyFeature entity)
        {
            if (entity == null)
                entitesView.MessageError("Не удалось создать связь ключа и функциональности.");

            if (keyFeatureModel.Add(entity))
                View();
            else
                entitesView.MessageError("Не удалось создать связь ключа и функциональности.");
        }

        public void Remove(int id)
        {
            if (id > 0 && keyFeatureModel.Remove(id))
                View();
            else
                this.entitesView.MessageError("Не удалось удалить связь ключа и функциональности.");
        }

        public void Update(ModelViewKeyFeature entity)
        {
            if (entity == null)
                entitesView.MessageError("Не удалось обновить связь ключа и функциональности.");

            if (keyFeatureModel.Update(entity))
                View();
            else
                entitesView.MessageError("Не удалось обновить связь ключа и функциональности.");
        }

        public void View() => entitesView.Bind(keyFeatureModel.GetAll());
    }
}
