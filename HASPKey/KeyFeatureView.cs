using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class KeyFeatureView : DevExpress.XtraEditors.XtraForm, IKeyFeatureView
    {
        public event Action DataUpdated;
        public string NumberHaspKey { get; set; }
        private IPresenterKeyFeature presenterEntities;
        
        private const string error = "Ошибка";
        private const string errorString = "Неправильно заполнена дата, окончание действия меньше начала.";
        private const string emptyKey = "Данный ключ не найден.";
        private const string caption = "Внести изменеия";
        private const string message = "Вы уверены, что хотите внести изменеия?";
        private const string headlineFeature = "Список действующих функциональностей у ключа - ";
        public KeyFeatureView()
        {
            InitializeComponent();
            presenterEntities = new PresenterKeyFeature(this);
        }
              
        public void DataChange() => DataUpdated?.Invoke();
        public void MessageError(string errorText)
            => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void BindFeature(List<ModelViewKeyFeature> feature)
        {
            bindingFeature.DataSource = feature != null ? new BindingList<ModelViewKeyFeature>(feature)
                                                        : new BindingList<ModelViewKeyFeature>();

            HeadlineFeature.Text = headlineFeature + NumberHaspKey;
        }
        public void BindKey(List<ModelViewHaspKey> key) 
            => bindingHaspKey.DataSource = key != null ? new BindingList<ModelViewHaspKey>(key)
                                                       : new BindingList<ModelViewHaspKey>();

        private void DgvHaspKey_CellClick(object sender, DataGridViewCellEventArgs e)
            => FillFeatureAtKey();

        private void DgvHaspKey_SelectionChanged(object sender, EventArgs e)
            => FillFeatureAtKey();

        private void FillFeatureAtKey()
        {
            if (!(dgvHaspKey.CurrentRow.DataBoundItem is ModelViewHaspKey row))
            {
                MessageError(emptyKey);
                return;
            }            
            presenterEntities.DisplayFeatureAtKey(row.Id);
        }
        
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var item = (bindingFeature.DataSource as BindingList<ModelViewKeyFeature>).ToList();

            DefaultRow();
            if (presenterEntities.CheckInputData(item))
            {
                if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    presenterEntities.Edit(item);
            }
            else
                MessageError(errorString);
        }

        public void ErrorRow(int numberRow)
            =>dgvFeature.Rows[numberRow].DefaultCellStyle.BackColor = Color.Red;

        private void DefaultRow()
        {
            for (int i = 0; i < dgvFeature.RowCount; i++)
                DefaultRow(i);
        }
        public void DefaultRow(int numberRow)
           => dgvFeature.Rows[numberRow].DefaultCellStyle.BackColor = Color.White;

        private void DgvFeature_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DefaultRow(e.RowIndex);
            var item = dgvFeature.CurrentRow.DataBoundItem as ModelViewKeyFeature;
            presenterEntities.CheckInputData(item, e.RowIndex);

            if (presenterEntities.CheckSelected(item))
                dgvFeature[6, e.RowIndex].Value = true;
        }

        private void EditKeyFeatureView_Load(object sender, EventArgs e)
            => EmptyFeatureAsKey();
        
        public void EmptyFeatureAsKey()
        {            
            for (int i = 0; i < bindingHaspKey.Count; i++)
            {
                if (!(bindingHaspKey[i] is ModelViewHaspKey item))
                    return;

                if(presenterEntities.CheckKey(item))
                    dgvHaspKey.Rows[i].DefaultCellStyle.BackColor = Color.Wheat;
                else
                    dgvHaspKey.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void DgvFeature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                dgvFeature.Rows[dgvFeature.CurrentCell.RowIndex].Cells[dgvFeature.CurrentCell.ColumnIndex].Value = null;
            }
        }
    }
}
