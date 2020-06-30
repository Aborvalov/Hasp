using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using ModelEntities;
using Presenter;
using View;

namespace HASPKey
{
    public partial class HaspKeyView : DevExpress.XtraEditors.XtraForm, IEntitesView<ModelViewHaspKey>
    {
        private readonly IPresenterHaspKey presenterHaspKey;
        private bool size = true;
        private const int sizeH = 40;

        public HaspKeyView()
        {
            InitializeComponent();
            presenterHaspKey = new PresenterHaspKey(this);
            dgvHaspKey.Height = dgvHaspKey.Size.Height + sizeH;
            comboBoxTypeKey.DataSource = Enum.GetValues(typeof(Entities.TypeKey));
            comboBoxTypeKey.SelectedIndex = -1;
        }

        public bool Add(ModelViewHaspKey entity)
        {
            throw new NotImplementedException();
        }

        public void Build(List<ModelViewHaspKey> homes) => bindingHaspKey.DataSource = homes != null ? new BindingList<ModelViewHaspKey>(homes)
                                                      : new BindingList<ModelViewHaspKey>();

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ModelViewHaspKey entity)
        {           
            throw new NotImplementedException();
        }

        private void RadioButtonAll_CheckedChanged(object sender, EventArgs e) => presenterHaspKey.View();

        private void RadioButtonPastDue_CheckedChanged(object sender, EventArgs e) => presenterHaspKey.GetByPastDue();


        private void RadioButtonActive_CheckedChanged(object sender, EventArgs e) => presenterHaspKey.GetByActive();

        private void ButtonAdd_Click(object sender, EventArgs e)
        {            
            if (size)
            {
                dgvHaspKey.Height = dgvHaspKey.Size.Height - sizeH;
                size = !size;
            }

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
                presenterHaspKey.Remove(row.Id);
        }

        public void MessageError(string error) => MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!size)
            {
                ModelViewHaspKey haspKey = new ModelViewHaspKey();

                string innerNumber = tbInnerNumber.Text;
                string erroeMess = string.Empty;
                bool isInt = Int32.TryParse(tbInnerNumber.Text, out int innNumber);

                if (isInt)
                    haspKey.InnerId = Convert.ToInt32(innerNumber);
                else
                {
                    erroeMess = '\u2022' + " Неверное значение внутреннего ключа, должно быть числом." + '\n';
                    tbInnerNumber.Text = string.Empty;
                }

                if (comboBoxTypeKey.SelectedItem == null)
                    erroeMess += '\u2022' + " Не выбран тип ключа." + '\n';

                if (string.IsNullOrWhiteSpace(tbNumber.Text))
                    erroeMess += '\u2022' + " Не заполнено поля \"Номер\"." + '\n';

                if (erroeMess != string.Empty)
                {
                    MessageError(erroeMess.Trim());
                    return;
                }


                haspKey.Number = tbNumber.Text.Trim();
                haspKey.TypeKey = (TypeKey)comboBoxTypeKey.SelectedItem;
                haspKey.IsHome = checkBoxIsHome.Checked;

                presenterHaspKey.Add(haspKey);


                dgvHaspKey.Height = dgvHaspKey.Size.Height + sizeH;
                size = !size;


                tbInnerNumber.Text = string.Empty;
                tbNumber.Text = string.Empty;
                comboBoxTypeKey.SelectedIndex = -1;
                checkBoxIsHome.Checked = false;

                presenterHaspKey.View();
            }
        }
    }
}
