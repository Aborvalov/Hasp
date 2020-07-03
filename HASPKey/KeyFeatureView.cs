using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class KeyFeatureView : DevExpress.XtraEditors.XtraForm, IEntitesView<ModelViewKeyFeature>
    {
        private readonly IPresenterEntites<ModelViewKeyFeature> presenterKeyFeature;
        private bool size = true;
        private int sizeH = 55;
        private ModelViewKeyFeature keyFeature = null;
        public event Action DateUpdate;

        public KeyFeatureView()
        {
            InitializeComponent();
            presenterKeyFeature = new PresenterKeyFeature(this);
            dgvKeyFeture.Height = dgvKeyFeture.Size.Height + sizeH;
           
            DefaultView();

            ToolTip t = new ToolTip();
            t.SetToolTip(buttonSelectFeature, "Выбрать функциональность");
        }

        public void Add(ModelViewKeyFeature entity)
        {
            presenterKeyFeature.Add(entity);
            DateUpdate?.Invoke();
        }

        public void Build(List<ModelViewKeyFeature> entity) 
        => bindingKeyFeature.DataSource = entity != null ? new BindingList<ModelViewKeyFeature>(entity)
                                                         : new BindingList<ModelViewKeyFeature>();

        public void MessageError(string error) => MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            var row = dgvKeyFeture.CurrentRow.DataBoundItem as ModelViewKeyFeature;
            if (row.Id == 0)
            {
                bindingKeyFeature.RemoveCurrent();
                return;
            }

            string caption = "Удалить связку ключ-функциональность";
            string message = "Вы уверены, что хотите удалить связь ключ-функциональность?";
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
            if (size)
            {
                dgvKeyFeture.Height = dgvKeyFeture.Size.Height - sizeH;
                size = !size;
                labelStartDate.Visible = true;
                labelEndDate.Visible = true;
                dtpStartDate.Visible = true;
                dtpEndDate.Visible = true;
            }
                        
            keyFeature = new ModelViewKeyFeature();
            var row = dgvKeyFeture.CurrentRow.DataBoundItem as ModelViewKeyFeature;

            keyFeature.Id = row.Id;
            keyFeature.IdFeature = row.IdFeature;
            keyFeature.IdHaspKey = row.IdHaspKey;
            dtpStartDate.Value = row.StartDate;
            dtpEndDate.MinDate = new DateTime(1753, 1, 1);
            dtpEndDate.Value = row.EndDate;
            labelSelectFeature.Text = row.Feature;
            labelSelectKey.Text = row.NumberKey;
        }

        private void DtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.MinDate = dtpStartDate.Value;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            DefaultView();
            if (size)
            {
                dgvKeyFeture.Height = dgvKeyFeture.Size.Height - sizeH;               
                labelEndDate.Visible = true;
                dtpEndDate.Visible = true;
                size = !size;
            }
            
            keyFeature = new ModelViewKeyFeature();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!size && keyFeature != null)
            {
                if (!CheckInputData())
                    return;

                keyFeature.EndDate = dtpEndDate.Value.Date;

                if (keyFeature.Id < 1)
                {
                    Add(keyFeature);
                    dgvKeyFeture.Height = dgvKeyFeture.Size.Height - 20;
                }
                else
                {
                    keyFeature.StartDate = dtpStartDate.Value.Date;
                    Update(keyFeature);
                }

                DefaultView();
            }
        }
        private bool CheckInputData()
        {
            string erroeMess = string.Empty;

            if (keyFeature.IdFeature < 1)
                erroeMess += '\u2022' + " Не выбрана функциональность." + '\n';
            if (keyFeature.IdHaspKey < 1)
                erroeMess += '\u2022' + " Не выбран hasp ключ." + '\n';
            if (dtpStartDate.Value.Date > dtpEndDate.Value.Date)
                erroeMess += '\u2022' + " Дата окончания действия меньше даты начала действия." + '\n';

            foreach (DataGridViewRow row in dgvKeyFeture.Rows)
            {
                var item = row.DataBoundItem as ModelViewKeyFeature;
                if (item.Id != keyFeature.Id &&
                    item.IdHaspKey == keyFeature.IdHaspKey &&
                    item.IdFeature == keyFeature.IdFeature &&
                    item.EndDate >= dtpStartDate.Value.Date)
                {
                    erroeMess += '\u2022' + " Данный ключ имеет действующую выбранную функциональность." + '\n';
                    break;
                }
            }

            if (erroeMess != string.Empty)
            {
                MessageError(erroeMess.Trim());
                return false;
            }

            return true;
        }
        private void ButtonSelectFeature_Click(object sender, EventArgs e)
        {
            FeatureView feature = new FeatureView(true);
            feature.ShowDialog();

            if (feature.SearchFeature != null)
            {
                keyFeature.IdFeature = feature.SearchFeature.Id;
                labelSelectFeature.Text = feature.SearchFeature.Name;
            }
        }

        private void ButtonSelectKey_Click(object sender, EventArgs e)
        {
            HaspKeyView haspKey = new HaspKeyView(true);
            haspKey.ShowDialog();

            if (haspKey.SearchHaspKey != null)
            {
                keyFeature.IdHaspKey = haspKey.SearchHaspKey.Id;
                labelSelectKey.Text = haspKey.SearchHaspKey.InnerId + " - \"" + haspKey.SearchHaspKey.Number + "\"";
            }
        }
    }
}
