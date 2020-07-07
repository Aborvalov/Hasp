using Entities;
using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class HaspKeyView : DevExpress.XtraEditors.XtraForm, IEntitiesView<ModelViewHaspKey>
    {
        private readonly IPresenterHaspKey presenterHaspKey;
        private bool size = true;
        private const int sizeH = 40;
        public event Action DateUpdate;
        private bool search = false;
        internal ModelViewHaspKey SearchHaspKey { get; private set; } = null;

        public HaspKeyView()
        {
            InitializeComponent();
            presenterHaspKey = new PresenterHaspKey(this);
            dgvHaspKey.Height = dgvHaspKey.Size.Height + sizeH;
            comboBoxTypeKey.DataSource = Enum.GetValues(typeof(TypeKey));
            comboBoxTypeKey.SelectedIndex = -1;

            labelClient.Text = string.Empty;
        }
        public HaspKeyView(bool search) : this()
        {
            this.search = search;
            dgvHaspKey.Height = dgvHaspKey.Size.Height + 28;
        }

        public void Add(ModelViewHaspKey entity)
        {
            presenterHaspKey.Add(entity);
            DateUpdate?.Invoke();
        }

        public void Bind(List<ModelViewHaspKey> entity) 
        => bindingHaspKey.DataSource = entity != null ? new BindingList<ModelViewHaspKey>(entity)
                                                      : new BindingList<ModelViewHaspKey>();

        public void Remove(int id)
        {
            presenterHaspKey.Remove(id);
            DateUpdate?.Invoke();
        }

        public void Update(ModelViewHaspKey entity)
        {
            presenterHaspKey.Update(entity);
            DateUpdate?.Invoke();
        }

            private void RadioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            presenterHaspKey.View();
            labelClient.Text = string.Empty;
        }
        private void RadioButtonPastDue_CheckedChanged(object sender, EventArgs e)
        {
            presenterHaspKey.GetByPastDue();
            labelClient.Text = string.Empty;
        }
        private void RadioButtonActive_CheckedChanged(object sender, EventArgs e)
        {
            presenterHaspKey.GetByActive();
            labelClient.Text = string.Empty;
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                dgvHaspKey.Height = dgvHaspKey.Size.Height - sizeH;
                size = !size;
                buttonAdd.Enabled = false;
            }
            presenterHaspKey.HaspKey = new ModelViewHaspKey();
        }
        public void MessageError(string error) => MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!size)
            {                           
                if (!CheckInputData(out int innNumber))
                    return;

                presenterHaspKey.HaspKey.InnerId = innNumber;
                presenterHaspKey.HaspKey.Number = tbNumber.Text.Trim();
                presenterHaspKey.HaspKey.TypeKey = (TypeKey)comboBoxTypeKey.SelectedItem;
                presenterHaspKey.HaspKey.IsHome = checkBoxIsHome.Checked;

                if(presenterHaspKey.HaspKey.Id < 1)
                    Add(presenterHaspKey.HaspKey);                
                else
                    Update(presenterHaspKey.HaspKey);

                DefaultView();
            }
        }

        private void DgvHaspKey_DoubleClick(object sender, EventArgs e)
        {
            if (search)
            {
                SearchHaspKey = dgvHaspKey.CurrentRow.DataBoundItem as ModelViewHaspKey;
                Close();
                return;
            }
            if (size)
            {
                dgvHaspKey.Height = dgvHaspKey.Size.Height - sizeH;
                size = !size;
            }

            presenterHaspKey.HaspKey = new ModelViewHaspKey();
            FillInputItem();
        }

        private void DefaultView()
        {
            if (!size)
            {
                dgvHaspKey.Height = dgvHaspKey.Size.Height + sizeH;
                size = !size;
            }

            tbInnerNumber.Text = string.Empty;
            tbNumber.Text = string.Empty;
            comboBoxTypeKey.SelectedIndex = -1;
            checkBoxIsHome.Checked = false;
            labelClient.Text = string.Empty;
            buttonAdd.Enabled = true;
        }
        private bool CheckInputData(out int innNumber)
        {
            string erroeMess = string.Empty;
            bool isInt = Int32.TryParse(tbInnerNumber.Text, out innNumber);

            if (!isInt)
            {
                erroeMess = '\u2022' + " Неверное значение внутреннего ключа, должно быть числом." + '\n';
                tbInnerNumber.Text = string.Empty;
            }

            if (comboBoxTypeKey.SelectedItem == null)
                erroeMess += '\u2022' + " Не выбран тип ключа." + '\n';

            if (string.IsNullOrWhiteSpace(tbNumber.Text))
                erroeMess += '\u2022' + " Не заполнено поля \"Номер\", не должно быть пустым." + '\n';

            if (erroeMess != string.Empty)
            {
                MessageError(erroeMess.Trim());
                return false;
            }

            return true;
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            var row = dgvHaspKey.CurrentRow.DataBoundItem as ModelViewHaspKey;
            if (row.Id == 0)
            {
                bindingHaspKey.RemoveCurrent();
                return;
            }

            string caption = "Удалить ключ";
            string message = "Вы уверены, что хотите удалить Hasp-ключ?";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Remove(row.Id);
                DefaultView();
            }
        }

        private void ButtonSearchByClient_Click(object sender, EventArgs e)
        {
            radioButtonActive.Checked = false;
            radioButtonAll.Checked = false;
            radioButtonPastDue.Checked = false;

            ClientView client = new ClientView(true);
            client.ShowDialog();

            if (client.SearchIdClient != null)
            {
                DefaultView();
                presenterHaspKey.GetByClient(client.SearchIdClient);
                
                labelClient.Text = client.SearchIdClient.Name;
                labelClient.Location = new System.Drawing.Point((this.Width - 25) - labelClient.Width, labelClient.Location.Y);
            }
        }

        private void DgvHaspKey_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!size)
                FillInputItem();
        }

        private void DgvHaspKey_SelectionChanged(object sender, EventArgs e)
        {
            if (!size)
                FillInputItem();
        }

        private void FillInputItem()
        {
            var row = dgvHaspKey.CurrentRow.DataBoundItem as ModelViewHaspKey;

            presenterHaspKey.HaspKey.Id = row.Id;
            tbInnerNumber.Text = row.InnerId.ToString();
            tbNumber.Text = row.Number;
            comboBoxTypeKey.SelectedIndex = (int)row.TypeKey;
            checkBoxIsHome.Checked = row.IsHome;
        }
    }
}
