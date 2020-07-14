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
        private readonly IKeyFeatureModel keyFeatureModel;
        private readonly IEntitiesModel<ModelViewHaspKey> keyModel;
        private readonly IFeatureForModelsKeyFeatureModel featureModel;
        private readonly IKeyFeatureView entitiesView;
        private List<ModelViewKeyFeature> keyFeatures;

        public PresenterKeyFeature(IKeyFeatureView entitesView)
        {
            this.entitiesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            keyFeatureModel = new KeyFeatureModel(new Logics());
            keyModel = new HaspKeyModel(new Logics());
            featureModel = new FeatureForMpdelsKeyFeatureModel(new Logics());

            keyFeatures = keyFeatureModel.GetAll();
            
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
            keyFeatureModel.Dispose();
            keyModel.Dispose();
            featureModel.Dispose();            
        }       
        public void Edit(List<ModelViewFeatureForKeyFeat> keyFeatModel)
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
            keyFeatures = keyFeatureModel.GetAll();
            entitiesView.EmptyFeatureAsKey();
            entitiesView.DataChange();
        }

        public bool CheckInputData(List<ModelViewFeatureForKeyFeat> item)
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
        public bool CheckInputData(ModelViewFeatureForKeyFeat item, int numverRow)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            if (item.StartDate != null &&
                item.EndDate != null &&
                item.StartDate.Value.Date > item.EndDate.Value.Date)
            {
                entitiesView.ErrorRow(numverRow);
                return false;
            }

            return true;
        }
        public bool CheckKey(ModelViewHaspKey item) 
            => keyFeatures
                    .LastOrDefault(x => x.IdHaspKey == item.Id &&
                                        x.EndDate >= DateTime.Now.Date) == null;
    }
}
