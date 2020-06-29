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

        private void RadioButtonAll_CheckedChanged(object sender, EventArgs e) => presenterHaspKey.View();

        private void RadioButtonPastDue_CheckedChanged(object sender, EventArgs e) => presenterHaspKey.GetByPastDue();


        private void RadioButtonActive_CheckedChanged(object sender, EventArgs e) => presenterHaspKey.GetByActive();

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            string caption = "Удалить ключ";
            string message = "Вы уверены, что хотите удалить Hasp-ключ?";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var row = dgvHaspKey.CurrentRow.DataBoundItem as ModelViewHaspKey;
                presenterHaspKey.Remove(row.Id);
            }            
        }

        public void MessageError(string error) => MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
