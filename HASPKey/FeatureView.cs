using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class FeatureView : DevExpress.XtraEditors.XtraForm, IEntitesView<ModelViewFeature>
    {
        private readonly IPresenterEntites<ModelViewFeature> presenterFeature;
        private bool size = true;
        private int sizeH = 40;
        private ModelViewFeature feature = null;
        private bool search = false;
        internal ModelViewFeature SearchIdFeature { get; private set; }

        public FeatureView(bool search)
        {
            InitializeComponent();
            presenterFeature = new PresenterFeature(this);
            dgvFeature.Height = dgvFeature.Size.Height + sizeH;
            this.search = search;
            
            if (this.search)
                dgvFeature.Height = dgvFeature.Size.Height + 28;
        }
        public FeatureView() : this(false)
        { }

        public void Add(ModelViewFeature entity) => presenterFeature.Add(entity);

        public void Build(List<ModelViewFeature> entity) => bindingFeature.DataSource = entity != null ? new BindingList<ModelViewFeature>(entity)
                                                      : new BindingList<ModelViewFeature>();

        public void MessageError(string error) => MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void Remove(int id) => presenterFeature.Remove(id);

        public void Update(ModelViewFeature entity) => presenterFeature.Update(entity);

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                dgvFeature.Height = dgvFeature.Size.Height - sizeH;
                size = !size;
            }
            feature = new ModelViewFeature();
        }

        private void DgvFeature_DoubleClick(object sender, EventArgs e)
        {
            if (this.search)
            {
                this.SearchIdFeature = dgvFeature.CurrentRow.DataBoundItem as ModelViewFeature;
                this.Close();
                return;
            }

            if (size)
            {
                dgvFeature.Height = dgvFeature.Size.Height - sizeH;
                size = !size;
            }

            feature = new ModelViewFeature();
            var row = dgvFeature.CurrentRow.DataBoundItem as ModelViewFeature;

            feature.Id = row.Id;
            tbNumber.Text = row.Number.ToString();
            tbName.Text = row.Name;
            tbDescription.Text = row.Description;
        }        
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!size)
            {
                if (!CheckInputData(out int number))
                    return;

                feature.Number = number;
                feature.Name = tbName.Text;
                feature.Description = tbDescription.Text;

                if (feature.Id < 1)
                    Add(feature);
                else
                    Update(feature);

                DefaultView();
            }
        }
        private bool CheckInputData(out int number)
        {
            string erroeMess = string.Empty;
            bool isInt = Int32.TryParse(tbNumber.Text, out number);

            if (!isInt)
            {
                erroeMess = '\u2022' + " Неверное значение номера, должно быть числом." + '\n';
                tbNumber.Text = string.Empty;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text))
                erroeMess += '\u2022' + " Не заполнено поля \"Наименование\", не должно быть пустым." + '\n';

            if (erroeMess != string.Empty)
            {
                MessageError(erroeMess.Trim());
                return false;
            }

            return true;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            var row = dgvFeature.CurrentRow.DataBoundItem as ModelViewFeature;
            if (row.Id == 0)
            {
                bindingFeature.RemoveCurrent();
                return;
            }

            string caption = "Удалить фичу";
            string message = "Вы уверены, что хотите удалить фичу?";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Remove(row.Id);
                DefaultView();
            }
        }
        private void DefaultView()
        {
            if (!size)
            {
                dgvFeature.Height = dgvFeature.Size.Height + sizeH;
                size = !size;
            }
            tbNumber.Text = string.Empty;
            tbName.Text = string.Empty;
            tbDescription.Text = string.Empty;
        }
    }
}
