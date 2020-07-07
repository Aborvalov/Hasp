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
        private readonly IEntitiesView<ModelViewFeature> entitiesView;

        private const string errorAdd = "Не удалось создать функциональность.";
        private const string errorUpdate = "Не удалось обновить функциональность.";
        private const string errorDelete = "Не удалось удалить функциональность.";

        public PresenterFeature(IEntitiesView<ModelViewFeature> entitesView)
        {
            this.entitiesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            featureModel = new FeatureModel(new Logics());
            Display();
        }

        public ModelViewFeature Entities { get; set; } = null;

        public void Add(ModelViewFeature entity)
        {
            if (entity == null)
            {
                entitiesView.MessageError(errorAdd);
                return;
            }

            if (featureModel.Add(entity))
                Display();
            else
                entitiesView.MessageError(errorAdd);
        }

        public void Remove(int id)
        {
            if (id > 0 && featureModel.Remove(id))
                Display();
            else
                entitiesView.MessageError(errorDelete);
        }

        public void Update(ModelViewFeature entity)
        {
            if (entity == null)
            {
                entitiesView.MessageError(errorUpdate);
                return;
            }

            if (featureModel.Update(entity))
                Display();
            else
                entitiesView.MessageError(errorUpdate);
        }

        public void Display() => entitiesView.Bind(featureModel.GetAll());

        public void Dispose() => featureModel.Dispose();
    }
}
