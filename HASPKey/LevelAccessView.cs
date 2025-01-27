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
        public User newItem = null;
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

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (loginBindingSource.DataSource == null)
            {
                loginBindingSource.DataSource = new BindingList<User>();
            }

            var bindingList = loginBindingSource.DataSource as BindingList<ModelViewUser>;

            using (AddUserForm user = new AddUserForm(true))
            {
                if (user.ShowDialog() == DialogResult.OK)
                {
                    var newItem = user.NewItem;

                    if (newItem != null)
                    {
                        var modelViewUser = new ModelViewUser
                        {
                            Id = newItem.Id,
                            Name = newItem.Name,
                            Login = newItem.Login,
                            Password = newItem.Password,
                            LevelAccess = newItem.LevelAccess
                        };

                        bindingList.Add(modelViewUser);
                        DataGridViewLogIn.Refresh();

                        int rowIndex = bindingList.IndexOf(modelViewUser);
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

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var bindingList = loginBindingSource.DataSource as BindingList<ModelViewUser>;
            error = false;
            if (MessageBox.Show(messageSave, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                presenterUser.Edit(bindingList.ToList());
                isSomethingChanged = false;
            }
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

        private void DataGridViewLogIn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewLogIn.Rows[e.RowIndex].Selected = true;
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
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

                            var bindingList = loginBindingSource.DataSource as BindingList<ModelViewUser>;
                            if (bindingList != null)
                            {
                                var itemToRemove = bindingList.FirstOrDefault(item => item.Id == selectedRow.Id);
                                if (itemToRemove != null)
                                {
                                    bindingList.Remove(itemToRemove);
                                }

                                var updatedUser = new ModelViewUser
                                {
                                    Id = user.NewItem.Id,
                                    Name = user.NewItem.Name,
                                    Login = user.NewItem.Login,
                                    Password = user.NewItem.Password,
                                    LevelAccess = user.NewItem.LevelAccess
                                };

                                bindingList.Add(updatedUser);

                                DataGridViewLogIn.Refresh();
                                isSomethingChanged = true;

                                var modelViewUserList = bindingList.Select(item => new ModelViewUser
                                {
                                    Id = item.Id,
                                    Name = item.Name,
                                    Login = item.Login,
                                    Password = item.Password,
                                    LevelAccess = item.LevelAccess
                                }).ToList();

                                presenterUser.Edit(modelViewUserList);
                                presenterUser.Remove(selectedRow.Id);
                            }
                        }
                    }
                }
            }
        }
    }
}