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
        private ModelViewClient client = null;

        public ClientView()
        {
            InitializeComponent();
            presenterClient = new PresenterClient(this);
            dgvClient.Height = dgvClient.Size.Height + sizeH;
        }

        public void Add(ModelViewClient entity) => presenterClient.Add(entity);

        public void Build(List<ModelViewClient> entity) => bindingClient.DataSource = entity != null ? new BindingList<ModelViewClient>(entity)
                                                      : new BindingList<ModelViewClient>();

        public void MessageError(string error) => MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void Remove(int id) => presenterClient.Remove(id);

        public void Update(ModelViewClient entity) => presenterClient.Update(entity);

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                dgvClient.Height = dgvClient.Size.Height - sizeH;
                size = !size;
            }
            client = new ModelViewClient();
        }

        private void DgvClient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (size)
            {
                dgvClient.Height = dgvClient.Size.Height - sizeH;
                size = !size;
            }

            client = new ModelViewClient();
            var row = dgvClient.CurrentRow.DataBoundItem as ModelViewClient;

            client.Id = row.Id;
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

                client.Name = tbName.Text;
                client.Address = tbAddress.Text;
                client.Phone = tbPhone.Text;
                client.ContactPerson = tbContactPerson.Text;

                if (client.Id < 1)
                    Add(client);
                else
                    Update(client);

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
    }
}
