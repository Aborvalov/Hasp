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
    public partial class KeyFeatureView : DevExpress.XtraEditors.XtraForm, IEntitesView<ModelViewKeyFeature>
    {
        private readonly IPresenterEntites<ModelViewKeyFeature> presenterKeyFeature;
        private bool size = true;
        private int sizeH = 40;
        private ModelViewKeyFeature feature = null;
        public event Action DateUpdate;

        public KeyFeatureView()
        {
            InitializeComponent();
            presenterKeyFeature = new PresenterKeyFeature(this);
            dgvKeyFeture.Height = dgvKeyFeture.Size.Height + sizeH;
        }

        public void Add(ModelViewKeyFeature entity)
        {
            presenterKeyFeature.Add(entity);
            DateUpdate?.Invoke();
        }

            public void Build(List<ModelViewKeyFeature> entity) => bindingKeyFeature.DataSource = entity != null ? new BindingList<ModelViewKeyFeature>(entity)
                                                      : new BindingList<ModelViewKeyFeature>();

        public void MessageError(string error) => MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void Remove(int id) => presenterKeyFeature.Remove(id);

        public void Update(ModelViewKeyFeature entity)
        {
            presenterKeyFeature.Update(entity);
            DateUpdate?.Invoke();
        }

            private void Button1Delete_Click(object sender, EventArgs e)
        {
            var row = dgvKeyFeture.CurrentRow.DataBoundItem as ModelViewKeyFeature;
            if (row.Id == 0)
            {
                bindingKeyFeature.RemoveCurrent();
                return;
            }

            string caption = "Удалить связку ключ-функциональность";
            string message = "Вы уверены, что хотите удалить связь ключ-функциональность?";
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Remove(row.Id);
                DefaultView();
            }
        }

        private void DefaultView()
        {
            if (!size)
            {
                dgvKeyFeture.Height = dgvKeyFeture.Size.Height + sizeH;
                size = !size;
            }
        }
    }
}
