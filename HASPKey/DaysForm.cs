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
        private void TextBox1TextChanged(object sender, EventArgs e)
        => change = true;

        private void DXFormFormClosed(object sender, FormClosedEventArgs e)
        {
            if (change)
                LoadFromXml.Save(textBox1.Text);
            
        }
    }
}