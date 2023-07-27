using ModelEntities;
using System.Collections.Generic;

namespace ViewContract
{
    public interface IMainView
    {
        void Bind(List<ModelViewMain> homes);
        void Bind(List<DXModelClient> homes);
        void BindForm(List<DXModelClient> homes);
        void MessageError(string error);
        bool ErrorDataBase { get; set; }
        
    }
}
