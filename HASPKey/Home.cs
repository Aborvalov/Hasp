using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using View;

namespace HASPKey
{
    public partial class Home : DevExpress.XtraEditors.XtraForm, IHomeView
    {
        private readonly IPresenterHome presenter;

        public Home()
        {
            InitializeComponent();
            presenter = new PresenterHome(this);
        }
        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
            =>  this.Close();
        public void Build(List<ModelEntities.ModelViewHome> homes)
        => bindingHome.DataSource = homes != null ? new BindingList<ModelEntities.ModelViewHome>(homes) 
                                                  : new BindingList<ModelEntities.ModelViewHome>();

        private void КлючToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HaspKeyView haspKey = new HaspKeyView();
            haspKey.DateUpdate += presenter.Views;
            haspKey.ShowDialog();
        }

        private void ФичаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeatureView feature = new FeatureView();
            feature.DateUpdate += presenter.Views;
            feature.ShowDialog();
        }
        
        private void КлиентToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientView client = new ClientView();
            client.DateUpdate += presenter.Views;
            client.ShowDialog();
        }

        private void СвязьКлючфункциональностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyFeatureView keyFeatureView = new KeyFeatureView();
            keyFeatureView.DateUpdate += presenter.Views;
            keyFeatureView.ShowDialog();
        }
    }
}
