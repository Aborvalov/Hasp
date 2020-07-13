using Logic;
using Model;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View;

namespace Presenter
{
    public class PresenterEditKeyFeature : IPresenterKeyFeature
    {
        private readonly IEntitiesModel<ModelViewKeyFeature> keyFeatureModel;
        private readonly IEntitiesModel<ModelViewHaspKey> keyModel;
        private readonly IFeatureFor__Model featureModel;
        private readonly IKeyFeatureView entitiesView;


        public PresenterEditKeyFeature(IKeyFeatureView entitesView)
        {
            this.entitiesView = entitesView ?? throw new ArgumentNullException(nameof(entitesView));

            keyFeatureModel = new KeyFeatureModel(new Logics());
            keyModel = new HaspKeyModel(new Logics());
            featureModel = new FeatureFor__Model(new Logics());

            DisplayHaspKey();
        }


               
        public ModelViewKeyFeature Entities { get; set; }

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
                

        public void Edit(List<ModelViewFeatureForEditKeyFeat> keyFeatModel)
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
                                    x.EndDate != null)
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
            entitiesView.DataChange();
        }

        public bool CheckInputData(List<ModelViewFeatureForEditKeyFeat> item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            int numverRow = 0;
            bool error = true;
            foreach (var i in item)
            {
                error = CheckInputData(i, numverRow);
                numverRow++;
            }

            return error;
        }
        public bool CheckInputData(ModelViewFeatureForEditKeyFeat item, int numverRow)
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
    }
}
