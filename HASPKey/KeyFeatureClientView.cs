using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModelEntities;
using Presenter;
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
            //if (change)
            //    Save();
            presenterEntities.DisplayHaspKeyAtClient(row.Id);
        }
    }
}