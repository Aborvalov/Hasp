using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HASPKey
{
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        public Home()
        {
            InitializeComponent();
            var entities = new BindingList<Entity>
            {
                new Entity{ Id = 1, Name = "A" },
                new Entity{ Id = 2, Name = "B" }
            };

            bindingSource1.DataSource = entities;
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void BindTo(Entity entity)
        {
            bindingSource1.DataSource = entity ?? throw new ArgumentNullException(nameof(entity));
        }
    }
}
