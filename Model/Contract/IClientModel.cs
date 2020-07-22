using ModelEntities;
using System.Collections.Generic;

namespace Model
{
    public interface IClientModel : IEntitiesModel<ModelViewClient>
    {
        List<ModelViewClient> GetByFeature(ModelViewFeature feature);
        ModelViewClient GetByNumberKey(int keyInnerId);
    }
}
