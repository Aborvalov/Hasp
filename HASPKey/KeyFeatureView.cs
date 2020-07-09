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
        private bool size = true;
        private int sizeH = 55;
        public event Action DataUpdated;
        
        private const string error = "Ошибка";
        private const string selectFeature = "Выбрать функциональность";
        private const string emptyKeyFeature = "Данная завпись не найдена.";
        private const string caption = "Удалить связку ключ-функциональность";
        private const string message = "Вы уверены, что хотите удалить связь ключ-функциональность?";
               
        public KeyFeatureView()
        {
            InitializeComponent();
            presenterKeyFeature = new PresenterKeyFeature(this);
            dgvKeyFeature.Height = dgvKeyFeature.Size.Height + sizeH;
           
            DefaultView();
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
                DefaultView();
            }
        }

        private void DefaultView()
        {
            if (!size)
            {
                dgvKeyFeature.Height = dgvKeyFeature.Size.Height + sizeH;
                size = !size;
            }            
            buttonAdd.Enabled = true;
        }

        private void DgvKeyFeture_DoubleClick(object sender, EventArgs e)
        {
            if (!(dgvKeyFeature.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
            {
                MessageError(emptyKeyFeature);
                return;
            }
                        
            if (!size)
                return;
            DefaultView();

            dgvKeyFeature.Height = dgvKeyFeature.Size.Height - sizeH;
            size = !size;           
            buttonAdd.Enabled = false;
            presenterKeyFeature.FillInputItem(row);
        }
                
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (!(dgvKeyFeature.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
            {
                MessageError(emptyKeyFeature);
                return;
            }

            DefaultView();
            if (size)
            {
                dgvKeyFeature.Height = dgvKeyFeature.Size.Height - sizeH;                 
                size = !size;
                buttonAdd.Enabled = false;
                presenterKeyFeature.Entities = new ModelViewKeyFeature();
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (size)
                return;
                        
            if (presenterKeyFeature.Entities.Id < 1)
                dgvKeyFeature.Height = dgvKeyFeature.Size.Height - 20;
            /*
             * 
             * 
             * 
             * 
             * */
            presenterKeyFeature.FillModel(null);
            DefaultView();            
        }
        
        private void DgvKeyFeture_CellClick(object sender, DataGridViewCellEventArgs e) => FillDate();
        private void DgvKeyFeture_SelectionChanged(object sender, EventArgs e) => FillDate();
        private void FillDate()
        {
            if (!size)
            {
                if (!(dgvKeyFeature.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
                {
                    MessageError(emptyKeyFeature);
                    return;
                }
                presenterKeyFeature.FillInputItem(row);
            }
        }

       
    }
}
