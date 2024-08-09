using Entities;
using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class LevelAccessView : DevExpress.XtraEditors.XtraForm, IUserView
    {
        private readonly IUserPresenter presenterUser;
        private ModelViewUser newItem;
        private bool isSomethingChanged = false;
        public bool error = false;
        private const string errorStr = "Ошибка";
        private const string caption = "Удалить пользователя";
        private const string messageDelete = "Вы уверены, что хотите удалить пользователя?";
        private const string messageSave = "Вы уверены, что хотите сохранить пользователя?";
        private const string emptyClient = "Данный пользователь не найден.";
        public event Action DataUpdated;

        public LevelAccessView(bool search)
        {
            InitializeComponent();
            presenterUser = new UserPresenter(this);
        }

        public LevelAccessView() : this(false)
        { }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            newItem = null;
            var bindingList = loginBindingSource.DataSource as BindingList<ModelViewUser>;

            using (AddUserForm user = new AddUserForm(true))
            {              
                if (user.ShowDialog() == DialogResult.OK)
                {
                    var newItem = user.NewItem; 

                    if (newItem != null)
                    {
                        bindingList.Add(newItem);
                        DataGridViewLogIn.Refresh();

                        int rowIndex = bindingList.IndexOf(newItem);
                        if (rowIndex >= 0)
                        {
                            DataGridViewLogIn.CurrentCell = DataGridViewLogIn.Rows[rowIndex].Cells[0];
                            DataGridViewLogIn.BeginEdit(true);
                        }

                        isSomethingChanged = true;
                    }
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var bindingList = loginBindingSource.DataSource as BindingList<ModelViewUser>;
            error = false;
            if (MessageBox.Show(messageSave, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                presenterUser.Edit(bindingList.ToList());
                isSomethingChanged = false;
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (isSomethingChanged)
            {
                presenterUser.Display();
                isSomethingChanged = false;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
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

        private void DataGridViewLogIn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewLogIn.Rows[e.RowIndex].Selected = true;
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (DataGridViewLogIn.CurrentRow != null)
            {
                var selectedRow = DataGridViewLogIn.CurrentRow.DataBoundItem as ModelViewUser;
                if (selectedRow != null)
                {
                    using (AddUserForm user = new AddUserForm(selectedRow))
                    {
                        if (user.ShowDialog() == DialogResult.OK)
                        {
                            int selectedRowIndex = DataGridViewLogIn.CurrentRow.Index;
                            loginBindingSource[selectedRowIndex] = user.NewItem;
                            var bindingList = loginBindingSource.DataSource as BindingList<ModelViewUser>;
                            presenterUser.Edit(bindingList.ToList());
                            presenterUser.Remove(selectedRow.Id);
                        }
                    }
                }
            }
        }

    }
}