using Logic;
using System;
using System.Windows.Forms;

namespace HASPKey
{
    public partial class NewDataForm : DevExpress.XtraEditors.XtraForm
    {
        private const string caption = "Внести изменения";
        private const string message = "Данные были изменены, внести изменения?";
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
            {
                if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    try
                    {
                        LoadFromXml.Save(int.Parse(DataWindow.Text));
                    }
                    catch
                    {
                        LoadFromXml.Save(defaultValue);
                    }
            }
        }

        private void DataWindowKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
            else
                e.Handled = false;
            change = true;
        }
    }
}