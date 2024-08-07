using ModelEntities;
using System.Collections.Generic;
using System.Deployment.Internal;

namespace Model
{
    public interface IHaspKeyModel : IEntitiesModel<ModelViewHaspKey>
    {
        List<ModelViewHaspKey> GetByClient(ModelViewClient client);
        List<ModelViewHaspKey> GetByActive();
        List<ModelViewHaspKey> GetAllInCompany(ModelViewClient client);
        List<ModelViewHaspKey> GetActiveInCompany(ModelViewClient client);
        List<ModelViewHaspKey> GetByPastDue(ModelViewClient client);
    }
}
