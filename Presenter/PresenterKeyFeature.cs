using Logic;
using Model;
using ModelEntities;
using System;
using View;

namespace Presenter
{
    public class PresenterKeyFeature : IPresenterEntities<ModelViewKeyFeature>
    {
        private readonly IEntitiesModel<ModelViewKeyFeature> keyFeatureModel;
        private readonly IEntitiesView<ModelViewKeyFeature> entitiesView;

        private const string errorAdd = "Не удалось создать связь ключа и функциональности.";
        private const string errorUpdate = "Не удалось обновить связь ключа и функциональности.";
        private const string errorDelete = "Не удалось удалить связь ключа и функциональности.";

        public PresenterKeyFeature(IEntitiesView<ModelViewKeyFeature> entitesView)
        {
            this.entitiesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            keyFeatureModel = new KeyFeatureModel(new Logics());
            Display();
        }

        public ModelViewKeyFeature Entities { get; set; } = null;

        public void Add(ModelViewKeyFeature entity)
        {
            if (entity == null)
                entitiesView.MessageError(errorAdd);

            if (keyFeatureModel.Add(entity))
                Display();
            else
                entitiesView.MessageError(errorAdd);
        }

        public void Remove(int id)
        {
            if (id > 0 && keyFeatureModel.Remove(id))
                Display();
            else
                this.entitiesView.MessageError(errorDelete);
        }

        public void Update(ModelViewKeyFeature entity)
        {
            if (entity == null)
                entitiesView.MessageError(errorUpdate);

            if (keyFeatureModel.Update(entity))
                Display();
            else
                entitiesView.MessageError(errorUpdate);
        }

        public void Display() => entitiesView.Bind(keyFeatureModel.GetAll());

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
