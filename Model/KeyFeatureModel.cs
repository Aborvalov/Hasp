using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class KeyFeatureModel : IKeyFeatureModel
    {
        private readonly EntitesContext db;
        private IKeyFeatureLogic keyFeatureLogic;
        private IFactoryLogic factoryLogic;
        
        public KeyFeatureModel(IFactoryLogic factoryLogic)
        {
            db = new EntitesContext();
            this.factoryLogic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));
            keyFeatureLogic = factoryLogic.CreateKeyFeature(db);
        }
        
        public List<ModelViewKeyFeature> GetAll() => Convert(keyFeatureLogic.GetAll());

        public ModelViewKeyFeature GetById(int id)
        {
            var keyFeature = keyFeatureLogic.GetById(id);
            var keys = factoryLogic.CreateHaspKey(db).GetAll();
            var feats = factoryLogic.CreateFeature(db).GetAll();
            
            var key = keys.FirstOrDefault(x => x.Id == keyFeature.IdHaspKey) ?? new HaspKey();
            var feat = feats.FirstOrDefault(x => x.Id == keyFeature.IdFeature) ?? new Feature();

            var viewKeyFeat = new ModelViewKeyFeature(keyFeature);
            return viewKeyFeat;
        }
       
        private List<ModelViewKeyFeature> Convert(List<KeyFeature> keyFeature)
        {
            if (keyFeature == null)
                throw new ArgumentNullException(nameof(keyFeature));

            var view = new List<ModelViewKeyFeature>();
           
            var  keys = factoryLogic.CreateHaspKey(db).GetAll();
            var  feats = factoryLogic.CreateFeature(db).GetAll();
           
             foreach (var keyFeat in keyFeature)
             {
                 var key = keys.FirstOrDefault(x => x.Id == keyFeat.IdHaspKey) ?? new HaspKey ();
                 var feat = feats.FirstOrDefault(x => x.Id == keyFeat.IdFeature) ?? new  Feature();
           
                 var viewKeyFeat = new ModelViewKeyFeature(keyFeat);
                 view.Add(viewKeyFeat);
             }
             return view;
        }

        public void Dispose() => db.Dispose();
    }
}
