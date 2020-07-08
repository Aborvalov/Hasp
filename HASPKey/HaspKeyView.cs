﻿using Entities;
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
    public partial class HaspKeyView : DevExpress.XtraEditors.XtraForm, IHaspKeyView
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
        
        private string innerNumber;
        public string InnerNumber
        {
            get { return innerNumber; }
            set
            {
                innerNumber = value;
                tbInnerNumber.Text = value;
            }
        }
        private string number;
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                tbNumber.Text = value;
            }
        }
        private TypeKey typeKey;
        public TypeKey TypeKey
        {
            get { return typeKey; }
            set
            {
                typeKey = value;
                comboBoxTypeKey.SelectedIndex = (int)value;
            }
        }
        private bool isHome;
        public bool IsHome
        {
            get { return isHome; }
            set
            {
                isHome = value;
                checkBoxIsHome.Checked = value;
            }
        }                     
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

        public void Bind(List<ModelViewHaspKey> entity) 
        => bindingHaspKey.DataSource = entity != null ? new BindingList<ModelViewHaspKey>(entity)
                                                      : new BindingList<ModelViewHaspKey>();

        public void DataChange() => DateUpdate?.Invoke();

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
                presenterHaspKey.FillModel();
                DefaultView();
            }
        }

        private void DgvHaspKey_DoubleClick(object sender, EventArgs e)
        {
            if (!(dgvHaspKey.CurrentRow.DataBoundItem is ModelViewHaspKey row))
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
                dgvHaspKey.Height = dgvHaspKey.Size.Height - sizeH;
                size = !size;
                presenterHaspKey.FillInputItem(row);
                buttonAdd.Enabled = false;
            }            
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
                presenterHaspKey.Remove(row.Id);
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

        private void DgvHaspKey_CellClick(object sender, DataGridViewCellEventArgs e) => FillDate();

        private void DgvHaspKey_SelectionChanged(object sender, EventArgs e) => FillDate();

        private void FillDate()
        {
            if (!size)
            {
                if (!(dgvHaspKey.CurrentRow.DataBoundItem is ModelViewHaspKey row))
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

        private void TbInnerNumber_TextChanged(object sender, EventArgs e) => InnerNumber = tbInnerNumber.Text;

        private void TbNumber_TextChanged(object sender, EventArgs e) => Number = tbNumber.Text;

        private void ComboBoxTypeKey_SelectionChangeCommitted(object sender, EventArgs e) => TypeKey = (TypeKey)comboBoxTypeKey.SelectedItem;

        private void CheckBoxIsHome_CheckedChanged(object sender, EventArgs e) => IsHome = checkBoxIsHome.Checked;
    }
}
