using ModelEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HASPKey
{
    public partial class EditKeyFeatureView : DevExpress.XtraEditors.XtraForm
    {
        public EditKeyFeatureView()
        {
            InitializeComponent();
        }

        public EditKeyFeatureView(List<ModelViewFeatureForEditKeyFeat> feature, List<ModelViewHaspKey> key) : this()
        {
            BindFeature(feature);
            BindKey(key);
        }


        public void BindFeature(List<ModelViewFeatureForEditKeyFeat> entity)
           => bindingFeature.DataSource = entity != null ? new BindingList<ModelViewFeatureForEditKeyFeat>(entity)
                                                         : new BindingList<ModelViewFeatureForEditKeyFeat>();
        public void BindKey(List<ModelViewHaspKey> entity)
          => bindingHaspKey.DataSource = entity != null ? new BindingList<ModelViewHaspKey>(entity)
                                                        : new BindingList<ModelViewHaspKey>();
    }
}
