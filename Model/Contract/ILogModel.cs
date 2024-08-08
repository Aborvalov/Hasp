using ModelEntities;
using System.Collections.Generic;

namespace Model
{
    public interface ILogModel : IEntitiesModel<ModelViewLog>
    {
        void Remove(IEnumerable<ModelViewLog> delete, out string error);
    }
}
