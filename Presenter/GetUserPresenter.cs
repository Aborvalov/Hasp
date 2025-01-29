using Entities;
using Logic;
using Model;
using System;
using ViewContract;

namespace Presenter
{
    public class GetUserPresenter : IGetUserPresenter
    {
        private readonly IErrorView entitiesErrorView;
        private readonly IUserModel userModel;
        private const string nullDB = "База данных не найдена.";
        private const string emptyLogin = "Поле \"Логин\" не заполнено.";
        private const string emptyPassword = "Поле \"Пароль\" не заполнено.";
        private const string wrongLoginOrPassword = "Неправильный логин или пароль.";

        public GetUserPresenter(IErrorView entitiesLogInView)
        {
            this.entitiesErrorView = entitiesLogInView ?? throw new ArgumentNullException(nameof(entitiesLogInView));
            try
            {
                userModel = new UserModel(new Logics());
            }
            catch (ArgumentNullException)
            {
                entitiesErrorView.MessageError(nullDB);
            }
        }

        public LevelAccess? GetByLoginAndPassword(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
            {
                entitiesErrorView.MessageError(emptyLogin);
                return null;
            }

            if (string.IsNullOrEmpty(password))
            {
                entitiesErrorView.MessageError(emptyPassword);
                return null;
            }

            var accessLevel = userModel.GetByLoginAndPassword(login, password);
            
            if (accessLevel == null)
            {
                entitiesErrorView.MessageError(wrongLoginOrPassword);
                return null;
            }

            return accessLevel;
        }
    }
}