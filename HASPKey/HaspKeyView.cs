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
    public partial class HaspKeyView : DevExpress.XtraEditors.XtraForm, IEntitesView<ModelViewHaspKey>
    {
        private readonly IPresenterHaspKey presenterHaspKey;
        public HaspKeyView()
        {
            InitializeComponent();
            presenterHaspKey = new PresenterHaspKey(this);
        }

        public bool Add(ModelViewHaspKey entity)
        {
            throw new NotImplementedException();
        }

        public void Build(List<ModelViewHaspKey> homes) => bindingHaspKey.DataSource = homes != null ? new BindingList<ModelViewHaspKey>(homes)
                                                      : new BindingList<ModelViewHaspKey>();

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ModelViewHaspKey entity)
        {           
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e) => presenterHaspKey.GetByActive();

        private void button2_Click(object sender, EventArgs e) => presenterHaspKey.GetByPastDue();

        private void button3_Click(object sender, EventArgs e) => presenterHaspKey.View();
    }
}
