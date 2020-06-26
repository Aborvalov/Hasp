using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Model;
using Logic;

namespace HASPKey
{
    public partial class Home : DevExpress.XtraEditors.XtraForm, IHomeView
    {
        public Home()
        {
            InitializeComponent();

            Build(new HomeModel(new Logics()).GetAll());
        }
        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
            =>  this.Close();
        public void Build(List<HomeView> homes)
            => bindingHome.DataSource = new BindingList<HomeView>(homes);

        private void ключToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HaspKeyView haspKey = new HaspKeyView();
            haspKey.ShowDialog();
        }
    }
}
