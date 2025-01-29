using Entities;
using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class LevelAccessView : DevExpress.XtraEditors.XtraForm, IUserView
    {
        private readonly IUserPresenter presenterUser;
        public User newItem = null;
        private bool isSomethingChanged = false;
        public bool error = false;
        private const string errorStr = "Ошибка";
        private const string caption = "Удалить пользователя";
        private const string messageDelete = "Вы уверены, что хотите удалить пользователя?";
        private const string messageSave = "Вы уверены, что хотите сохранить пользователя?";
        private const string emptyClient = "Данный пользователь не найден.";
        public event Action DataUpdated;
        public int editingRowId = -1;

        public LevelAccessView(bool search)
        {
            InitializeComponent();
            presenterUser = new UserPresenter(this);
            SetupComboBoxColumn();
        }

        public LevelAccessView() : this(false)
        { }

        private void SetupComboBoxColumn()
        {
            if (DataGridViewLogIn.Columns["levelAccessDataGridViewTextBoxColumn"] is DataGridViewComboBoxColumn comboBoxColumn)
            {
                comboBoxColumn.DataSource = Enum.GetValues(typeof(LevelAccess));
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (loginBindingSource.DataSource == null)
            {
                loginBindingSource.DataSource = new BindingList<ModelViewUser>();
            }

            var bindingList = loginBindingSource.DataSource as BindingList<ModelViewUser>;
            if (bindingList == null) return;

            int nextId = (bindingList.Count > 0) ? bindingList.Max(u => u.Id) + 1 : 1;

            var newUser = new ModelViewUser
            {
                Id = -1,
                Name = "",
                Login = "",
                Password = "",
                LevelAccess = LevelAccess.user
            };

            bindingList.Add(newUser);
            DataGridViewLogIn.Refresh();

            int rowIndex = bindingList.IndexOf(newUser);
            if (rowIndex >= 0)
            {
                DataGridViewLogIn.CurrentCell = DataGridViewLogIn.Rows[rowIndex].Cells[1];
                DataGridViewLogIn.BeginEdit(true);
            }

            editingRowId = nextId;

            isSomethingChanged = true;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var bindingList = loginBindingSource.DataSource as BindingList<ModelViewUser>;
            if (bindingList == null) return;

            if (DataGridViewLogIn.IsCurrentCellInEditMode)
            {
                DataGridViewLogIn.EndEdit();
            }
            loginBindingSource.EndEdit();

            error = false;
            if (MessageBox.Show(messageSave, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                presenterUser.Edit(bindingList.ToList());
                isSomethingChanged = false;
            }
            DataGridViewLogIn.Refresh();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (isSomethingChanged)
            {
                presenterUser.Display();
                isSomethingChanged = false;
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!(DataGridViewLogIn.CurrentRow.DataBoundItem is ModelViewUser row))
            {
                MessageError(emptyClient);
                return;
            }
            if (row.Id == 0)
            {
                loginBindingSource.RemoveCurrent();
                return;
            }
            if (MessageBox.Show(messageDelete, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                presenterUser.Remove(row.Id);
            }
        }

        public void DataChange() => DataUpdated?.Invoke();

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = true;
        }

        public void Bind(List<ModelViewUser> entity)
            => loginBindingSource.DataSource = entity != null ? new BindingList<ModelViewUser>(entity)
                                                         : new BindingList<ModelViewUser>();

        public void BindItem(ModelViewUser entity)
        {
            loginBindingSource.DataSource = entity ?? new ModelViewUser();
            
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (DataGridViewLogIn.CurrentRow != null)
            {
                var selectedRow = DataGridViewLogIn.CurrentRow.DataBoundItem as ModelViewUser;
                if (selectedRow != null)
                {
                    editingRowId = selectedRow.Id;
                    DataGridViewLogIn.BeginEdit(true);
                }
            }
        }

        private void DataGridViewLogIn_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DataGridViewLogIn.Columns[e.ColumnIndex].Name == "RealPassword" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
                e.FormattingApplied = true;
            }
        }
    }
}