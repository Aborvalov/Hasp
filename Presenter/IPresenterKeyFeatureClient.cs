using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IPresenterKeyFeatureClient : IDisposable
    {
        void DisplayClient();
        void DisplayHaspKeyAtClient(int idClient);
        void Edit(List<ModelViewKeyFeatureClient> keyClient);
    }
}
