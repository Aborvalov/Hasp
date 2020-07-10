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

        public void Add(ModelViewKeyFeature entity)
        {
            throw new NotImplementedException();
        }

        public void DisplayHaspKey() => entitiesView.BindKey(keyModel.GetAll());
        public void DisplayFeatureAtKey(int idKey)
            => entitiesView.BindFeature(featureModel.GetAll(idKey));

        public void Dispose()
        {
            keyFeatureModel.Dispose();
            keyModel.Dispose();
            featureModel.Dispose();            
        }
        


    }
}
