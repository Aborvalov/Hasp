using DevExpress.XtraBars;
using Entities;
using Model;
using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class MainFormDX : DevExpress.XtraEditors.XtraForm, IMainView, IUpdateDataBaseMain
    {
        private const string errorStr = "Ошибка";
        public bool ErrorDataBase { get; set; } = false;
        private IMainPresenter presenter;
        public event Action DataUpdated;
        public MainFormDX()
        {
            InitializeComponent();
            presenter = new MainPresenter(this);            
        }

        public void BindForm(List<DXModelClient> clients)
        => PastDays.DataSource = clients != null ? new BindingList<DXModelClient>(clients)
                                          : new BindingList<DXModelClient>();

        public void Bind(List<DXModelClient> clients)
        => NextDays.DataSource = clients != null ? new BindingList<DXModelClient>(clients)
                                          : new BindingList<DXModelClient>();

        public void Bind(List<ModelViewMain> homes)
        => NextDays.DataSource = homes != null ? new BindingList<ModelViewMain>(homes)
                                                  : new BindingList<ModelViewMain>();
        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            ErrorDB();
        }
        private void ErrorDB()
        {
            if (ErrorDataBase)
            {
                barButtonItem2.Enabled = false;
                barButtonItem6.Enabled = false;
                barSubItem3.Enabled = false;
            }
            else
            {
                barButtonItem2.Enabled = true;
                barButtonItem6.Enabled = true;
                if (!Admin.IsAdmin()) {
                    barSubItem3.Enabled = false;
                }
                else { barSubItem3.Enabled = true; }
            }
        }
        private void BarButtonItem2ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (ReferenceView referenceView = new ReferenceView())
            {
                referenceView.ShowDialog();
            }
        }
        private void BarButtonItem6ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
             => Close();
        void IUpdateDataBaseMain.UpdateDataBaseMain()
        {
            ErrorDataBase = false;
            presenter = new MainPresenter(this);
            ErrorDB();
        }

        private void BarButtonItem8ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Admin.IsAdmin())
            {
                using (HaspKeyView haspKey = new HaspKeyView())
                {
                    haspKey.ShowDialog();
                }
            }
            else 
            {
                barButtonItem8.Enabled = false;
            }
        }
        private void BarButtonItem9ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Admin.IsAdmin())
            {
                using (FeatureView feature = new FeatureView())
                {
                    feature.ShowDialog();
                }
            }
            else
            {
                barButtonItem9.Enabled = false;
            }
        }
        private void BarButtonItem10ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Admin.IsAdmin())
            {
                using (ClientView client = new ClientView())
                {
                    client.ShowDialog();
                }
            }
            else
            {
                barButtonItem10.Enabled = false;
            }
        }

        private void BarButtonItem11ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Admin.IsAdmin())
            {
                using (KeyFeatureView keyFeatureView = new KeyFeatureView())
                {
                    keyFeatureView.ShowDialog();
                }
            }
            else
            {
                barButtonItem11.Enabled = false;
            }
        }

        private void BarButtonItem12ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Admin.IsAdmin())
            {
                using (KeyFeatureClientView keyFeatureClientView = new KeyFeatureClientView())
                {
                    keyFeatureClientView.ShowDialog();
                }
            }
            else
            {
                barButtonItem12.Enabled = false;
            }
        }

        private void BarButtonItem15ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (NewDataForm form = new NewDataForm(this))
            {
                form.ShowDialog();
            }  
        }  
    }
}