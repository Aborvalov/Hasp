using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class ClientView : DevExpress.XtraEditors.XtraForm, IEntitiesView<ModelViewClient>
    {
        private readonly IPresenterClient presenterClient;
        private bool size = true;
        private const int sizeH = 40;
        private bool search = false;
        public event Action DataUpdated;
        internal ModelViewClient SearchIdClient { get; private set; }

        private const string caption = "Удалить клиента";
        private const string message = "Вы уверены, что хотите удалить клиента?";
        private const string error = "Ошибка";
        private const string emptyClient = "Данная клиент не найден.";
        
        public ClientView(bool search)
        {
            InitializeComponent();
            this.search = search;
            presenterClient = new PresenterClient(this);
            DataGridViewClient.Height = DataGridViewClient.Size.Height + sizeH;

            if (this.search)
                DataGridViewClient.Height = DataGridViewClient.Size.Height + 28;

            labelFeature.Text = string.Empty;
        }
        public ClientView() : this(false)
        { }

        public void DataChange() => DataUpdated?.Invoke();

        public void Bind(List<ModelViewClient> entity)
            => bindingClient.DataSource = entity != null ? new BindingList<ModelViewClient>(entity)
                                                         : new BindingList<ModelViewClient>();
        public void BindItem(ModelViewClient entity)
           => bindingItem.DataSource = entity ?? new ModelViewClient();

        public void MessageError(string errorText)
            => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
       
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                DataGridViewClient.Height = DataGridViewClient.Size.Height - sizeH;
                size = !size;
                buttonAdd.Enabled = false;
            }            
        }

        private void DataGridViewClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(DataGridViewClient.CurrentRow.DataBoundItem is ModelViewClient row))
            {
                MessageError(emptyClient);
                return;
            }
            if (this.search)
            {
                this.SearchIdClient = row;
                this.Close();
                return;
            }

            if (size)
            {
                DefaultView();
                DataGridViewClient.Height = DataGridViewClient.Size.Height - sizeH;
                size = !size;
                presenterClient.FillInputItem(row);
                buttonAdd.Enabled = false;
            }
        }
       
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (size)
                return;
            
            presenterClient.FillModel(bindingItem.DataSource as ModelViewClient);
            DefaultView();
        }
        private void DefaultView()
        {
            if (!size)
            {
                DataGridViewClient.Height = DataGridViewClient.Size.Height + sizeH;
                size = !size;
            }

            bindingItem.DataSource = new ModelViewClient();
            presenterClient.FillInputItem(bindingItem.DataSource as ModelViewClient);
            labelFeature.Text = string.Empty;
            tbInnerIdHaspKey.Text = string.Empty;
            buttonAdd.Enabled = true;
        }

        private void ButtonDelete_Click(object sender, EventArgs e) => DeleteItem();

        private void ButtonSearchByFeature_Click(object sender, EventArgs e)
        {
            DefaultView();

            using (FeatureView feature = new FeatureView(true))
            {
                feature.ShowDialog();

                if (feature.SearchFeature != null)
                {
                    presenterClient.GetByFeature(feature.SearchFeature);
                    labelFeature.Text = feature.SearchFeature.Name;
                }
            }
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            DefaultView();
            presenterClient.Display();
        }
        private void TbInnerIdHaspKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                presenterClient.GetByNumberKey(int.Parse(tbInnerIdHaspKey.Text));
                DefaultView();
            }
        }
        private void TbInnerIdHaspKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void DataGridViewClient_CellClick(object sender, DataGridViewCellEventArgs e) => FillDate();
        private void DataGridViewClient_SelectionChanged(object sender, EventArgs e) => FillDate();
        private void FillDate()
        {
            if (!size)
            {
                if (!(DataGridViewClient.CurrentRow.DataBoundItem is ModelViewClient row))
                {
                    MessageError(emptyClient);
                    return;
                }
                presenterClient.FillInputItem(row);
            }
        }

        private void DataGridViewClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteItem();
        }
        private void DeleteItem()
        {
            if (!(DataGridViewClient.CurrentRow.DataBoundItem is ModelViewClient row))
            {
                MessageError(emptyClient);
                return;
            }
            if (row.Id == 0)
            {
                bindingClient.RemoveCurrent();
                return;
            }

            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                presenterClient.Remove(row.Id);
                DefaultView();
            }
        }

        private void DataGridViewClient_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DataGridViewClient.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }
    }
}
