using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IClientModel : IEntitiesModel<ModelViewClient>, IDisposable
    {
        List<ModelViewClient> GetByFeature(ModelViewFeature feature);
        ModelViewClient GetByNumberKey(int keyInnerId);
        bool Add(IEnumerable<ModelViewClient> keyClient, out string error);
        bool Add(ModelViewClient entity);
        List<ModelViewClient> GetNumberOfKeysAndFeatures();
        bool Update(IEnumerable<ModelViewClient> keyClient, out string error);
        bool Remove(IEnumerable<ModelViewClient> idKeyClient, out string error);
        bool Remove(int id);
        bool Update(ModelViewClient entity);
        List<ModelViewClient> GetByFeature(int id);
        List<ModelViewClient> GetByInnerId(int id);
    }
}
