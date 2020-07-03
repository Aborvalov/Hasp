using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            haspKey.DateUpdate += presenter.Views;
            haspKey.ShowDialog();
        }

        private void FeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeatureView feature = new FeatureView();
            feature.DateUpdate += presenter.Views;
            feature.ShowDialog();
        }
        
        private void ClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientView client = new ClientView();
            client.DateUpdate += presenter.Views;
            client.ShowDialog();
        }

        private void KeyFeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyFeatureView keyFeatureView = new KeyFeatureView();
            keyFeatureView.DateUpdate += presenter.Views;
            keyFeatureView.ShowDialog();
        }
    }
}
