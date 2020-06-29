using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Presenter;
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
            haspKey.ShowDialog();
        }
    }
}
