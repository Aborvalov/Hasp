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
    public partial class UserView : DevExpress.XtraEditors.XtraForm, IUserView
    {
        private readonly IUserPresenter presenterUser;
        public bool error = false;
        public bool click = false;
        public LevelAccess dataAccess;
        public User user = null;
        private const string errorStr = "Ошибка";
        private const string emptyLogin = "Поле \"Логин\" не заполнено.";
        private const string emptyPassword = "Поле \"Пароль\" не заполнено.";
        private const string wrongLoginOrPassword = "Неправильный логин или пароль.";

        public event Action DataUpdated;

        public UserView(bool search)
        {
            InitializeComponent();
            presenterUser = new UserPresenter(this);
        }

        public UserView() : this(false)
        { }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(login))
            {
                MessageError(emptyLogin);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageError(emptyPassword);
                return;
            }

            var user = presenterUser.Authenticate(login, password);
            if (user != null)
            {
                using (MainFormDX mainFormView = new MainFormDX(user))
                {
                    mainFormView.ShowDialog();
                }
                this.Close();
            }
            else
            {
                MessageError(wrongLoginOrPassword);
            }
    }

        private void textBoxLogin_KeyDown(object sender, KeyEventArgs e)
        {
            string login = textBoxLogin.Text;
        }

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = true;
        }

        public void textBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            string password = textBoxPassword.Text;
        }

        public void DataChange() => DataUpdated?.Invoke();

        public void Bind(List<ModelViewUser> entity)
        => loginBindingSource.DataSource = entity != null ? new BindingList<ModelViewUser>(entity)
                                                         : new BindingList<ModelViewUser>();

        public void BindItem(ModelViewUser entity)
        {
            loginBindingSource.DataSource = entity ?? new ModelViewUser();
        }

        private void UserView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (user != null)
            {
                using (MainFormDX mainFormView = new MainFormDX(user))
                {
                    mainFormView.ShowDialog();
                }
            }
        }
    }
}