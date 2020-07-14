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

        public PresenterKeyFeature(IKeyFeatureView entitesView)
        {
            this.entitiesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            keyModel = new HaspKeyModel(new Logics());
            featureModel = new KeyFeatureModel(new Logics());
            keyFeatures = featureModel.GetAllKeyFeature();
            
            DisplayHaspKey();
        }

        public void DisplayHaspKey() => entitiesView.BindKey(keyModel.GetAll());
        public void DisplayFeatureAtKey(int idKey)
        {
            entitiesView.NumberHaspKey = keyModel.GetById(idKey).InnerId.ToString();
            entitiesView.BindFeature(featureModel.GetAll(idKey));            
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
                       
            string error = string.Empty;
            var delete = keyFeatModel
                        .Where(x => x.IdKeyFeaure != 0 && !x.Selected)
                        .Select(item => item.IdKeyFeaure);

            var add = keyFeatModel
                     .Where(x => x.IdKeyFeaure == 0 && 
                                 x.Selected &&
                                 x.StartDate != null &&
                                 x.EndDate != null)
                     .ToList();

            var update = keyFeatModel
                        .Where(x => x.IdKeyFeaure != 0 && 
                                    x.StartDate != null &&
                                    x.EndDate != null &&
                                    x.Selected)
                        .ToList();
                       
            if (delete.Any())
            {
                featureModel.Remove(delete, out error);
                if (error != string.Empty)
                    entitiesView.MessageError(error);
            }
            
            if (add.Any())
            {
                error = string.Empty;
                featureModel.Add(add, out error);
                if (error != string.Empty)
                    entitiesView.MessageError(error);
            }

            if (update.Any())
            {
                error = string.Empty;
                featureModel.Update(update, out error);
                if (error != string.Empty)
                    entitiesView.MessageError(error);
            }

            DisplayFeatureAtKey(keyFeatModel[0].IdKey);
            keyFeatures = featureModel.GetAllKeyFeature();
            entitiesView.EmptyFeatureAsKey();
            entitiesView.DataChange();
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
                (item.Selected || item.IdKeyFeaure == 0))
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

            return item.IdKeyFeaure == 0 &&
                   item.StartDate != null &&
                   item.EndDate != null &&
                   item.StartDate.Value.Date < item.EndDate.Value.Date;
        }
    }
}
