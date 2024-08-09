using ModelEntities;
using System.Collections.Generic;

namespace Model
{
    public interface ILogModel
    {
        List<ModelViewLog> GetAll();
    }
}
