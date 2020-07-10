using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class KeyFeatureView : DevExpress.XtraEditors.XtraForm, IEntitiesView<ModelViewKeyFeature>
    {
        private readonly IPresenterEntities<ModelViewKeyFeature> presenterKeyFeature;       
        public event Action DataUpdated;
        
        private const string error = "Ошибка";
        private const string emptyKeyFeature = "Данная завпись не найдена.";
        private const string caption = "Удалить связку ключ-функциональность";
        private const string message = "Вы уверены, что хотите удалить связь ключ-функциональность?";
               
        public KeyFeatureView()
        {
            InitializeComponent();
            presenterKeyFeature = new PresenterKeyFeature(null);  
        }
               
        public void Bind(List<ModelViewKeyFeature> entity) 
            => bindingKeyFeature.DataSource = entity != null ? new BindingList<ModelViewKeyFeature>(entity)
                                                             : new BindingList<ModelViewKeyFeature>();

        public void BindItem(ModelViewKeyFeature entity)
        {
            throw new NotImplementedException();
        }
        
        public void MessageError(string errorText) => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void DataChange() => DataUpdated?.Invoke();

        private void Button1Delete_Click(object sender, EventArgs e)
        {
            if (!(dgvKeyFeature.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
            {
                MessageError(emptyKeyFeature);
                return;
            }            
            if (row.Id == 0)
            {
                bindingKeyFeature.RemoveCurrent();
                return;
            }
            
            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                presenterKeyFeature.Remove(row.Id);
            }
        }
               
        private void DgvKeyFeture_DoubleClick(object sender, EventArgs e)
        {
            if (!(dgvKeyFeature.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
            {
                MessageError(emptyKeyFeature);
                return;
            }
            presenterKeyFeature.FillInputItem(row);
        }
                
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            ModelViewFeatureForEditKeyFeat item = new ModelViewFeatureForEditKeyFeat(new Entities.Feature
            {
                Id = 1,
                Description = "dsfdsf",
                Name = "test",
                Number = 1,
            })
            {
                EndDate = DateTime.Now.Date.AddDays(30),
                StartDate = DateTime.Now.Date,
                Selected = true,
                SerialNumber = 1,                
            };
            ModelViewFeatureForEditKeyFeat item2 = new ModelViewFeatureForEditKeyFeat(new Entities.Feature
            {
                Id = 2,
                Name = "____",
                Number = 2,
            })
            {
                Selected = false,
                SerialNumber = 2,
            };

            ModelViewHaspKey key = new ModelViewHaspKey
            {
                Id = 1,
                InnerId = 2,
                IsHome = true,
                Number = "sdf",
                TypeKey = Entities.TypeKey.Pro,
                SerialNumber = 1,
            };



            var tf = new List<ModelViewFeatureForEditKeyFeat>();
            var tk = new List<ModelViewHaspKey>();

            tf.Add(item);
            tf.Add(item2);
            tk.Add(key);
            EditKeyFeatureView editKeyFeatureView = new EditKeyFeatureView(tf,tk);
            editKeyFeatureView.Show();




            //if (!(dgvKeyFeature.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
            //{
            //    MessageError(emptyKeyFeature);
            //    return;
            //}

            //presenterKeyFeature.Entities = new ModelViewKeyFeature();            
        }       
    }
}
