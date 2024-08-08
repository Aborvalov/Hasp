using Entities;
using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class AddUserForm : DevExpress.XtraEditors.XtraForm, IUserView
    {
        private readonly IUserPresenter presenterUser;
        public bool error = false;
        private const string errorStr = "Ошибка";
        public event Action DataUpdated;
        public ModelViewUser newItem;

        public ModelViewUser NewItem { get; set; }

        public AddUserForm(bool search)
        {
            InitializeComponent();
            presenterUser = new UserPresenter(this);
        }

        public AddUserForm() : this(false)
        { }

        public AddUserForm(ModelViewUser item)
        {
            InitializeComponent();
            buttonCreate.Text = "Изменить";
            NewItem = item;
            textBoxName.Text = item.Name;
            textBoxLogin.Text = item.Login;
            textBoxPassword.Text = item.Password;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            NewItem = new ModelViewUser
            {
                Id = -1,
                Name = textBoxName.Text,
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text,
                LevelAccess = checkEdit2.Checked ? LevelAccess.superadmin : checkEdit3.Checked ? LevelAccess.user : LevelAccess.admin,
            };
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            string name = textBoxName.Text;
        }

        private void textBoxLogin_KeyDown(object sender, KeyEventArgs e)
        {
            string login = textBoxLogin.Text;
        }

        private void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            string password = textBoxPassword.Text;
        }

        public void DataChange() => DataUpdated?.Invoke();

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = true;
        }

        public void Bind(User entity)
        {
            loginBindingSource.DataSource = entity ?? new User();
        }
        public void Bind(List<ModelViewUser> entity)
            => loginBindingSource.DataSource = entity != null ? new BindingList<ModelViewUser>(entity)
                                                         : new BindingList<ModelViewUser>();

        public void BindItem(ModelViewUser entity)
        {
            loginBindingSource.DataSource = entity ?? new ModelViewUser();
        }
    }
}