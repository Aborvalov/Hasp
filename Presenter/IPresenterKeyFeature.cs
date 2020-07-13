using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IPresenterKeyFeature : IDisposable
    {
        ModelViewKeyFeature Entities { get; set; }
        void DisplayHaspKey();
        void DisplayFeatureAtKey(int idKey);
        void Edit(List<ModelViewFeatureForEditKeyFeat> keyFeatModel);
    }
}
