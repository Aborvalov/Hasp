using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class ClientView : DevExpress.XtraEditors.XtraForm,
        IEntitesView<ModelViewClient>
    {
        private readonly IPresenterClient presenterClient;
        private bool size = true;
        private const int sizeH = 40;
        private ModelViewClient clientForDB = null;
        private bool search = false;
        public event Action DateUpdate;
        internal ModelViewClient SearchIdClient { get; private set; }

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

        public void Add(ModelViewClient entity)
        {
            presenterClient.Add(entity);
            DateUpdate?.Invoke();
        }

        public void Build(List<ModelViewClient> entity) => bindingClient.DataSource = entity != null ? new BindingList<ModelViewClient>(entity)
                                                      : new BindingList<ModelViewClient>();

        public void MessageError(string error) => MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void Remove(int id)
        {
            presenterClient.Remove(id);
            DateUpdate?.Invoke();
        }

        public void Update(ModelViewClient entity)
        {
            presenterClient.Update(entity);
            DateUpdate?.Invoke();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                dgvClient.Height = dgvClient.Size.Height - sizeH;
                size = !size;
            }
            clientForDB = new ModelViewClient();
        }

        private void DgvClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.search)
            {
                this.SearchIdClient = dgvClient.CurrentRow.DataBoundItem as ModelViewClient;
                this.Close();
                return;
            }

            if (size)
            {
                dgvClient.Height = dgvClient.Size.Height - sizeH;
                size = !size;
            }

            clientForDB = new ModelViewClient();
            var row = dgvClient.CurrentRow.DataBoundItem as ModelViewClient;

            clientForDB.Id = row.Id;
            tbName.Text = row.Name;
            tbAddress.Text = row.Address;
            tbContactPerson.Text = row.ContactPerson;
            tbPhone.Text = row.Phone;            
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!size)
            {
                if (!CheckInputData())
                    return;

                clientForDB.Name = tbName.Text;
                clientForDB.Address = tbAddress.Text;
                clientForDB.Phone = tbPhone.Text;
                clientForDB.ContactPerson = tbContactPerson.Text;

                if (clientForDB.Id < 1)
                    Add(clientForDB);
                else
                    Update(clientForDB);

                DefaultView();
            }
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
        }
        private bool CheckInputData()
        {
            string erroeMess = string.Empty;
            if (string.IsNullOrWhiteSpace(tbName.Text))
                erroeMess += '\u2022' + " Не заполнено поля \"Наименование\", не должно быть пустым." + '\n';
            if (string.IsNullOrWhiteSpace(tbAddress.Text))
                erroeMess += '\u2022' + " Не заполнено поля \"Адрес\", не должно быть пустым." + '\n';

            if (erroeMess != string.Empty)
            {
                MessageError(erroeMess.Trim());
                return false;
            }

            return true;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            var row = dgvClient.CurrentRow.DataBoundItem as ModelViewClient;
            if (row.Id == 0)
            {
                bindingClient.RemoveCurrent();
                return;
            }

            string caption = "Удалить клиента";
            string message = "Вы уверены, что хотите удалить клиента?";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Remove(row.Id);
                DefaultView();
            }
        }

        private void ButtonSearchByFeature_Click(object sender, EventArgs e)
        {
            DefaultView();
            FeatureView feature = new FeatureView(true);
            feature.ShowDialog();

            if (feature.SearchIdFeature != null)
            {
                presenterClient.GetByFeature(feature.SearchIdFeature);

                labelFeature.Text = feature.SearchIdFeature.Name;
            }
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            DefaultView();
            presenterClient.View();
        }

        private void TbInnerIdHaspKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {                
                presenterClient.GetByNumberKey(Int32.Parse(tbInnerIdHaspKey.Text));
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
    }
}
