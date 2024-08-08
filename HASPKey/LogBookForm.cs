using DevExpress.ExpressApp.Editors;
using Entities;
using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ViewContract;
using static DevExpress.XtraCharts.GLGraphics.Platform.EGL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HASPKey
{
    public partial class LogBookForm : DevExpress.XtraEditors.XtraForm, ILogView
    {
        private ILogPresenter presenterLog;
        public bool error = false;
        private const string errorStr = "Ошибка";

        public LogBookForm(bool search)
        {
            InitializeComponent();
            presenterLog = new LogPresenter(this);
        }

        public LogBookForm() : this(false)
        { }

        public void Bind(Log check)
        {
            throw new NotImplementedException();
        }

        public void Bind(List<ModelViewLog> entity)
        => logbookBindingSource.DataSource = entity != null ? new BindingList<ModelViewLog>(entity)
                                                         : new BindingList<ModelViewLog>();

        public void BindItem(ModelViewLog entity)
        {
            throw new NotImplementedException();
        }

        public void DataChange()
        {
            throw new NotImplementedException();
        }

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = true;
        }
    }
}