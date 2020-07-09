﻿using ModelEntities;
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

        public EditKeyFeatureView(List<ModelViewFeatureForEditKeyFeat> entity) : this()
        {
            Bind(entity);
        }


        public void Bind(List<ModelViewFeatureForEditKeyFeat> entity)
           => bindingFeature.DataSource = entity != null ? new BindingList<ModelViewFeatureForEditKeyFeat>(entity)
                                                         : new BindingList<ModelViewFeatureForEditKeyFeat>();
    }
}
