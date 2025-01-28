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
    public partial class UserView : DevExpress.XtraEditors.XtraForm, IGetUserView
    {
        private readonly IUserPresenter presenterUser;
        private readonly IGetUserPresenter getPresenterUser;
        public bool error = false;
        public bool click = false;
        public LevelAccess? dataAccess = null;
        private const string errorStr = "Ошибка";
        private const string emptyLogin = "Поле \"Логин\" не заполнено.";
        private const string emptyPassword = "Поле \"Пароль\" не заполнено.";
        private const string wrongLoginOrPassword = "Неправильный логин или пароль.";

        public event Action DataUpdated;

        public UserView(bool search)
        {
            InitializeComponent();
            getPresenterUser = new GetUserPresenter(this);
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

            dataAccess = getPresenterUser.GetByLoginAndPassword(login, password);

            if (dataAccess != null)
            {
                using (MainFormDX mainFormView = new MainFormDX(dataAccess.Value))
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

        private void UserView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dataAccess != null)
            {
                if (Application.OpenForms.OfType<MainFormDX>().Any())
                {
                    using (MainFormDX mainFormView = new MainFormDX(dataAccess))
                    {
                        mainFormView.ShowDialog();
                    }
                }
            }
            Application.Exit();
        }
    }
}
