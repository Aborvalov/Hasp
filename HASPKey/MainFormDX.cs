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
                //barButtonItem5.Enabled = false;
            }
            else
            {
                barButtonItem2.Enabled = true;
                barButtonItem6.Enabled = true;
                //barButtonItem5.Enabled = true;
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
            using (HaspKeyView haspKey = new HaspKeyView())
            {
                haspKey.ShowDialog();
            }
        }
        private void BarButtonItem9ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FeatureView feature = new FeatureView())
            {
                feature.ShowDialog();
            }
        }
        private void BarButtonItem10ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (ClientView client = new ClientView())
            {
                
                client.ShowDialog();
            }
        }

        private void BarButtonItem11ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (KeyFeatureView keyFeatureView = new KeyFeatureView())
            {
                keyFeatureView.ShowDialog();
            }
        }

        private void BarButtonItem12ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (KeyFeatureClientView keyFeatureClientView = new KeyFeatureClientView())
            {
                keyFeatureClientView.ShowDialog();
            }
        }
        private void BarButtonItem5ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (SelectedDataBaseView selectedDataBaseView = new SelectedDataBaseView(this))
            {
                selectedDataBaseView.ShowDialog();
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