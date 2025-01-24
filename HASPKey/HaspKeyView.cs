using Entities;
using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class HaspKeyView : DevExpress.XtraEditors.XtraForm, IEntitiesView<ModelViewHaspKey>
    {
        private readonly IHaspKeyPresenter presenterHaspKey;
        public ModelViewClient client;
        private bool size = true;
        private bool error = false;
        private const int sizeH = 40;
        public LevelAccess DataAccess;
        public event Action DataUpdated;
        internal ModelViewHaspKey SearchHaspKey { get; private set; } = null;

        private const string errorStr = "Ошибка";
        private const string caption = "Удалить ключ";
        private const string emptyHaspKey = "Данный ключ не найден.";
        private const string message = "Вы уверены, что хотите удалить Hasp-ключ?";

        private void SetRadioButtonsVisibility(bool visibility)
        {
            radioButtonActive.Visible = visibility;
            radioButtonAll.Visible = visibility;
            radioButtonPastDue.Visible = visibility;
        }

        public HaspKeyView()
        {
            InitializeComponent();
            presenterHaspKey = new HaspKeyPresenter(this);
            DataGridViewHaspKey.Height = DataGridViewHaspKey.Size.Height + sizeH;

            comboBoxTypeKey.DataSource = Enum.GetValues(typeof(TypeKey));
            comboBoxTypeKey.SelectedIndex = -1;
            labelClient.Text = string.Empty;

            DataGridViewHaspKey.Height = DataGridViewHaspKey.Size.Height + 28;
        }

        public HaspKeyView(LevelAccess dataAccess)
        {
            InitializeComponent();
            presenterHaspKey = new HaspKeyPresenter(this);
            DataGridViewHaspKey.Height = DataGridViewHaspKey.Size.Height + sizeH;

            comboBoxTypeKey.DataSource = Enum.GetValues(typeof(TypeKey));
            comboBoxTypeKey.SelectedIndex = -1;
            labelClient.Text = string.Empty;
            DataAccess = dataAccess;

            if (DataAccess == LevelAccess.superadmin)
            {
                DataGridViewHaspKey.Height = DataGridViewHaspKey.Size.Height - 28;
                buttonCancel.Visible = true;
            }
            DataGridViewHaspKey.Height = DataGridViewHaspKey.Size.Height + 28;

            if (DataAccess == LevelAccess.admin) buttonCancel.Visible = false;

            if (DataAccess == LevelAccess.user)
            {
                buttonAdd.Enabled = false;
                buttonCancel.Enabled = false;
                buttonCancel.Visible = false;
                buttonDelete.Enabled = false;
                buttonSave.Enabled = false;
            }
        }

        public void Bind(List<ModelViewHaspKey> entity)
            => bindingHaspKey.DataSource = entity != null ? new BindingList<ModelViewHaspKey>(entity)
                                                          : new BindingList<ModelViewHaspKey>();

        public void BindItem(ModelViewHaspKey entity)
           => bindingItem.DataSource = entity ?? new ModelViewHaspKey();

        public void DataChange() => DataUpdated?.Invoke();

        private void RadioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            DefaultView();
            if (client != null)
            {
                presenterHaspKey.GetAllInCompany(client);
                labelClient.Text = client.Name;
            }
        }

        private void RadioButtonActive_CheckedChanged(object sender, EventArgs e)
        {
            DefaultView();
            if (DataAccess == LevelAccess.user) buttonAdd.Enabled = false;
            if (client != null)
            {
                presenterHaspKey.GetActiveInCompany(client);
                labelClient.Text = client.Name;
            }

        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                DataGridViewHaspKey.Height = DataGridViewHaspKey.Size.Height - sizeH;
                size = !size;
                buttonAdd.Enabled = false;
                checkBoxIsHome.Checked = true;
            }
        }

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = true;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (size)
                return;

            error = false;
            presenterHaspKey.FillModel(bindingItem.DataSource as ModelViewHaspKey);
            if (!error)
                DefaultView();
        }

        private void DataGridViewHaspKey_DoubleClick(object sender, EventArgs e)
        {
            if (!(DataGridViewHaspKey.CurrentRow.DataBoundItem is ModelViewHaspKey row))
            {
                MessageError(emptyHaspKey);
                return;
            }
            if (size)
            {
                DefaultView();
                DataGridViewHaspKey.Height = DataGridViewHaspKey.Size.Height - sizeH;
                size = !size;
                presenterHaspKey.FillInputItem(row);
                buttonAdd.Enabled = false;
            }
        }

        private void DefaultView()
        {
            if (!size)
            {
                DataGridViewHaspKey.Height = DataGridViewHaspKey.Size.Height + sizeH;
                size = !size;
            }

            bindingItem.DataSource = new ModelViewHaspKey();
            presenterHaspKey.FillInputItem(bindingItem.DataSource as ModelViewHaspKey);
            tbInnerNumber.Text = string.Empty;
            comboBoxTypeKey.SelectedIndex = -1;
            labelClient.Text = string.Empty;
            buttonAdd.Enabled = true;
        }

        private void ButtonDelete_Click(object sender, EventArgs e) => DeleteItem();

        private void ButtonSearchByClient_Click(object sender, EventArgs e)
        {
            SetRadioButtonsVisibility(true);

            using (ClientView client = new ClientView(true))
            {
                client.ShowDialog();

                if (client.SearchIdClient != null)
                {
                    this.client = client.SearchIdClient;
                    DefaultView();
                    if (DataAccess == LevelAccess.user)
                    {
                        buttonAdd.Enabled = false;
                    }
                    presenterHaspKey.GetByClient(this.client);

                    labelClient.Text = this.client.Name;
                    labelClient.Location = new System.Drawing.Point((this.Width - 25) - labelClient.Width, labelClient.Location.Y);
                }
            }
        }

        private void RadioButtonPastDue_CheckedChanged(object sender, EventArgs e)
        {
            DefaultView();
            if (DataAccess == LevelAccess.user) buttonAdd.Enabled = false;
            if (client != null)
            {
                presenterHaspKey.GetByPastDue(client);
                labelClient.Text = client.Name;
            }
        }

        private void DataGridViewHaspKey_CellClick(object sender, DataGridViewCellEventArgs e) => FillDate();

        private void DataGridViewHaspKey_SelectionChanged(object sender, EventArgs e) => FillDate();

        private void FillDate()
        {
            if (!size)
            {
                if (!(DataGridViewHaspKey.CurrentRow.DataBoundItem is ModelViewHaspKey row))
                {
                    MessageError(emptyHaspKey);
                    return;
                }
                presenterHaspKey.FillInputItem(row);
            }
        }

        private void TbInnerNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void DataGridViewHaspKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteItem();
        }

        private void DeleteItem()
        {
            if (!(DataGridViewHaspKey.CurrentRow.DataBoundItem is ModelViewHaspKey row))
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
                presenterHaspKey.Remove(row.Id);
                DefaultView();
            }
        }

        private void DataGridViewHaspKey_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DataGridViewHaspKey.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DefaultView();
        }

        private void ButtonAllKeys_Click(object sender, EventArgs e)
        {
            SetRadioButtonsVisibility(false);
            DefaultView();
            if (DataAccess == LevelAccess.user) buttonAdd.Enabled = false;
            presenterHaspKey.Display();
            labelClient.Text = string.Empty;
        }
    }
}