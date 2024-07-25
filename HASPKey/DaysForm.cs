using Logic;
using System;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class NewDataForm : DevExpress.XtraEditors.XtraForm
    {
        private const string caption = "Внести изменения";
        private const string message = "Данные были изменены, внести изменения?";
        private readonly int oldValue;
        private const int defaultValue = 30;

        private readonly IUpdateDataBaseMain updateDataBaseMain;

        public NewDataForm(IUpdateDataBaseMain updateDataBaseMain)
        {
            InitializeComponent();
            oldValue = LoadFromXml.GetItem();
            DataWindow.Text = oldValue.ToString();
            this.updateDataBaseMain = updateDataBaseMain ?? throw new ArgumentNullException(nameof(updateDataBaseMain));
        }
        private void DXFormFormClosed(object sender, FormClosedEventArgs e)
        {
            if (!int.TryParse(DataWindow.Text, out int currentValue))
                return;

            if (oldValue != currentValue)
            {
                if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    try
                    {
                        LoadFromXml.Save(currentValue);
                    }
                    catch
                    {
                        LoadFromXml.Save(defaultValue);
                    }

                updateDataBaseMain.UpdateDataBaseMain();
            }
        }
    }
}