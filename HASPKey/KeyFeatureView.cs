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
        private readonly IPresenterKeyFeature presenterEntities;
        private bool change = false;


        private const string error = "Ошибка";
        private const string errorString = "Неправильно заполнена дата, окончание действия меньше начала.";
        private const string emptyKey = "Данный ключ не найден.";
        private const string emptyFeature = "Данная функциональность не найдена.";
        private const string caption = "Внести изменеия";
        private const string message = "Данные были изменены, внести изменеия?";
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

        private void  DataGridViewHaspKey_CellClick(object sender, DataGridViewCellEventArgs e)
            => FillFeatureAtKey();

        private void DataGridViewHaspKey_SelectionChanged(object sender, EventArgs e)
            => FillFeatureAtKey();

        private void FillFeatureAtKey()
        {
            if (!(DataGridViewHaspKey.CurrentRow.DataBoundItem is ModelViewHaspKey row))
            {
                MessageError(emptyKey);
                return;
            }
            if (change)
                Save();
            presenterEntities.DisplayFeatureAtKey(row.Id);
        }
        
        private void ButtonSave_Click(object sender, EventArgs e) => Save();

        private void Save()
        {
            var item = (bindingFeature.DataSource as BindingList<ModelViewKeyFeature>).ToList();

            DefaultColorRow();
            if (presenterEntities.CheckInputData(item))
            {
                if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    presenterEntities.Edit(item);
                change = false;
            }
            else
                MessageError(errorString);
        }

        public void ErrorRow(int numberRow)
            =>DataGridViewFeature
                .Rows[numberRow]
                .DefaultCellStyle
                .BackColor = Color.Red;

        private void DefaultColorRow()
        {
            for (int i = 0; i < DataGridViewFeature.RowCount; i++)
                DefaultColorRow(i);
        }
        public void DefaultColorRow(int numberRow)
           => DataGridViewFeature.Rows[numberRow].DefaultCellStyle.BackColor = Color.White;

        private void DataGridViewFeature_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DefaultColorRow(e.RowIndex);
            if (!(DataGridViewFeature.CurrentRow.DataBoundItem is ModelViewKeyFeature row))
            {
                MessageError(emptyFeature);
                return;
            }            

            presenterEntities.CheckInputData(row, e.RowIndex);
            if (presenterEntities.CheckSelected(row))
                DataGridViewFeature[6, e.RowIndex].Value = true;
            else
                if(DataGridViewFeature[5, e.RowIndex].Value == null ||
                   DataGridViewFeature[4, e.RowIndex].Value == null)
                ErrorRow(e.RowIndex);

            change = true;
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
                    DataGridViewHaspKey.Rows[i].DefaultCellStyle.BackColor = Color.Wheat;
                else
                    DataGridViewHaspKey.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void DataGridViewFeature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
                DataGridViewFeature.Rows[DataGridViewFeature.CurrentCell.RowIndex]
                                   .Cells[DataGridViewFeature.CurrentCell.ColumnIndex]
                                   .Value = null;
        }

        private void DataGridViewHaspKey_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DataGridViewHaspKey.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }

        private void DataGridViewFeature_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DataGridViewFeature.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }
    }
}
