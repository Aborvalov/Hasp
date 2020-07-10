using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Logic;
using LogicContract;
using ModelEntities;

namespace Model
{
    public class FeatureFor__Model : IFeatureFor__Model
    {
        private readonly EntitesContext db;
        private IFeatureLogic featLogic;
        private IKeyFeatureLogic keyFeature;
        private ModelViewFeatureForEditKeyFeat model;

        public FeatureFor__Model(IFactoryLogic factoryLogic)
        {
            if (factoryLogic == null)
                throw new ArgumentNullException(nameof(factoryLogic));

            db = new EntitesContext();
            featLogic = factoryLogic.CreateFeature(db);
            keyFeature = factoryLogic.CreateKeyFeature(db);
        }




        public void Dispose() => db.Dispose();

        public List<ModelViewFeatureForEditKeyFeat> GetAll()
        {
            var viewFeature = new List<ModelViewFeatureForEditKeyFeat>();
            int i = 1;
            foreach (var item in featLogic.GetAll())
            {
                var model = new ModelViewFeatureForEditKeyFeat(item)
                {
                    SerialNumber = i++,
                };
                viewFeature.Add(model);
            }
            return viewFeature;
        }

        public List<ModelViewFeatureForEditKeyFeat> GetAll(int idKey)
        {
            var listKeyFeat = keyFeature.GetAll()
                              .Where(x => x.IdHaspKey == idKey);

            var viewFeature = new List<ModelViewFeatureForEditKeyFeat>();
            int i = 1;
            foreach (var item in featLogic.GetAll())
            {
                model = new ModelViewFeatureForEditKeyFeat(item)
                {
                    SerialNumber = i++,
                };

                var itemKeyFeature = listKeyFeat
                                     .LastOrDefault(x => x.IdFeature == item.Id);
                
                if (itemKeyFeature != null)
                {
                    model.Selected = true;
                    model.StartDate = itemKeyFeature.StartDate;
                    model.EndDate = itemKeyFeature.EndDate;
                    model.IdKey = idKey;
                }                

                viewFeature.Add(model);
            }
            return viewFeature;
        }
    }
}
