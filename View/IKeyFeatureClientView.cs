using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public interface IKeyFeatureClientView
    {
        void DataChange();
        event Action DataUpdated;
        void MessageError(string errorText);
        void BindClient(List<ModelViewClient> client);
        void BindKey(List<ModelViewKeyFeatureClient> keyClient);
        string NameClient { get; set; }

    }
}
