using Logic;
using Model;
using ModelEntities;
using System;
using View;
using System.Linq;

namespace Presenter
{
    public class PresenterKeyFeature : IPresenterEntities<ModelViewKeyFeature>
    {
        private readonly IEntitiesModel<ModelViewKeyFeature> keyFeatureModel;
        private readonly IEntitiesModel<ModelViewHaspKey> keyModel;
        private readonly IEntitiesModel<ModelViewFeature> featureModel;
        private readonly IKeyFeatureView entitiesView;

        private const string errorAdd = "Не удалось создать связь ключа и функциональности.";
        private const string errorUpdate = "Не удалось обновить связь ключа и функциональности.";
        private const string errorDelete = "Не удалось удалить связь ключа и функциональности.";
        private const string errorEmptyFeature = "\u2022 Не выбрана функциональность. \n";
        private const string errorEmptyHaspKey = "\u2022 Не выбран hasp ключ. \n";
        private const string errorDate = "\u2022 Дата окончания действия меньше даты начала действия. \n";
        private const string errorKeyFeature = "\u2022 Данный ключ имеет действующую выбранную функциональность. \n";

        public PresenterKeyFeature(IKeyFeatureView entitesView)
        {
            this.entitiesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            keyFeatureModel = new KeyFeatureModel(new Logics());
            keyModel = new HaspKeyModel(new Logics());
            featureModel = new FeatureModel(new Logics());

            Display();
        }

        public ModelViewKeyFeature Entities { get; set; } = null;

        public void Add(ModelViewKeyFeature entity)
        {
            if (entity == null)
            {
                entitiesView.MessageError(errorAdd);
                return;
            }

            if (keyFeatureModel.Add(entity))
            {
                entitiesView.DataChange();
                Display();
            }
            else
                entitiesView.MessageError(errorAdd);
        }

        public void Remove(int id)
        {
            if (id > 0 && keyFeatureModel.Remove(id))
            {
                entitiesView.DataChange();
                Display();
            }
            else
                this.entitiesView.MessageError(errorDelete);
        }

        public void Update(ModelViewKeyFeature entity)
        {
            if (entity == null)
            {
                entitiesView.MessageError(errorUpdate);
                return;
            }

            if (keyFeatureModel.Update(entity))
            {
                entitiesView.DataChange();
                Display();
            }
            else
                entitiesView.MessageError(errorUpdate);
        }

        public void Display()
            => entitiesView.Bind(keyFeatureModel.GetAll().OrderBy(x => x.IdHaspKey).ToList());

        public void Dispose()
        {
            keyFeatureModel.Dispose();
            keyModel.Dispose();
            featureModel.Dispose();
        }

        public void FillInputItem(ModelViewKeyFeature row)
        {            
            Entities = new ModelViewKeyFeature
            {
                Id = row.Id,
                IdFeature = row.IdFeature,
                IdHaspKey = row.IdHaspKey
            };
            
            //entitiesView.StartDate = row.StartDate;
            //entitiesView.EndDate = row.EndDate;
            //entitiesView.HaspKey = keyModel.GetById(row.IdHaspKey);
            //entitiesView.Feature = featureModel.GetById(row.IdFeature);            
        }

        public void FillModel(ModelViewKeyFeature item)
        {
            if (!CheckInputData())
                return;

            //Entities.StartDate = entitiesView.StartDate;
            //Entities.EndDate = entitiesView.EndDate;
            //Entities.IdFeature = entitiesView.Feature.Id;
            //Entities.IdHaspKey = entitiesView.HaspKey.Id;

            if (Entities.Id < 1)
                Add(Entities);
            else
                Update(Entities);
        }
        private bool CheckInputData()
        {
            string errorMess = string.Empty;

            //if(entitiesView.Feature == null)
            //    errorMess += errorEmptyFeature;
            //if (entitiesView.HaspKey == null)
            //    errorMess += errorEmptyHaspKey;
            //if (entitiesView.StartDate > entitiesView.EndDate)
            //    errorMess += errorDate;

            //foreach (var row in keyFeatureModel.GetAll())
            //{                
            //    if (row.Id != Entities.Id &&
            //        row.IdHaspKey == entitiesView.HaspKey.Id &&
            //        row.IdFeature == entitiesView.Feature.Id &&
            //        row.EndDate >= entitiesView.StartDate)
            //    {
            //        errorMess += errorKeyFeature;
            //        break;
            //    }
            //}

            if (errorMess != string.Empty)
            {
                entitiesView.MessageError(errorMess.Trim());
                return false;
            }

            return true;
        }
    }
}
