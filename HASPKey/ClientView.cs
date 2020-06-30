using ModelEntities;
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
using View;

namespace HASPKey
{
    public partial class ClientView : DevExpress.XtraEditors.XtraForm,
        IEntitesView<ModelViewClient>
    {
        private readonly IPresenterClient presenterHaspKey;
        private bool size = true;
        private const int sizeH = 40;
        private ModelViewClient haspKey = null;

        public ClientView()
        {
            InitializeComponent();
            presenterHaspKey = new PresenterClient(this);
            dgvClient.Height = dgvClient.Size.Height + sizeH;
        }

        public void Add(ModelViewClient entity)
        {
            throw new NotImplementedException();
        }

        public void Build(List<ModelViewClient> entity) => bindingClient.DataSource = entity != null ? new BindingList<ModelViewClient>(entity)
                                                      : new BindingList<ModelViewClient>();

        public void MessageError(string error)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ModelViewClient entity)
        {
            throw new NotImplementedException();
        }
    }
}
