using Presenter;
using System;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class UserView : DevExpress.XtraEditors.XtraForm, IErrorView
    {
        private readonly IGetUserPresenter getPresenterUser;
        private const string errorStr = "Ошибка";

        public UserView()
        {
            InitializeComponent();
            getPresenterUser = new GetUserPresenter(this);
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonEnter_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            var dataAccess = getPresenterUser.GetByLoginAndPassword(login, password);

            if (dataAccess.HasValue)
            {
                using (MainFormDX mainFormView = new MainFormDX(dataAccess.Value))
                {
                    mainFormView.ShowDialog();
                }
                this.Close();
            }
        }

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UserView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
