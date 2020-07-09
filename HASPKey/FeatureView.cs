using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class FeatureView : DevExpress.XtraEditors.XtraForm, IFeatureView
    {
        private readonly IPresenterEntities<ModelViewFeature> presenterFeature;
        private bool size = true;
        private int sizeH = 40;       
        private bool search = false;
        public event Action DataUpdated;
        internal ModelViewFeature SearchFeature { get; private set; } = null;
        
        private const string error = "Ошибка";
        private const string emptyFeature = "Функциональность не найдена.";
        private const string caption = "Удалить фичу";
        private const string message = "Вы уверены, что хотите удалить фичу?";
        
        public FeatureView(bool search) : this()
        { 
            this.search = search;            
            dgvFeature.Height = dgvFeature.Size.Height + 28;
        }
        public FeatureView() 
        {
            InitializeComponent();
            presenterFeature = new PresenterFeature(this);
            dgvFeature.Height = dgvFeature.Size.Height + sizeH;            
        }

        public void DataChange() => DataUpdated?.Invoke();    

        public void Bind(List<ModelViewFeature> entity) 
        => bindingFeature.DataSource = entity != null ? new BindingList<ModelViewFeature>(entity)
                                                      : new BindingList<ModelViewFeature>();

        public void BindItem(ModelViewFeature entity)
        => bindingItem.DataSource = entity ?? new ModelViewFeature();

        public void MessageError(string errorText) => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);              

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                dgvFeature.Height = dgvFeature.Size.Height - sizeH;
                size = !size;
                ButtonAdd.Enabled = false;
                bindingItem.DataSource = new ModelViewFeature();
                tbNumber.Text = string.Empty;
            }            
        }

        private void DgvFeature_DoubleClick(object sender, EventArgs e)
        {
            if (!(dgvFeature.CurrentRow.DataBoundItem is ModelViewFeature row))
            {
                MessageError(emptyFeature);
                return;
            }
            if (search)
            {
                SearchFeature = row;
                Close();
                return;
            }
                        
            if (size)
            {
                DefaultView();
                dgvFeature.Height = dgvFeature.Size.Height - sizeH;
                size = !size;
                presenterFeature.FillInputItem(row);
                ButtonAdd.Enabled = false;
            }
        }       

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (size)
                return;

            presenterFeature.FillModel(bindingItem.DataSource as ModelViewFeature);            
            DefaultView();           
        }        

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!(dgvFeature.CurrentRow.DataBoundItem is ModelViewFeature row))
            {
                MessageError(emptyFeature);
                return;
            }
            if (row.Id == 0)
            {
                bindingFeature.RemoveCurrent();
                return;
            }

            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                presenterFeature.Remove(row.Id);
                DefaultView();
            }
        }
        private void DefaultView()
        {
            if (!size)
            {
                dgvFeature.Height = dgvFeature.Size.Height + sizeH;
                size = !size;
            }
            bindingItem.DataSource = new ModelViewFeature();
            tbNumber.Text = string.Empty;
            tbName.Text = string.Empty;
            tbDescription.Text = string.Empty;
            ButtonAdd.Enabled = true;
        }

        private void DgvFeature_CellClick(object sender, DataGridViewCellEventArgs e)=> FillDate();
        private void DgvFeature_SelectionChanged(object sender, EventArgs e) => FillDate();

        private void FillDate()
        {
            if (!size)
            {
                if (!(dgvFeature.CurrentRow.DataBoundItem is ModelViewFeature row))
                {
                    MessageError(emptyFeature);
                    return;
                }
                presenterFeature.FillInputItem(row);
            }
        }
               
        private void TbNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
