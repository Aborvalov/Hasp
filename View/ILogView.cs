using ModelEntities;
using System.Collections.Generic;

namespace ViewContract
{
    public interface ILogView
    {
        void MessageError(string errorText);
        void Bind(List<ModelViewLog> entity);
    }
}
