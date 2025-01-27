using Entities;
using Logic;
using Model;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewContract;

namespace Presenter
{
    public class UserPresenter : IUserPresenter
    {
        private readonly IUserView entitiesUserView;
        private readonly IUserModel userModel;

        private const string nullDB = "База данных не найдена.";
        private const string errorEmpty = "Одно из полей не заполнено.";
        private const string errorUpdate = "Не удалось обновить клиента.";
        private const string errorDelete = "Не удалось удалить клиента.";
        private const string errorAdd = "Не удалось создать клиента.";
        private const string errorEmptyName = "\u2022 Не заполнено поля \"Имя\", не должно быть пустым. \n";

        public UserPresenter(IUserView entitiesLogInView)
        {
            this.entitiesUserView = entitiesLogInView ?? throw new ArgumentNullException(nameof(entitiesLogInView));
            try
            {
                userModel = new UserModel(new Logics());
            }
            catch (ArgumentNullException)
            {
                entitiesLogInView.MessageError(nullDB);
            }
            Display();
        }

        public ModelViewUser Entities { set; get; } = null;

        public LevelAccess? GetByLoginAndPassword(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                entitiesUserView.MessageError(errorEmpty);
            }
            return userModel.GetByLoginAndPassword(login, password);
        }

        public void Display() => entitiesUserView.Bind(userModel.GetAll());

        public void Edit(List<ModelViewUser> user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            Delete(user);
            Add(user);
            Update(user);

            Display();

            entitiesUserView.DataChange();
        }

        public void Update(List<ModelViewUser> keyClient)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }

            var update = keyClient.Where(x => x.Id > 0 && !string.IsNullOrEmpty(x.Name));
            if (update.Any())
            {
                userModel.Update(update, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesUserView.MessageError(error);
            }
        }

        public void Add(List<ModelViewUser> keyClient)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }
            var add = keyClient
                        .Where(x => x.Id == -1 && !string.IsNullOrEmpty(x.Name));
            if (add.Any())
            {
                userModel.Add(add, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesUserView.MessageError(error);
            }
        }

        public void Delete(List<ModelViewUser> keyClient)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }
            var delete = keyClient.Where(x => x.Id > 0);
            if (delete.Any())
            {
                userModel.Remove(delete, out string error);
                if (!string.IsNullOrEmpty(error))
                    entitiesUserView.MessageError(error);
            }
        }

        public void Add(ModelViewUser entity)
        {
            if (entity == null)
            {
                entitiesUserView.MessageError(errorAdd);
                return;
            }

            if (userModel.Add(entity))
            {
                entitiesUserView.DataChange();
                Display();
            }
            else
                entitiesUserView.MessageError(errorAdd);
        }

        public void Update(ModelViewUser entity)
        {
            if (entity == null)
            {
                entitiesUserView.MessageError(errorUpdate);
                return;
            }
            if (userModel.Update(entity))
            {
                entitiesUserView.DataChange();
                Display();
            }
            else
                entitiesUserView.MessageError(errorUpdate);
        }

        public void Remove(int id)
        {
            if (id > 0 && userModel.Remove(id))
            {
                entitiesUserView.DataChange();
                Display();
            }
            else
                entitiesUserView.MessageError(errorDelete);
        }

        public void FillInputItem(ModelViewUser item)
        {
            Entities = item ?? throw new ArgumentNullException(nameof(item));
            entitiesUserView.BindItem(item);
        }

        public void FillModel(ModelViewUser item)
        {
            Entities = item ?? throw new ArgumentNullException(nameof(item));
            if (!CheckInputData())
                return;
            if (Entities.Id < 1)
                Add(Entities);
            else
                Update(Entities);
        }

        public bool CheckInputData()
        {
            string errorMess = string.Empty;
            if (string.IsNullOrWhiteSpace(Entities.Name))
                errorMess += errorEmptyName;
            if (errorMess != string.Empty)
            {
                entitiesUserView.MessageError(errorMess.Trim());
                return false;
            }
            return true;
        }

        public void Dispose() => userModel.Dispose();

        public LevelAccess? Authenticate(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                entitiesUserView.MessageError(errorEmpty);
            }

            var levelAccess = userModel.GetByLoginAndPassword(login, password);

            if (levelAccess.ToString() != "")
            {
                entitiesUserView.MessageError("Неправильный логин или пароль.");
            }
            
            return levelAccess;
        }
    }
}
