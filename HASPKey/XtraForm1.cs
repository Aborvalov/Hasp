using DevExpress.XtraEditors;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class MainForm2 : DevExpress.XtraEditors.XtraForm
    {
        private IPresenterMain presenter;
        public MainForm2()
        {
            InitializeComponent();
           // presenter = new PresenterMain(this);
           
        }
    }
}