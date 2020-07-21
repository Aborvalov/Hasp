using ModelEntities;
using System.Collections.Generic;

namespace View
{
    public interface IMainView
    {
        void Bind(List<ModelViewMain> homes);
        void MessageError(string error);
    }
}
