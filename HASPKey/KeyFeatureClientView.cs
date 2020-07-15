using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class KeyFeatureClientView : DevExpress.XtraEditors.XtraForm, IKeyFeatureClientView
    {
        
        public event Action DataUpdated;


        private const string error = "Ошибка";


        public KeyFeatureClientView()
        {
            InitializeComponent();
        }

        

        public void DataChange() => DataUpdated?.Invoke();

        public void MessageError(string errorText)
            => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}