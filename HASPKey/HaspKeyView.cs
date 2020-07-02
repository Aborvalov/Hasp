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
    public partial class HaspKeyView : DevExpress.XtraEditors.XtraForm, IEntitesView<ModelViewHaspKey>
    {
        private readonly IPresenterHaspKey presenterHaspKey;
        private bool size = true;
        private const int sizeH = 40;
        private ModelViewHaspKey haspKey = null;
        private readonly int labelClientHeight;
        private readonly int labelClientWidth;
        public event Action DateUpdate;
        public HaspKeyView()
        {
            InitializeComponent();
            presenterHaspKey = new PresenterHaspKey(this);
            dgvHaspKey.Height = dgvHaspKey.Size.Height + sizeH;
            comboBoxTypeKey.DataSource = Enum.GetValues(typeof(Entities.TypeKey));
            comboBoxTypeKey.SelectedIndex = -1;

            labelClient.Text = string.Empty;
            labelClientHeight = labelClient.Location.Y;
            labelClientWidth = labelClient.Location.X;
        }

        public void Add(ModelViewHaspKey entity)
        {
            presenterHaspKey.Add(entity);
            DateUpdate?.Invoke();
        }

        public void Build(List<ModelViewHaspKey> entity) => bindingHaspKey.DataSource = entity != null ? new BindingList<ModelViewHaspKey>(entity)
                                                      : new BindingList<ModelViewHaspKey>();

        public void Remove(int id) => presenterHaspKey.Remove(id);

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
            }
            haspKey = new ModelViewHaspKey();
        }
        public void MessageError(string error) => MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!size)
            {                           
                if (!CheckInputData(out int innNumber))
                    return;

                haspKey.InnerId = innNumber;
                haspKey.Number = tbNumber.Text.Trim();
                haspKey.TypeKey = (TypeKey)comboBoxTypeKey.SelectedItem;
                haspKey.IsHome = checkBoxIsHome.Checked;

                if(haspKey.Id < 1)
                    Add(haspKey);                
                else
                    Update(haspKey);

                DefaultView();
            }
        }

        private void DgvHaspKey_DoubleClick(object sender, EventArgs e)
        {
            if (size)
            {
                dgvHaspKey.Height = dgvHaspKey.Size.Height - sizeH;
                size = !size;
            }

            haspKey = new ModelViewHaspKey();                
            var row = dgvHaspKey.CurrentRow.DataBoundItem as ModelViewHaspKey;

            haspKey.Id = row.Id;
            tbInnerNumber.Text = row.InnerId.ToString();
            tbNumber.Text = row.Number;
            comboBoxTypeKey.SelectedIndex = (int)row.TypeKey;
            checkBoxIsHome.Checked = row.IsHome;            
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

            DefaultView();

            labelClient.Location = new System.Drawing.Point(labelClientWidth, labelClientHeight);

            ClientView client = new ClientView(true);
            client.ShowDialog();

            if (client.SearchIdClient != null)
            {
                presenterHaspKey.GetByClient(client.SearchIdClient);
                
                labelClient.Text = client.SearchIdClient.Name;
                labelClient.Location = new System.Drawing.Point(labelClient.Location.X - labelClient.Width, labelClientHeight);
            }
        }
    }
}
