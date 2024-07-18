using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class FeatureView : DevExpress.XtraEditors.XtraForm, IEntitiesView<ModelViewFeature>
    {
        private readonly IEntitiesPresenter<ModelViewFeature> presenterFeature;
        private bool size = true;
        private int sizeH = 40;       
        private bool search = false;
        private bool error = false;
        public event Action DataUpdated;
        internal ModelViewFeature SearchFeature { get; private set; } = null;
        
        private const string errorStr = "Ошибка";
        private const string emptyFeature = "Функциональность не найдена.";
        private const string caption = "Удалить фичу";
        private const string message = "Вы уверены, что хотите удалить фичу?";
        
        public FeatureView(bool search) 
        {
            InitializeComponent();
            presenterFeature = new FeaturePresenter(this);
            DataGridViewFeature.Height = DataGridViewFeature.Size.Height + sizeH;

            this.search = search;
            if (this.search || !Admin.IsAdmin())
                DataGridViewFeature.Height = DataGridViewFeature.Size.Height + 28;
        }
        public FeatureView() : this(false)
        {}

        public void DataChange() => DataUpdated?.Invoke();    

        public void Bind(List<ModelViewFeature> entity) 
            => bindingFeature.DataSource = entity != null ? new BindingList<ModelViewFeature>(entity)
                                                          : new BindingList<ModelViewFeature>();

        public void BindItem(ModelViewFeature entity)
            => bindingItem.DataSource = entity ?? new ModelViewFeature();

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = true;
        }           

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                DataGridViewFeature.Height = DataGridViewFeature.Size.Height - sizeH;
                size = !size;
                ButtonAdd.Enabled = false;               
            }            
        }

        private void DataGridViewFeatureFeature_DoubleClick(object sender, EventArgs e)
        {
            if (!(DataGridViewFeature.CurrentRow.DataBoundItem is ModelViewFeature row))
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
                        
            if (size && Admin.IsAdmin())
            {
                DefaultView();
                DataGridViewFeature.Height = DataGridViewFeature.Size.Height - sizeH;
                size = !size;
                presenterFeature.FillInputItem(row);
                ButtonAdd.Enabled = false;
            }
        }       

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (size)
                return;

            error = false;
            presenterFeature.FillModel(bindingItem.DataSource as ModelViewFeature);
            if (!error)
                DefaultView();
        }

        private void ButtonDelete_Click(object sender, EventArgs e) => DeleteIrem();
        private void DefaultView()
        {
            if (!size)
            {
                DataGridViewFeature.Height = DataGridViewFeature.Size.Height + sizeH;
                size = !size;
            }
            
            bindingItem.DataSource = new ModelViewFeature();
            presenterFeature.FillInputItem(bindingItem.DataSource as ModelViewFeature);
            tbNumber.Text = string.Empty;           
            ButtonAdd.Enabled = true;
        }

        private void DataGridViewFeatureFeature_CellClick(object sender, DataGridViewCellEventArgs e)=> FillDate();
        private void DataGridViewFeatureFeature_SelectionChanged(object sender, EventArgs e) => FillDate();

        private void FillDate()
        {
            if (!size)
            {
                if (!(DataGridViewFeature.CurrentRow.DataBoundItem is ModelViewFeature row))
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
                e.Handled = true;
        }

        private void DataGridViewFeatureFeature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteIrem();
        }

        private void DeleteIrem()
        {
            if (!(DataGridViewFeature.CurrentRow.DataBoundItem is ModelViewFeature row))
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

        private void DataGridViewFeature_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DataGridViewFeature.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DefaultView();
        }
    }
}
