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
        private readonly DateTime date = DateTime.Now.Date;

        private const string errorAdd = "Не удалось создать запись с данной функциональностью: ";
        private const string errorDelete = "Не удалось удалить запись: ";





        public FeatureFor__Model(IFactoryLogic factoryLogic)
        {
            if (factoryLogic == null)
                throw new ArgumentNullException(nameof(factoryLogic));

            db = new EntitesContext();
            featLogic = factoryLogic.CreateFeature(db);
            keyFeature = factoryLogic.CreateKeyFeature(db);
        }

        public bool Add(List<ModelViewFeatureForEditKeyFeat> keyFeat, out string error)
        {
            error = string.Empty;

            foreach (var item in keyFeat)
            {
                var keyFeature = new KeyFeature()
                {
                    IdFeature = item.IdFeature,
                    IdHaspKey = item.IdKey,
                    StartDate = (DateTime)item.StartDate,
                    EndDate = (DateTime)item.EndDate,
                };

                if (!this.keyFeature.Save(keyFeature))
                    error += errorAdd + item.Feature + '\n';
            }

            return error == string.Empty;
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
                    IdKey = idKey,
                };

                var itemKeyFeature = listKeyFeat
                                     .LastOrDefault(x => x.IdFeature == item.Id &&
                                                         x.EndDate >= date);
                
                if (itemKeyFeature != null)
                {
                    model.Selected = true;
                    model.StartDate = itemKeyFeature.StartDate;
                    model.EndDate = itemKeyFeature.EndDate;
                    model.IdKeyFeaure = itemKeyFeature.Id;                 
                }                

                viewFeature.Add(model);
            }
            return viewFeature;
        }

        public bool Remove(IEnumerable<int> idFeatureKey, out string error)
        {
            error = string.Empty;

            foreach (var id in idFeatureKey)
                if (!keyFeature.Remove(id))
                    error += errorDelete + id.ToString() + '\n';
            
            return error == string.Empty;                 
        }
    }
}
