using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class UserModel : IUserModel
    {
        private readonly IUsersLogic userLogic;
        private readonly IFactoryLogic factoryLogic;
        private readonly IEntitesContext db;

        public UserModel(IFactoryLogic factoryLogic)
        {
            this.factoryLogic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));

            db = Context.GetContext();
            if (db == null)
                throw new ArgumentNullException(nameof(db));
        
            userLogic = this.factoryLogic.CreateUser(db);
        }

        public bool Add(IEnumerable<ModelViewUser> keyClient, out string error)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }

            error = string.Empty;

            if (!keyClient.Any())
                return true;
            
            foreach (var item in keyClient)
            {
                userLogic.Save(item.User);
            }
            return string.IsNullOrEmpty(error);
        }

        public bool Remove(IEnumerable<ModelViewUser> keyClient, out string error)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }

            error = string.Empty;
            var updateList = new List<ModelViewUser>();
            var all = GetAll();
            foreach (var item in keyClient)
            {
                if (all.Any(x => userLogic.Equals(item.User)))
                    continue;
                updateList.Add(item);
                userLogic.Update(item.User);
            }
            return string.IsNullOrEmpty(error);
        }

        public bool Update(IEnumerable<ModelViewUser> keyClient, out string error)
        {
            if (keyClient == null)
            {
                throw new ArgumentException(nameof(keyClient));
            }

            error = string.Empty;

            if (!keyClient.Any())
                return true;

            var allKeyAtClient = GetAll();
            var updateList = new List<ModelViewUser>();
            foreach (var item in keyClient)
            {
                if (allKeyAtClient.Any(x => userLogic.Equals(item.User)))
                    continue;
                updateList.Add(item);
                userLogic.Update(item.User);
            }
            return string.IsNullOrEmpty(error);
        }

        public List<ModelViewUser> GetAll() => Convert(userLogic.GetAll());

        private List<ModelViewUser> Convert(List<User> clients)
        {
            var viewClients = new List<ModelViewUser>();
            foreach (var cl in clients)
                viewClients.Add(new ModelViewUser(cl));
            return viewClients;
        }

        public bool Add(ModelViewUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            return userLogic.Save(entity.User);
        }

        public ModelViewUser GetById(int id) =>
            new ModelViewUser(userLogic.GetById(id));

        public bool Remove(int id) => userLogic.Remove(id);

        public bool Update(ModelViewUser entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return userLogic.Update(entity.User);
        }

        public void Dispose() => db.Dispose();

        public User GetByLoginAndPassword(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
                throw new ArgumentNullException(nameof(login));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            var userEntity = userLogic.GetByLoginAndPassword(login, password);
            if (userEntity == null)
                return null;

            return new User
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Login = userEntity.Login,
                LevelAccess = userEntity.LevelAccess
            };
        }
    }
}
