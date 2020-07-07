using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class KeyFeatureView : DevExpress.XtraEditors.XtraForm, IEntitiesView<ModelViewKeyFeature>
    {
        private readonly IPresenterEntities<ModelViewKeyFeature> presenterKeyFeature;
        private bool size = true;
        private int sizeH = 55;
        public event Action DateUpdate;
        
        private const string error = "Ошибка";
        private const string selectFeature = "Выбрать функциональность";
        private const string emptyKeyFeature = "Данная завпись не найдена.";
        private const string caption = "Удалить связку ключ-функциональность";
        private const string message = "Вы уверены, что хотите удалить связь ключ-функциональность?";
        private const string errorEmptyFeature = "\u2022 Не выбрана функциональность. \n";
        private const string errorEmptyHaspKey = "\u2022 Не выбран hasp ключ. \n";
        private const string errorDate = "\u2022 Дата окончания действия меньше даты начала действия. \n";
        private const string errorKeyFeature = "\u2022 Данный ключ имеет действующую выбранную функциональность. \n";
        
        public KeyFeatureView()
        {
            InitializeComponent();
            presenterKeyFeature = new PresenterKeyFeature(this);
            dgvKeyFeture.Height = dgvKeyFeture.Size.Height + sizeH;
           
            DefaultView();

            ToolTip t = new ToolTip();
            t.SetToolTip(buttonSelectFeature, selectFeature);
        }

        public void Add(ModelViewKeyFeature entity)
        {
            presenterKeyFeature.Add(entity);
            DateUpdate?.Invoke();
        }

        public void Bind(List<ModelViewKeyFeature> entity) 
        => bindingKeyFeature.DataSource = entity != null ? new BindingList<ModelViewKeyFeature>(entity)
                                                         : new BindingList<ModelViewKeyFeature>();

        public void MessageError(string errorText) => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void Remove(int id)
        {
            presenterKeyFeature.Remove(id);
            DateUpdate?.Invoke();
        }

        public void Update(ModelViewKeyFeature entity)
        {
            presenterKeyFeature.Update(entity);
            DateUpdate?.Invoke();
        }

        private void Button1Delete_Click(object sender, EventArgs e)
        {
            if (!(dgvKeyFeture.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
            {
                MessageError(emptyKeyFeature);
                return;
            }            
            if (row.Id == 0)
            {
                bindingKeyFeature.RemoveCurrent();
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
                dgvKeyFeture.Height = dgvKeyFeture.Size.Height + sizeH;
                size = !size;
            }

            dtpEndDate.MinDate = DateTime.Now.Date;
            labelStartDate.Visible = false;
            labelEndDate.Visible = false;
            dtpStartDate.Visible = false;
            dtpEndDate.Visible = false;
            labelSelectFeature.Text = string.Empty;
            labelSelectKey.Text = string.Empty;
        }

        private void DgvKeyFeture_DoubleClick(object sender, EventArgs e)
        {
            DefaultView();
            if (!size)
                return;

            dgvKeyFeture.Height = dgvKeyFeture.Size.Height - sizeH;
            size = !size;
            labelStartDate.Visible = true;
            labelEndDate.Visible = true;
            dtpStartDate.Visible = true;
            dtpEndDate.Visible = true;

            FillInputItem();
        }

        private void FillInputItem()
        {
            if (!(dgvKeyFeture.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
            {
                MessageError(emptyKeyFeature);
                return;
            }
            presenterKeyFeature.Entities = new ModelViewKeyFeature
            {
                Id = row.Id,
                IdFeature = row.IdFeature,
                IdHaspKey = row.IdHaspKey
            };
            dtpStartDate.Value = row.StartDate;
            dtpEndDate.MinDate = new DateTime(1753, 1, 1);
            dtpEndDate.Value = row.EndDate;
            labelSelectFeature.Text = row.Feature;
            labelSelectKey.Text = row.NumberKey;
        }

        private void DtpStartDate_ValueChanged(object sender, EventArgs e) => dtpEndDate.MinDate = dtpStartDate.Value;
        
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                dgvKeyFeture.Height = dgvKeyFeture.Size.Height - sizeH;               
                labelEndDate.Visible = true;
                dtpEndDate.Visible = true;
                size = !size;
                presenterKeyFeature.Entities = new ModelViewKeyFeature();
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (size || 
                presenterKeyFeature.Entities == null ||
                !CheckInputData())
                return;
            
            presenterKeyFeature.Entities.EndDate = dtpEndDate.Value.Date;

            if (presenterKeyFeature.Entities.Id < 1)
            {
                Add(presenterKeyFeature.Entities);
                dgvKeyFeture.Height = dgvKeyFeture.Size.Height - 20;
            }
            else
            {
                presenterKeyFeature.Entities.StartDate = dtpStartDate.Value.Date;
                Update(presenterKeyFeature.Entities);
            }

            DefaultView();            
        }
        private bool CheckInputData()
        {
            string errorMess = string.Empty;

            if (presenterKeyFeature.Entities.IdFeature < 1)
                errorMess += errorEmptyFeature;
            if (presenterKeyFeature.Entities.IdHaspKey < 1)
                errorMess += errorEmptyHaspKey;
            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
                errorMess += errorDate;

            foreach (DataGridViewRow row in dgvKeyFeture.Rows)
            {
                var item = row.DataBoundItem as ModelViewKeyFeature;
                if (item.Id != presenterKeyFeature.Entities.Id &&
                    item.IdHaspKey == presenterKeyFeature.Entities.IdHaspKey &&
                    item.IdFeature == presenterKeyFeature.Entities.IdFeature &&
                    item.EndDate >= dtpStartDate.Value.Date)
                {
                    errorMess += errorKeyFeature;
                    break;
                }
            }

            if (errorMess != string.Empty)
            {
                MessageError(errorMess.Trim());
                return false;
            }

            return true;
        }
        private void ButtonSelectFeature_Click(object sender, EventArgs e)
        {
            using (FeatureView feature = new FeatureView(true))
            {
                feature.ShowDialog();

                if (feature.SearchFeature != null)
                {
                    presenterKeyFeature.Entities.IdFeature = feature.SearchFeature.Id;
                    labelSelectFeature.Text = feature.SearchFeature.Name;
                }
            }
        }

        private void ButtonSelectKey_Click(object sender, EventArgs e)
        {
            using (HaspKeyView haspKey = new HaspKeyView(true))
            {
                haspKey.ShowDialog();

                if (haspKey.SearchHaspKey != null)
                {
                    presenterKeyFeature.Entities.IdHaspKey = haspKey.SearchHaspKey.Id;
                    labelSelectKey.Text = haspKey.SearchHaspKey.InnerId + " - \"" + haspKey.SearchHaspKey.Number + "\"";
                }
            }
        }

        private void DgvKeyFeture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!size)
                FillInputItem();
        }
        private void DgvKeyFeture_SelectionChanged(object sender, EventArgs e)
        {
            if (!size)
                FillInputItem();
        }
    }
}
