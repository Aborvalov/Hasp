using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class EditKeyFeatureView : DevExpress.XtraEditors.XtraForm, IKeyFeatureView
    {
        public event Action DataUpdated;
        public List<ModelViewKeyFeature> KeyFeatyre { get; set; }
        IPresenterKeyFeature presenterEntities;

        private const string error = "Ошибка";
        private const string emptyKey = "Данный ключ не найден.";


        public EditKeyFeatureView()
        {
            InitializeComponent();

            presenterEntities = new PresenterEditKeyFeature(this);
        }

        public EditKeyFeatureView(List<ModelViewFeatureForEditKeyFeat> feature, List<ModelViewHaspKey> key) : this()
        {
            BindFeature(feature);
            BindKey(key);
        }



        public void DataChange() => DataUpdated?.Invoke();
        public void MessageError(string errorText) => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        
        public void BindFeature(List<ModelViewFeatureForEditKeyFeat> feature)
           => bindingFeature.DataSource = feature != null ? new BindingList<ModelViewFeatureForEditKeyFeat>(feature)
                                                          : new BindingList<ModelViewFeatureForEditKeyFeat>();
        public void BindKey(List<ModelViewHaspKey> key)
          => bindingHaspKey.DataSource = key != null ? new BindingList<ModelViewHaspKey>(key)
                                                     : new BindingList<ModelViewHaspKey>();

        private void DgvHaspKey_CellClick(object sender, DataGridViewCellEventArgs e) => FillFeatureAtKey();

        private void DgvHaspKey_SelectionChanged(object sender, EventArgs e) => FillFeatureAtKey();

        private void FillFeatureAtKey()
        {
            if (!(dgvHaspKey.CurrentRow.DataBoundItem is ModelViewHaspKey row))
            {
                MessageError(emptyKey);
                return;
            }            
            presenterEntities.DisplayFeatureAtKey(row.Id);
        }
    }
}
