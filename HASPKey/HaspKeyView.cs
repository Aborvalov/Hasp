using Entities;
using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
        
        private const string error = "Ошибка";
        private const string caption = "Удалить ключ";
        private const string emptyHaspKey = "Данный ключ не найден.";
        private const string message = "Вы уверены, что хотите удалить Hasp-ключ?";
        private const string errorHaspKey = "\u2022 Неверное значение внутреннего ключа, должно быть числом. \n";
        private const string errorEmptyTypeKey =  "\u2022 Не выбран тип ключа. \n";
        private const string errorEmptyNumber = "\u2022 Не заполнено поля \"Номер\", не должно быть пустым. \n";
        
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
            presenterHaspKey.Display();
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
                presenterHaspKey.Entities = new ModelViewHaspKey();
                buttonAdd.Enabled = false;
            }            
        }
        public void MessageError(string errorText) => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!size)
            {                           
                if (!CheckInputData(out int innNumber))
                    return;

                presenterHaspKey.Entities.InnerId = innNumber;
                presenterHaspKey.Entities.Number = tbNumber.Text.Trim();
                presenterHaspKey.Entities.TypeKey = (TypeKey)comboBoxTypeKey.SelectedItem;
                presenterHaspKey.Entities.IsHome = checkBoxIsHome.Checked;

                if(presenterHaspKey.Entities.Id < 1)
                    Add(presenterHaspKey.Entities);                
                else
                    Update(presenterHaspKey.Entities);

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

            presenterHaspKey.Entities = new ModelViewHaspKey();
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
            string errorMess = string.Empty;
            
            if (!int.TryParse(tbInnerNumber.Text, out innNumber))
            {
                errorMess = errorHaspKey;
                tbInnerNumber.Text = string.Empty;
            }

            if (comboBoxTypeKey.SelectedItem == null)
                errorMess += errorEmptyTypeKey;

            if (string.IsNullOrWhiteSpace(tbNumber.Text))
                errorMess += errorEmptyNumber;

            if (errorMess != string.Empty)
            {
                MessageError(errorMess.Trim());
                return false;
            }

            return true;
        }
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!(dgvHaspKey.CurrentRow.DataBoundItem is ModelViewHaspKey row))
            {
                MessageError(emptyHaspKey);
                return;
            }

            if (row.Id == 0)
            {
                bindingHaspKey.RemoveCurrent();
                return;
            }
            
            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

            using (ClientView client = new ClientView(true))
            {
                client.ShowDialog();

                if (client.SearchIdClient != null)
                {
                    DefaultView();
                    presenterHaspKey.GetByClient(client.SearchIdClient);

                    labelClient.Text = client.SearchIdClient.Name;
                    labelClient.Location = new System.Drawing.Point((this.Width - 25) - labelClient.Width, labelClient.Location.Y);
                }
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
            if (!(dgvHaspKey.CurrentRow.DataBoundItem is ModelViewHaspKey row))
            {
                MessageError(emptyHaspKey);
                return;
            }

            presenterHaspKey.Entities.Id = row.Id;
            tbInnerNumber.Text = row.InnerId.ToString();
            tbNumber.Text = row.Number;
            comboBoxTypeKey.SelectedIndex = (int)row.TypeKey;
            checkBoxIsHome.Checked = row.IsHome;
        }

        private void TbInnerNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
