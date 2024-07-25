using Logic;
using Model;
using ModelEntities;
using System;
using ViewContract;

namespace Presenter
{
    public class FeaturePresenter : IEntitiesPresenter<ModelViewFeature>
    {
        private readonly IEntitiesModel<ModelViewFeature> featureModel;
        private readonly IEntitiesView<ModelViewFeature> entitiesView;

        private const string errorAdd = "Не удалось создать функциональность.";
        private const string errorUpdate = "Не удалось обновить функциональность.";
        private const string errorDelete = "Не удалось удалить функциональность.";
        private const string errorNumber = "\u2022 Неверное значение номера, должно быть числом. \n";
        private const string erroremptyName = "\u2022 Не заполнено поля \"Наименование\", не должно быть пустым. \n";
        private const string nullDB = "База данных не найдена.";

        public FeaturePresenter(IEntitiesView<ModelViewFeature> entitesView)
        {
            this.entitiesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            try
            {
                featureModel = new FeatureModel(new Logics());
            }
            catch (ArgumentNullException)
            {
                entitiesView.MessageError(nullDB);
            }
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
            {
                entitiesView.DataChange();
                Display();
            }
            else
                entitiesView.MessageError(errorAdd);
        }

        public void Remove(int id)
        {
            if (id > 0 && featureModel.Remove(id))
            {
                entitiesView.DataChange();
                Display();
            }
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
            {
                entitiesView.DataChange();
                Display();
            }
            else
                entitiesView.MessageError(errorUpdate);
        }

        public void Display() => entitiesView.Bind(featureModel.GetAll());

        public void Dispose() => featureModel.Dispose();
       
        public void FillModel(ModelViewFeature item)
        {
            Entities = item ?? throw new ArgumentNullException(nameof(item));
            if (!CheckInputData())
                return;

            if (Entities.Id < 1)
                Add(Entities);
            else
                Update(Entities);
        }
       
         private bool CheckInputData()
        {
            string errorMess = string.Empty;
                                  
            if (string.IsNullOrWhiteSpace(Entities.Name))
                errorMess += erroremptyName;

            if (errorMess != string.Empty)
            {
                entitiesView.MessageError(errorMess.Trim());
                return false;
            }

            return true;
        }
       
        public void FillInputItem(ModelViewFeature item)
        {            
            Entities = item ?? throw new ArgumentNullException(nameof(item));
            entitiesView.BindItem(item);
        }
    }
}
