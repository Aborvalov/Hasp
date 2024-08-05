using ModelEntities;
using System.Collections.Generic;

namespace ViewContract
{
    public interface IMainView
    {
        void Bind(List<ModelViewMain> homes);
        void Bind(List<DXModelClient> homes);
        void Bind(List<DXModelLicenseEnd> homes);
        void MessageError(string error);
        bool ErrorDataBase { get; set; }

    }
}