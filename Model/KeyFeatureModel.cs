using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class KeyFeatureModel : IEntitiesModel<ModelViewKeyFeature>
    {
        private readonly EntitesContext db;
        private IKeyFeatureLogic keyFeatureLogic;
        private IFactoryLogic factoryLogic;
        private readonly DateTime startDate = DateTime.Now.Date;

        public KeyFeatureModel(IFactoryLogic factoryLogic)
        {
            db = new EntitesContext();
            this.factoryLogic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));
            keyFeatureLogic = factoryLogic.CreateKeyFeature(db);
        }
        public bool Add(ModelViewKeyFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return keyFeatureLogic.Save(entity.KeyFeature);
        }

        public List<ModelViewKeyFeature> GetAll() => Convert(keyFeatureLogic.GetAll());

        public ModelViewKeyFeature GetById(int id)
        {
            var keyFeature = keyFeatureLogic.GetById(id);
            var keys = factoryLogic.CreateHaspKey(db).GetAll();
            var feats = factoryLogic.CreateFeature(db).GetAll();
            
            var key = keys.FirstOrDefault(x => x.Id == keyFeature.IdHaspKey) ?? new HaspKey();
            var feat = feats.FirstOrDefault(x => x.Id == keyFeature.IdFeature) ?? new Feature();

            var viewKeyFeat = new ModelViewKeyFeature(keyFeature)
            {
                SerialNumber = 1,
                TypeKey = key.TypeKey,
                NumberKey = key.InnerId.ToString() + " - \"" + key.Number + "\"",
                Feature = feat.Name,
            };

            return viewKeyFeat;
        }

        public bool Remove(int id) => keyFeatureLogic.Remove(id);

        public bool Update(ModelViewKeyFeature entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return keyFeatureLogic.Update(entity.KeyFeature);
        }
        private List<ModelViewKeyFeature> Convert(List<KeyFeature> keyFeature)
        {
            if (keyFeature == null)
                throw new ArgumentNullException(nameof(keyFeature));

            var view = new List<ModelViewKeyFeature>();
            int i = 1;

           var  keys = factoryLogic.CreateHaspKey(db).GetAll();
           var  feats = factoryLogic.CreateFeature(db).GetAll();

            foreach (var keyFeat in keyFeature)
            {
                var key = keys.FirstOrDefault(x => x.Id == keyFeat.IdHaspKey) ?? new HaspKey();
                var feat = feats.FirstOrDefault(x => x.Id == keyFeat.IdFeature) ?? new Feature();
                
                var viewKeyFeat = new ModelViewKeyFeature(keyFeat)
                {
                    SerialNumber = i++,
                    TypeKey = key.TypeKey,
                    NumberKey = key.InnerId.ToString() + " - \"" + key.Number + "\"",
                    Feature = feat.Name,                    
                };

                view.Add(viewKeyFeat);
            }
            return view;
        }

        public void Dispose() => db.Dispose();
    }
}
