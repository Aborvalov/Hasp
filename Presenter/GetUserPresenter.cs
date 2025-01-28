using Entities;
using Logic;
using Model;
using System;
using ViewContract;

namespace Presenter
{
    public class GetUserPresenter : IGetUserPresenter
    {
        private readonly IGetUserView entitiesGetUserView;
        private readonly IUserModel userModel;

        private const string errorEmpty = "Одно из полей не заполнено.";
        private const string nullDB = "База данных не найдена.";

        public GetUserPresenter(IGetUserView entitiesLogInView)
        {
            this.entitiesGetUserView = entitiesLogInView ?? throw new ArgumentNullException(nameof(entitiesLogInView));
            try
            {
                userModel = new UserModel(new Logics());
            }
            catch (ArgumentNullException)
            {
                entitiesLogInView.MessageError(nullDB);
            }
        }

        public LevelAccess? GetByLoginAndPassword(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                entitiesGetUserView.MessageError(errorEmpty);
            }
            return userModel.GetByLoginAndPassword(login, password);
        }
    }
}
