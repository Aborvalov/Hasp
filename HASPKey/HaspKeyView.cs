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
        public event Action DataUpdated;
        private bool search = false;
        internal ModelViewHaspKey SearchHaspKey { get; private set; } = null;
        
        private const string error = "Ошибка";
        private const string caption = "Удалить ключ";
        private const string emptyHaspKey = "Данный ключ не найден.";
        private const string message = "Вы уверены, что хотите удалить Hasp-ключ?";
                    
        public HaspKeyView()
        {
            InitializeComponent();
            presenterHaspKey = new PresenterHaspKey(this);
            DataGridViewHaspKey.Height = DataGridViewHaspKey.Size.Height + sizeH;
            
            comboBoxTypeKey.DataSource = Enum.GetValues(typeof(TypeKey));
            comboBoxTypeKey.SelectedIndex = -1;
            labelClient.Text = string.Empty;
        }
        public HaspKeyView(bool search) : this()
        {
            this.search = search;
            DataGridViewHaspKey.Height = DataGridViewHaspKey.Size.Height + 28;
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
            presenterHaspKey.Display();
            labelClient.Text = string.Empty;
        }
        private void RadioButtonPastDue_CheckedChanged(object sender, EventArgs e)
        {
            DefaultView();
            presenterHaspKey.GetByPastDue();
            labelClient.Text = string.Empty;
        }
        private void RadioButtonActive_CheckedChanged(object sender, EventArgs e)
        {
            DefaultView();
            presenterHaspKey.GetByActive();
            labelClient.Text = string.Empty;
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                DataGridViewHaspKey.Height = DataGridViewHaspKey.Size.Height - sizeH;
                size = !size;               
                buttonAdd.Enabled = false;
            }            
        }
        public void MessageError(string errorText)
            => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (size)
                return;

            presenterHaspKey.FillModel(bindingItem.DataSource as ModelViewHaspKey);
            DefaultView();            
        }

        private void DataGridViewHaspKey_DoubleClick(object sender, EventArgs e)
        {
            if (!(DataGridViewHaspKey.CurrentRow.DataBoundItem is ModelViewHaspKey row))
            {
                MessageError(emptyHaspKey);
                return;
            }
            if (search)
            {
                SearchHaspKey = row;
                Close();
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
    }
}
