using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class KeyFeatureModel : IEntitesModel<ModelViewKeyFeature>
    {
        private readonly IFactoryLogic logic;
        private IKeyFeatureLogic keyFeatureLogic;

        public KeyFeatureModel(IFactoryLogic factoryLogic)
        {
            logic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));
        }
        public bool Add(ModelViewKeyFeature entity)
        {
            KeyFeature keyFeature = new KeyFeature
            {
                IdFeature = entity.IdFeature,
                IdHaspKey = entity.IdHaspKey,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
            };

            using (var db = new EntitesContext())
            {
                keyFeatureLogic = logic.CreateKeyFeature(db);
                return keyFeatureLogic.Save(keyFeature);
            }
        }

        public List<ModelViewKeyFeature> GetAll()
        {
            List<KeyFeature> keyFeature;
            using (var db = new EntitesContext())
            {
                keyFeatureLogic = logic.CreateKeyFeature(db);
                keyFeature = keyFeatureLogic.GetAll();
            }

            return Convert(keyFeature);
        }
        public ModelViewKeyFeature GetById(int id)
        {
            KeyFeature keyFeature;
            var keys = new List<HaspKey>();
            var feats = new List<Feature>();

            using (var db = new EntitesContext())
            {
                keyFeatureLogic = logic.CreateKeyFeature(db);
                keyFeature = keyFeatureLogic.GetById(id);

                keys = logic.CreateHaspKey(db).GetAll();
                feats = logic.CreateFeature(db).GetAll();
            }
            
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

        public bool Remove(int id)
        {
            using (var db = new EntitesContext())
            {
                keyFeatureLogic = logic.CreateKeyFeature(db);
               return keyFeatureLogic.Remove(id);
            }
        }

        public bool Update(ModelViewKeyFeature entity)
        {
            KeyFeature keyFeature = new KeyFeature
            {
                Id = entity.Id,
                IdFeature = entity.IdFeature,
                IdHaspKey = entity.IdHaspKey,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
            };

            using (var db = new EntitesContext())
            {
                keyFeatureLogic = logic.CreateKeyFeature(db);
                return keyFeatureLogic.Update(keyFeature);
            }
        }
        private List<ModelViewKeyFeature> Convert(List<KeyFeature> keyFeature)
        {
            var view = new List<ModelViewKeyFeature>();
            int i = 1;

            var keys = new List<HaspKey>();
            var feats = new List<Feature>();

            using (var db = new EntitesContext())
            {
                keys = logic.CreateHaspKey(db).GetAll();
                feats = logic.CreateFeature(db).GetAll();
            }

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
    }
}
