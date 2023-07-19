using Logic;
using System;
using System.Windows.Forms;

namespace HASPKey
{
    public partial class NewDataForm : DevExpress.XtraEditors.XtraForm
    {
        private bool change = false;
        public NewDataForm()
        {
            InitializeComponent();
        }
        private void DataWindowTextChanged(object sender, EventArgs e)
        => change = true;

        private void DXFormFormClosed(object sender, FormClosedEventArgs e)
        {
            if (change)
                LoadFromXml.Save(DataWindow.Text);
            
        }

        private void DataWindowKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            else 
            {
                e.Handled = false;
            }
        }
    }
}