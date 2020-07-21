using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm, IMainView
    {
        private readonly IPresenterMain presenter;

        public MainForm()
        {
            InitializeComponent();
            presenter = new PresenterMain(this);
        }
       
        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
            =>  this.Close();
        public void Bind(List<ModelEntities.ModelViewMain> homes)
        => bindingHome.DataSource = homes != null ? new BindingList<ModelEntities.ModelViewMain>(homes) 
                                                  : new BindingList<ModelEntities.ModelViewMain>();

        private void KeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HaspKeyView haspKey = new HaspKeyView();
            haspKey.DataUpdated += presenter.Views;
            haspKey.ShowDialog();
        }

        private void FeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeatureView feature = new FeatureView();
            feature.DataUpdated += presenter.Views;
            feature.ShowDialog();
        }
        
        private void ClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientView client = new ClientView();
            client.DataUpdated += presenter.Views;
            client.ShowDialog();
        }

        private void KeyFeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyFeatureView keyFeatureView = new KeyFeatureView();
            keyFeatureView.DataUpdated += presenter.Views;
            keyFeatureView.ShowDialog();
        }

        private void DataGridViewHomeView_DataBindingComplete(object sender, System.Windows.Forms.DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DataGridViewHomeView.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }

        private void KeyFeatureClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyFeatureClientView keyFeatureClientView = new KeyFeatureClientView();
            keyFeatureClientView.DataUpdated += presenter.Views;
            keyFeatureClientView.ShowDialog();
        }

        private void Reference_Click(object sender, EventArgs e)
        {
            ReferenceView referenceView = new ReferenceView();
            referenceView.ShowDialog();
        }
    }
}
