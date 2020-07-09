using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class KeyFeatureView : DevExpress.XtraEditors.XtraForm, IKeyFeatureView
    {
        private readonly IPresenterEntities<ModelViewKeyFeature> presenterKeyFeature;
        private bool size = true;
        private int sizeH = 55;
        public event Action DataUpdated;
        
        private const string error = "Ошибка";
        private const string selectFeature = "Выбрать функциональность";
        private const string emptyKeyFeature = "Данная завпись не найдена.";
        private const string caption = "Удалить связку ключ-функциональность";
        private const string message = "Вы уверены, что хотите удалить связь ключ-функциональность?";
        
        private DateTime startDate;
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                dtpStartDate.Value = value;
            }
        }
        private DateTime endDate;
        public DateTime EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                dtpEndDate.Value = value;
            }
        }
        private ModelViewHaspKey haspKey;
        public ModelViewHaspKey HaspKey
        {
            get { return haspKey; }
            set
            {
                haspKey = value;
                labelSelectKey.Text = value.InnerId + " - \"" + value.Number + "\"";
            }
        }
        private ModelViewFeature feature;
        public ModelViewFeature Feature
        {
            get { return feature; }
            set
            {
                feature = value;
                labelSelectFeature.Text = value.Name;
            }
        }

        public KeyFeatureView()
        {
            InitializeComponent();
            presenterKeyFeature = new PresenterKeyFeature(this);
            dgvKeyFeature.Height = dgvKeyFeature.Size.Height + sizeH;
           
            DefaultView();

            ToolTip t = new ToolTip();
            t.SetToolTip(buttonSelectFeature, selectFeature);
        }
               
        public void Bind(List<ModelViewKeyFeature> entity) 
        => bindingKeyFeature.DataSource = entity != null ? new BindingList<ModelViewKeyFeature>(entity)
                                                         : new BindingList<ModelViewKeyFeature>();

        public void MessageError(string errorText) => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
        public void DataChange() => DataUpdated?.Invoke();

        private void Button1Delete_Click(object sender, EventArgs e)
        {
            if (!(dgvKeyFeature.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
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
                presenterKeyFeature.Remove(row.Id);
                DefaultView();
            }
        }

        private void DefaultView()
        {
            if (!size)
            {
                dgvKeyFeature.Height = dgvKeyFeature.Size.Height + sizeH;
                size = !size;
            }

            dtpEndDate.MinDate = new DateTime(1753, 1, 1);
            dtpEndDate.MinDate = DateTime.Now.Date;
            labelStartDate.Visible = false;
            labelEndDate.Visible = false;
            dtpStartDate.Visible = false;
            dtpEndDate.Visible = false;
            labelSelectFeature.Text = string.Empty;
            labelSelectKey.Text = string.Empty;
            buttonAdd.Enabled = true;
        }

        private void DgvKeyFeture_DoubleClick(object sender, EventArgs e)
        {
            if (!(dgvKeyFeature.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
            {
                MessageError(emptyKeyFeature);
                return;
            }
                        
            if (!size)
                return;
            DefaultView();

            dgvKeyFeature.Height = dgvKeyFeature.Size.Height - sizeH;
            size = !size;
            labelStartDate.Visible = true;
            labelEndDate.Visible = true;
            dtpStartDate.Visible = true;
            dtpEndDate.Visible = true;
            buttonAdd.Enabled = false;
            presenterKeyFeature.FillInputItem(row);
        }
               
        private void DtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
            StartDate = dtpStartDate.Value;
        }
        
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (!(dgvKeyFeature.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
            {
                MessageError(emptyKeyFeature);
                return;
            }

            DefaultView();
            if (size)
            {
                dgvKeyFeature.Height = dgvKeyFeature.Size.Height - sizeH;               
                labelEndDate.Visible = true;
                dtpEndDate.Visible = true;
                size = !size;
                buttonAdd.Enabled = false;
                presenterKeyFeature.Entities = new ModelViewKeyFeature();
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (size)
                return;
                        
            if (presenterKeyFeature.Entities.Id < 1)
                dgvKeyFeature.Height = dgvKeyFeature.Size.Height - 20;
            /*
             * 
             * 
             * 
             * 
             * */
            presenterKeyFeature.FillModel(null);
            DefaultView();            
        }
        
        private void ButtonSelectFeature_Click(object sender, EventArgs e)
        {
            using (FeatureView feature = new FeatureView(true))
            {
                feature.ShowDialog();

                if (feature.SearchFeature != null)
                    Feature = feature.SearchFeature;                
            }
        }

        private void ButtonSelectKey_Click(object sender, EventArgs e)
        {
            using (HaspKeyView haspKey = new HaspKeyView(true))
            {
                haspKey.ShowDialog();

                if (haspKey.SearchHaspKey != null)
                    HaspKey = haspKey.SearchHaspKey;
            }
        }

        private void DgvKeyFeture_CellClick(object sender, DataGridViewCellEventArgs e) => FillDate();
        private void DgvKeyFeture_SelectionChanged(object sender, EventArgs e) => FillDate();
        private void FillDate()
        {
            if (!size)
            {
                if (!(dgvKeyFeature.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
                {
                    MessageError(emptyKeyFeature);
                    return;
                }
                presenterKeyFeature.FillInputItem(row);
            }
        }

        private void DtpEndDate_ValueChanged(object sender, EventArgs e) => EndDate = dtpEndDate.Value;
    }
}
