using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class ClientView : DevExpress.XtraEditors.XtraForm, IClientView
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
              
        public string NameClient
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }       
        public string Address
        {
            get { return tbAddress.Text; }
            set { tbAddress.Text = value; }
        }       
        public string Phone
        {
            get { return tbPhone.Text; }
            set { tbPhone.Text = value; }
        }
        public string ContactPerson
        {
            get { return tbContactPerson.Text; }
            set { tbContactPerson.Text = value;}
        }
        public ClientView(bool search)
        {
            InitializeComponent();
            this.search = search;
            presenterClient = new PresenterClient(this);
            dgvClient.Height = dgvClient.Size.Height + sizeH;

            if (this.search)
                dgvClient.Height = dgvClient.Size.Height + 28;

            labelFeature.Text = string.Empty;
        }
        public ClientView() : this(false)
        { }

        public void DataChange() => DataUpdated?.Invoke();

        public void Bind(List<ModelViewClient> entity)
        => bindingClient.DataSource = entity != null ? new BindingList<ModelViewClient>(entity)
                                                     : new BindingList<ModelViewClient>();

        public void MessageError(string errorText) => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
       
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                dgvClient.Height = dgvClient.Size.Height - sizeH;
                size = !size;
                buttonAdd.Enabled = false;
                presenterClient.Entities = new ModelViewClient();
            }            
        }

        private void DgvClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!(dgvClient.CurrentRow.DataBoundItem is ModelViewClient row))
            {
                MessageError(emptyClient);
                return;
            }
            if (this.search)
            {
                this.SearchIdClient = dgvClient.CurrentRow.DataBoundItem as ModelViewClient;
                this.Close();
                return;
            }

            if (size)
            {
                DefaultView();
                dgvClient.Height = dgvClient.Size.Height - sizeH;
                size = !size;
                presenterClient.FillInputItem(row);
                buttonAdd.Enabled = false;
            }
        }
       
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (size)
                return;
            /*
             * 
             * 
             * 
             * */
            presenterClient.FillModel(null);
            DefaultView();
        }
        private void DefaultView()
        {
            if (!size)
            {
                dgvClient.Height = dgvClient.Size.Height + sizeH;
                size = !size;
            }
            tbName.Text = string.Empty;
            tbAddress.Text = string.Empty;
            tbContactPerson.Text = string.Empty;
            tbPhone.Text = string.Empty;
            labelFeature.Text = string.Empty;
            tbInnerIdHaspKey.Text = string.Empty;
            buttonAdd.Enabled = true;
        }
        
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!(dgvClient.CurrentRow.DataBoundItem is ModelViewClient row))
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
        private void DgvClient_CellClick(object sender, DataGridViewCellEventArgs e) => FillDate();
        private void DgvClient_SelectionChanged(object sender, EventArgs e) => FillDate();
        private void FillDate()
        {
            if (!size)
            {
                if (!(dgvClient.CurrentRow.DataBoundItem is ModelViewClient row))
                {
                    MessageError(emptyClient);
                    return;
                }
                presenterClient.FillInputItem(row);
            }
        }

        private void TbName_TextChanged(object sender, EventArgs e) => NameClient = tbName.Text;

        private void TbAddress_TextChanged(object sender, EventArgs e) => Address = tbAddress.Text;

        private void TbPhone_TextChanged(object sender, EventArgs e) => Phone = tbPhone.Text;

        private void TbContactPerson_TextChanged(object sender, EventArgs e) => ContactPerson = tbContactPerson.Text;
    }
}
