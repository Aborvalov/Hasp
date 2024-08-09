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
    public partial class AddUserForm : DevExpress.XtraEditors.XtraForm, IUserView
    {
        private readonly IUserPresenter presenterUser;
        public bool error = false;
        private const string errorStr = "Ошибка";
        private const string errorLen = "Длина пароля должна быть больше 5 символов.";
        private const string errorNoLetters = "Пароль должен содержать хотя бы одну букву.";
        private const string errorNoDigit = "Пароль должен содержать хотя бы одну цифру.";
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
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string password = textBoxPassword.Text;

            if (password.Length <= 5)
            {
                MessageError(errorLen);
                return;
            }

            bool containsLetter = password.Any(char.IsLetter);
            bool containsDigit = password.Any(char.IsDigit);

            if (!containsLetter)
            {
                MessageError(errorNoLetters);
                return;
            }

            if (!containsDigit)
            {
                MessageError(errorNoDigit);
                return;
            }

            NewItem = new ModelViewUser
            {
                Id = -1,
                Name = textBoxName.Text,
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text,
                LevelAccess = checkSuperAdmin.Checked ? LevelAccess.superadmin : checkAdmin.Checked ? LevelAccess.admin : LevelAccess.user,
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

        public void Bind(List<ModelViewUser> entity)
            => loginBindingSource.DataSource = entity != null ? new BindingList<ModelViewUser>(entity)
                                                         : new BindingList<ModelViewUser>();

        public void BindItem(ModelViewUser entity)
        {
            loginBindingSource.DataSource = entity ?? new ModelViewUser();
        }
    }
}