using Entities;
using Logic;
using Model;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using View;

namespace Presenter
{
    public class PresenterKeyFeature : IPresenterKeyFeature
    {
        private readonly IEntitiesModel<ModelViewHaspKey> keyModel;
        private readonly IKeyFeatureModel featureModel;
        private readonly IKeyFeatureView entitiesView;
        private List<KeyFeature> keyFeatures;

        public PresenterKeyFeature(IKeyFeatureView entitiesView)
        {
            this.entitiesView = entitiesView ?? throw new ArgumentNullException(nameof(entitiesView));

            keyModel = new HaspKeyModel(new Logics());
            featureModel = new KeyFeatureModel(new Logics());
            keyFeatures = featureModel.GetAllKeyFeature();
            
            DisplayHaspKey();
        }

        public void DisplayHaspKey() => entitiesView.BindKey(keyModel.GetAll());
        public void DisplayFeatureAtKey(int idKey)
        {
            entitiesView.NumberHaspKey = keyModel.GetById(idKey).InnerId.ToString();
            entitiesView.BindFeature(featureModel.GetAllFeatureAtKey(idKey));            
        }
        public void Dispose()
        {
            keyModel.Dispose();
            featureModel.Dispose();            
        }       
        public void Edit(List<ModelViewKeyFeature> keyFeatModel)
        {
            if (keyFeatModel == null)
                throw new ArgumentNullException(nameof(keyFeatModel));
                       
            Delete(keyFeatModel);
            Add(keyFeatModel);
            Update(keyFeatModel);

            DisplayFeatureAtKey(keyFeatModel[0].IdKey);
            keyFeatures = featureModel.GetAllKeyFeature();
            entitiesView.EmptyFeatureAsKey();
            entitiesView.DataChange();
        }

        private void Update(List<ModelViewKeyFeature> keyFeatModel)
        {
            var update = keyFeatModel
                            .Where(x => x.IdKeyFeature != 0 &&
                                        x.StartDate != null &&
                                        x.EndDate != null &&
                                        x.Selected);
            if (update.Any())
            {
                featureModel.Update(update, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesView.MessageError(error);
            }
        }

        private void Add(List<ModelViewKeyFeature> keyFeatModel)
        {
            var add = keyFeatModel
                        .Where(x => x.IdKeyFeature == 0 &&
                                    x.Selected &&
                                    x.StartDate != null &&
                                    x.EndDate != null);
            if (add.Any())
            {
                featureModel.Add(add, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesView.MessageError(error);
            }
        }

        private void Delete(List<ModelViewKeyFeature> keyFeatModel)
        {
            var delete = keyFeatModel
                                    .Where(x => x.IdKeyFeature != 0 && !x.Selected)
                                    .Select(item => item.IdKeyFeature);

            if (delete.Any())
            {
                featureModel.Remove(delete, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesView.MessageError(error);
            }
        }

        public bool CheckInputData(List<ModelViewKeyFeature> item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            int numverRow = 0;
            bool error = true;
            foreach (var i in item)
            {
                error &= CheckInputData(i, numverRow);
                numverRow++;
            }

            return error;
        }
        public bool CheckInputData(ModelViewKeyFeature item, int numverRow)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (item.StartDate != null &&
                item.EndDate != null &&
                item.StartDate.Value.Date > item.EndDate.Value.Date &&
                (item.Selected || item.IdKeyFeature == 0))
            {
                entitiesView.ErrorRow(numverRow);
                return false;
            }

            return true;
        }
        public bool CheckKey(ModelViewHaspKey item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return keyFeatures
                    .LastOrDefault(x => x.IdHaspKey == item.Id &&
                                        x.EndDate >= DateTime.Now.Date) == null;
        }

        public bool CheckSelected(ModelViewKeyFeature item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return item.IdKeyFeature == 0 &&
                   item.StartDate != null &&
                   item.EndDate != null &&
                   item.StartDate.Value.Date < item.EndDate.Value.Date;
        }
    }
}
