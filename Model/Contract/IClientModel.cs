using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IClientModel : IEntitiesModel<ModelViewClient>, IDisposable
    {
        ModelViewClient GetByNumberKey(int keyInnerId);
        bool Add(IEnumerable<ModelViewClient> keyClient, out string error);
        bool Update(IEnumerable<ModelViewClient> keyClient, out string error);
        bool Remove(IEnumerable<ModelViewClient> idKeyClient, out string error);
        List<ModelViewClient> GetByFeature(ModelViewFeature feature);
        List<ModelViewClient> GetNumberOfKeysAndFeatures();
        List<ModelViewClient> GetByFeature(int id);
        List<ModelViewClient> GetByInnerId(int id);
    }
}
