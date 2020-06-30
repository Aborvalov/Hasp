using ModelEntities;
using System.Collections.Generic;

namespace Model
{
    public interface IClientModel : IEntitesModel<ModelViewClient>
    {
        List<ModelViewClient> GetByFeature(ModelViewFeature feature);
        ModelViewClient GetByNumberKey(int keyInnerId);
    }
}
