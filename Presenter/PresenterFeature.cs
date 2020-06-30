using Logic;
using Model;
using ModelEntities;
using System;
using View;

namespace Presenter
{
    public class PresenterFeature : IPresenterEntites<ModelViewFeature>
    {
        private readonly IEntitesModel<ModelViewFeature> featureModel;
        private readonly IEntitesView<ModelViewFeature> entitesView;

        public PresenterFeature(IEntitesView<ModelViewFeature> entitesView)
        {
            this.entitesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            featureModel = new FeatureModel(new Logics());
            View();
        }
        public void Add(ModelViewFeature entity)
        {
            if (featureModel.Add(entity))
                View();
            else
                this.entitesView.MessageError("Не удалось создать Hasp-ключ.");
        }

        public void Remove(int id)
        {
            if (id > 0 && featureModel.Remove(id))
                View();
            else
                this.entitesView.MessageError("Не удалось удалить Hasp-ключ.");
        }

        public void Update(ModelViewFeature entity)
        {
            if (featureModel.Update(entity))
                View();
            else
                this.entitesView.MessageError("Не удалось обновить Hasp-ключ.");
        }

        public void View() => this.entitesView.Build(featureModel.GetAll());
    }
}
