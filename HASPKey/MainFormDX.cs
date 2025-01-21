using DevExpress.XtraBars;
using ModelEntities;
using Presenter;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class MainFormDX : DevExpress.XtraEditors.XtraForm, IMainView, IUpdateDataBaseMain
    {
        private const string errorStr = "Ошибка";
        public bool ErrorDataBase { get; set; } = false;
        private IMainPresenter presenter;
        public int DataAccess;

        public MainFormDX()
        {
            InitializeComponent();
            presenter = new MainPresenter(this);
            barSubItem3.Enabled = false;
        }

        public MainFormDX(int dataAccess)
        {
            InitializeComponent();
            presenter = new MainPresenter(this);
            DataAccess = dataAccess;
            barSubItem4.Enabled = dataAccess == 2;
        }

        public void Bind(List<DXModelLicenseEnd> clients)
        => PastDays.DataSource = clients != null ? new BindingList<DXModelLicenseEnd>(clients)
                                          : new BindingList<DXModelLicenseEnd>();

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
            }
            else
            {
                barButtonItem2.Enabled = true;
                barButtonItem6.Enabled = true;
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
            using (HaspKeyView haspKey = new HaspKeyView(DataAccess))
            {
                haspKey.ShowDialog();
            }

        }

        private void BarButtonItem9ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (FeatureView feature = new FeatureView(DataAccess, true))
            {
                feature.ShowDialog();
            }
        }

        private void BarButtonItem10ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (ClientNumberKeys client = new ClientNumberKeys(DataAccess))
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

        private void BarButtonItem15ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (NewDataForm form = new NewDataForm(this))
            {
                form.ShowDialog();
            }
        }

        private void BarButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (LevelAccessView form = new LevelAccessView())
            {
                form.ShowDialog();
            }
        }

        private void BarButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (LogBookForm logbook = new LogBookForm()) 
            {
                logbook.ShowDialog();
            }
        }
    }
}