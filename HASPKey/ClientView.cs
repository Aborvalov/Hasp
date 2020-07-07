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
        IEntitiesView<ModelViewClient>
    {
        private readonly IPresenterClient presenterClient;
        private bool size = true;
        private const int sizeH = 40;
        private bool search = false;
        public event Action DateUpdate;
        internal ModelViewClient SearchIdClient { get; private set; }

        private const string caption = "Удалить клиента";
        private const string message = "Вы уверены, что хотите удалить клиента?";
        private const string error = "Ошибка";
        private const string emptyClient = "Данная клиент не найден.";
        private const string errorEmptyName = "\u2022 Не заполнено поля \"Наименование\", не должно быть пустым. \n";
        private const string errorEmptyAddress = "\u2022 Не заполнено поля \"Адрес\", не должно быть пустым. \n";
                
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

        public void Bind(List<ModelViewClient> entity)
        => bindingClient.DataSource = entity != null ? new BindingList<ModelViewClient>(entity)
                                                     : new BindingList<ModelViewClient>();

        public void MessageError(string errorText) => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            presenterClient.Entities = new ModelViewClient();
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
                dgvClient.Height = dgvClient.Size.Height - sizeH;
                size = !size;
            }

            FillInputItem(row);
        }
        private void FillInputItem() => FillInputItem(dgvClient.CurrentRow.DataBoundItem as ModelViewClient);
        private void FillInputItem(ModelViewClient row)
        {
            presenterClient.Entities = new ModelViewClient
            {
                Id = row.Id
            };
            tbName.Text = row.Name;
            tbAddress.Text = row.Address;
            tbContactPerson.Text = row.ContactPerson;
            tbPhone.Text = row.Phone;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!size)
            {
                if (CheckInputData())
                    return;

                presenterClient.Entities.Name = tbName.Text;
                presenterClient.Entities.Address = tbAddress.Text;
                presenterClient.Entities.Phone = tbPhone.Text;
                presenterClient.Entities.ContactPerson = tbContactPerson.Text;

                if (presenterClient.Entities.Id < 1)
                    Add(presenterClient.Entities);
                else
                    Update(presenterClient.Entities);

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
            string errorMess = string.Empty;
            if (string.IsNullOrWhiteSpace(tbName.Text))
                errorMess += errorEmptyName;
            if (string.IsNullOrWhiteSpace(tbAddress.Text))
                errorMess += errorEmptyAddress;

            if (errorMess != string.Empty)
            {
                MessageError(errorMess.Trim());
                return false;
            }

            return true;
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
                Remove(row.Id);
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
        private void DgvClient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!size)
                FillInputItem();
        }
        private void DgvClient_SelectionChanged(object sender, EventArgs e)
        {
            if (!size)
                FillInputItem();
        }
    }
}
