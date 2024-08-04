using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ViewContract;
using System.Linq;
using ModelEntities;

namespace HASPKey
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm, IMainView, IUpdateDataBaseMain
    {
        private IMainPresenter presenter;
        private const string errorStr = "Ошибка";
        public bool ErrorDataBase { get; set; } = false;

        public MainForm()
        {
            InitializeComponent();
            presenter = new MainPresenter(this);
            ErrorDB(); 
        }

        private void ErrorDB()
        {
            if (ErrorDataBase)
            {
                EditToolStripMenuItem.Enabled = false;
                buttonAll.Enabled = false;
                buttonSearchClient.Enabled = false;
            }
            else
            {
                EditToolStripMenuItem.Enabled = true;
                buttonAll.Enabled = true;
                buttonSearchClient.Enabled = true;
            }
        }

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            ErrorDB();
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e) => Close();

        public void BindForm(List<DXModelClient> clients)
        => bindingHome.DataSource = clients != null ? new BindingList<DXModelClient>(clients)
                                          : new BindingList<DXModelClient>();

        public void Bind(List<ModelViewMain> homes)
        => bindingHome.DataSource = homes != null ? new BindingList<ModelViewMain>(homes)
                                                  : new BindingList<ModelViewMain>();

        public void Bind(List<DXModelClient> clients)
         => bindingHome.DataSource = clients != null ? new BindingList<DXModelClient>(clients)
                                          : new BindingList<DXModelClient>();

        private void KeyToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (HaspKeyView haspKey = new HaspKeyView())
            {
                haspKey.DataUpdated += presenter.Views;
                haspKey.ShowDialog();
            }
        }

        private void FeatureToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (FeatureView feature = new FeatureView())
            {
                feature.DataUpdated += presenter.Views;
                feature.ShowDialog();
            }
        }

        private void ClientToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (ClientView client = new ClientView())
            {
                client.DataUpdated += presenter.Views;
                client.ShowDialog();
            }
        }

        private void KeyFeatureToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (KeyFeatureView keyFeatureView = new KeyFeatureView())
            {
                keyFeatureView.DataUpdated += presenter.Views;
                keyFeatureView.ShowDialog();
            }
        }

        private void DataGridViewHomeViewDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DataGridViewHomeView.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }

        private void KeyFeatureClientToolStripMenuItemClick(object sender, EventArgs e)
        {
            using (KeyFeatureClientView keyFeatureClientView = new KeyFeatureClientView())
            {
                keyFeatureClientView.DataUpdated += presenter.Views;
                keyFeatureClientView.ShowDialog();
            }
        }

        private void ReferenceClick(object sender, EventArgs e)
        {
            using (ReferenceView referenceView = new ReferenceView())
            {
                referenceView.ShowDialog();
            }
        }

        void IUpdateDataBaseMain.UpdateDataBaseMain()
        {
            ErrorDataBase = false;
            presenter = new MainPresenter(this);
            ErrorDB();
        }

        private void ButtonSearchClientClick(object sender, EventArgs e)
        {
            using (ClientView client = new ClientView(true))
            {
                client.ShowDialog();

                if (client.SearchIdClient != null)
                {                    
                    presenter.GetByClient(client.SearchIdClient);
                }
            }
        }

        private void ButtonAllClick(object sender, EventArgs e)
        {
            presenter.Views();
           
        }

        private void ViewExpiredKeysCheckedChanged(object sender, EventArgs e)
        {
           if (viewOldKeys.Checked)
           {
                presenter.ShowExpiredKeys();
           }
           else
           {
                presenter.Views();
           }
        }
        
        private void DataGridViewHomeViewColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = DataGridViewHomeView.Columns[e.ColumnIndex].Name;

            if (columnName == "endDateDataGridViewTextBoxColumn")
            {
                Sort(x => x.Date);
            }
             if (columnName == "clientDataGridViewTextBoxColumn")
            {
                Sort(x => x.Client);    
            }
            else if (columnName == "featureDataGridViewTextBoxColumn")
            {               
                Sort(x => x.Feature);
            }
            else if (columnName == "numberKeyDataGridViewTextBoxColumn")
            {
                Sort(x => x.NumberKey);
            }   
        }

        private void Sort(Func<ModelViewMain, object> param)
        {
            var currentList = bindingHome.List.Cast<ModelViewMain>().ToList();
            var sortedList = currentList.OrderBy(param).ToList();

            if (currentList.SequenceEqual(sortedList))
            {
                sortedList = currentList.OrderByDescending(param).ToList();
            }
            Bind(sortedList);
        }
    }
}
