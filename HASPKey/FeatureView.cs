using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class FeatureView : DevExpress.XtraEditors.XtraForm, IEntitiesView<ModelViewFeature>
    {
        private readonly IPresenterEntities<ModelViewFeature> presenterFeature;
        private bool size = true;
        private int sizeH = 40;       
        private bool search = false;
        public event Action DateUpdate;
        internal ModelViewFeature SearchFeature { get; private set; } = null;
        
        private const string error = "Ошибка";
        private const string emptyFeature = "Функциональность не найдена.";
        private const string caption = "Удалить фичу";
        private const string message = "Вы уверены, что хотите удалить фичу?";
        private const string errorNumber = "\u2022 Неверное значение номера, должно быть числом. \n";
        private const string erroremptyName = "\u2022 Не заполнено поля \"Наименование\", не должно быть пустым. \n";
               
        public FeatureView(bool search) : this()
        { 
            this.search = search;            
            dgvFeature.Height = dgvFeature.Size.Height + 28;
        }
        public FeatureView() 
        {
            InitializeComponent();
            presenterFeature = new PresenterFeature(this);
            dgvFeature.Height = dgvFeature.Size.Height + sizeH;            
        }

        public void Add(ModelViewFeature entity)
        {
            presenterFeature.Add(entity);
            DateUpdate?.Invoke();
        }

        public void Bind(List<ModelViewFeature> entity) 
        => bindingFeature.DataSource = entity != null ? new BindingList<ModelViewFeature>(entity)
                                                      : new BindingList<ModelViewFeature>();

        public void MessageError(string errorText) => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void Remove(int id)
        {
            presenterFeature.Remove(id);
            DateUpdate?.Invoke();
        }

        public void Update(ModelViewFeature entity)
        {
            presenterFeature.Update(entity);
            DateUpdate?.Invoke();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                dgvFeature.Height = dgvFeature.Size.Height - sizeH;
                size = !size;
            }
            presenterFeature.Entities = new ModelViewFeature();
        }

        private void DgvFeature_DoubleClick(object sender, EventArgs e)
        {
            if (!(dgvFeature.CurrentRow.DataBoundItem is ModelViewFeature row))
            {
                MessageError(emptyFeature);
                return;
            }
            if (search)
            {
                SearchFeature = row;
                Close();
                return;
            }
                        
            if (size)
            {
                DefaultView();
                dgvFeature.Height = dgvFeature.Size.Height - sizeH;
                size = !size;
                FillInputItem(row);
            }
        }       

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (size)
                return;
          
            if (!CheckInputData(out int number))
                return;

            presenterFeature.Entities.Number = number;
            presenterFeature.Entities.Name = tbName.Text;
            presenterFeature.Entities.Description = tbDescription.Text;

            if (presenterFeature.Entities.Id < 1)
                Add(presenterFeature.Entities);
            else
                Update(presenterFeature.Entities);

            DefaultView();           
        }
        private bool CheckInputData(out int number)
        {
            string errorMess = string.Empty;
           
            if (!int.TryParse(tbNumber.Text, out number))
            {
                errorMess = errorNumber;
                tbNumber.Text = string.Empty;
            }
            if (string.IsNullOrWhiteSpace(tbName.Text))
                errorMess += erroremptyName;

            if (errorMess != string.Empty)
            {
                MessageError(errorMess.Trim());
                return false;
            }

            return true;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!(dgvFeature.CurrentRow.DataBoundItem is ModelViewFeature row))
            {
                MessageError(emptyFeature);
                return;
            }
            if (row.Id == 0)
            {
                bindingFeature.RemoveCurrent();
                return;
            }
            
            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void DgvFeature_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!size)
                FillInputItem();
        }

        private void DgvFeature_SelectionChanged(object sender, EventArgs e)
        {
            if (!size)
                FillInputItem();
        }
        private void FillInputItem() => FillInputItem(dgvFeature.CurrentRow.DataBoundItem as ModelViewFeature);
        private void FillInputItem(ModelViewFeature row)
        {
            if (row == null)
                return;

            presenterFeature.Entities = new ModelViewFeature
            {
                Id = row.Id
            };
            tbNumber.Text = row.Number.ToString();
            tbName.Text = row.Name;
            tbDescription.Text = row.Description;
        }        
    }
}
