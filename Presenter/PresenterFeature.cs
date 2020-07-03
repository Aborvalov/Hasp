using Logic;
using Model;
using ModelEntities;
using System;
using View;

namespace Presenter
{
    public class PresenterFeature : IPresenterEntities<ModelViewFeature>
    {
        private readonly IEntitiesModel<ModelViewFeature> featureModel;
        private readonly IEntitiesView<ModelViewFeature> entitesView;

        public PresenterFeature(IEntitiesView<ModelViewFeature> entitesView)
        {
            this.entitesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            featureModel = new FeatureModel(new Logics());
            View();
        }
        public void Add(ModelViewFeature entity)
        {
            if (entity == null)
              entitesView.MessageError("Не удалось создать Hasp-ключ.");

                if (featureModel.Add(entity))
                View();
            else
                entitesView.MessageError("Не удалось создать Hasp-ключ.");
        }

        public void Remove(int id)
        {
            if (id > 0 && featureModel.Remove(id))
                View();
            else
                entitesView.MessageError("Не удалось удалить Hasp-ключ.");
        }

        public void Update(ModelViewFeature entity)
        {
            if (entity == null)
                entitesView.MessageError("Не удалось обновить Hasp-ключ.");

            if (featureModel.Update(entity))
                View();
            else
                entitesView.MessageError("Не удалось обновить Hasp-ключ.");
        }

        public void View() => entitesView.Bind(featureModel.GetAll());
    }
}
