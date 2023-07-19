using Logic;
using System;
using System.Windows.Forms;

namespace HASPKey
{
    public partial class NewDataForm : DevExpress.XtraEditors.XtraForm
    {
        private bool change = false;
        private const int defaultValue = 30;

        public NewDataForm()
        {
            InitializeComponent();
            DataWindow.Text = LoadFromXml.GetItem().ToString();
        }
        private void DataWindowTextChanged(object sender, EventArgs e)
        => change = true;

        private void DXFormFormClosed(object sender, FormClosedEventArgs e)
        {
            if (change)
                try
                {
                    LoadFromXml.Save(int.Parse(DataWindow.Text));
                }
                catch 
                {
                    LoadFromXml.Save(defaultValue);
                }
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
            change = true;
        }

        private void DataWindow_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DataWindow.Text = null;
        }
    }
}