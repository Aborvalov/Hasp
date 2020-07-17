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
    public partial class KeyFeatureClientView : DevExpress.XtraEditors.XtraForm, IKeyFeatureClientView
    {
        private readonly IPresenterKeyFeatureClient presenterEntities;
        public event Action DataUpdated;
        private bool change = false;

        private const string error = "Ошибка";
        private const string emptyClient = "Данный клиент не найден.";
        private const string caption = "Внести изменеия";
        private const string message = "Данные были изменены, внести изменеия?";
        private const string errorString = "Не заполнено поле \"Инициатор\".";
        private const string emptyKeyFeature = "Данный ключ не найден.";

        public string NameClient { get ; set; }

        public KeyFeatureClientView()
        {
            InitializeComponent();
            presenterEntities = new PresenterKeyFeatureClient(this);
        }        

        public void DataChange() => DataUpdated?.Invoke();

        public void MessageError(string errorText)
            => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void BindClient(List<ModelViewClient> client) 
            => bindingClient.DataSource = client != null ? new BindingList<ModelViewClient>(client)
                                                         : new BindingList<ModelViewClient>();

        public void BindKey(List<ModelViewKeyFeatureClient> keyClient)
         => bindingKeyFeatureClient.DataSource = keyClient != null ? new BindingList<ModelViewKeyFeatureClient>(keyClient)
                                                         : new BindingList<ModelViewKeyFeatureClient>();

        private void DataGridViewClient_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DataGridViewClient.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }

        private void DataGridViewKeyFeature_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DataGridViewKeyFeature.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }

        private void DataGridViewClient_CellClick(object sender, DataGridViewCellEventArgs e) => FillKeyFeatureAtClient();

        private void DataGridViewClient_SelectionChanged(object sender, EventArgs e) => FillKeyFeatureAtClient();

        private void FillKeyFeatureAtClient()
        {
            if (!(DataGridViewClient.CurrentRow.DataBoundItem is ModelViewClient row))
            {
                MessageError(emptyClient);
                return;
            }
            if (change)
                Save();
            
            presenterEntities.DisplayHaspKeyAtClient(row.Id);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
            => Save();

        private void Save()
        {
            var item = (bindingKeyFeatureClient.DataSource as BindingList<ModelViewKeyFeatureClient>).ToList();

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
            => DataGridViewKeyFeature
                   .Rows[numberRow]
                   .DefaultCellStyle
                   .BackColor = Color.Red;
        private void DefaultColorRow()
        {
            for (int i = 0; i < DataGridViewKeyFeature.RowCount; i++)
                DefaultColorRow(i);
        }
        public void DefaultColorRow(int numberRow)
           => DataGridViewKeyFeature
                .Rows[numberRow]
                .DefaultCellStyle
                .BackColor = Color.White;

        private void DataGridViewKeyFeature_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DefaultColorRow(e.RowIndex);
            if (!(DataGridViewKeyFeature.CurrentRow.DataBoundItem is ModelViewKeyFeatureClient row))
            {
                MessageError(emptyKeyFeature);
                return;
            }
                     
            DataGridViewKeyFeature[6, e.RowIndex].Value = presenterEntities.CheckSelected(row);

            presenterEntities.CheckInputData(row, e.RowIndex);
            change = true;
        }
    }
}