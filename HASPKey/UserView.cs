﻿using Entities;
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
        public int dataAccess = -1;
        private const string errorStr = "Ошибка";
        private const string emptyLogin = "Поле \"Логин\" не заполнено.";
        private const string emptyPassword = "Поле \"Пароль\" не заполнено.";
        private const string wrongLoginAndPassword = "Неправильный логин или пароль.";

        public event Action DataUpdated;

        public UserView(bool search)
        {
            InitializeComponent();
            presenterUser = new UserPresenter(this);
        }

        public UserView() : this(false)
        { }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
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
            dataAccess = presenterUser.GetByLoginAndPassword(login, password);
            if (dataAccess > 0)
            {
                this.Hide();
                using (MainFormDX mainFormView = new MainFormDX(dataAccess))
                {
                    mainFormView.FormClosed += (s, args) =>
                    { 
                        this.Close();
                    };
                    mainFormView.ShowDialog();
                }
                
            }
            else
            {
                MessageError(wrongLoginAndPassword);
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