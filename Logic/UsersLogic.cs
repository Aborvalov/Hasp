using DalContract;
using Entities;
using LogicContract;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class UsersLogic : IUsersLogic
    {
        private readonly IContractUserDAO usersDAO;

        public UsersLogic(IContractUserDAO userDAO)
        {
            this.usersDAO = userDAO ?? throw new ArgumentNullException(nameof(userDAO));
        }

        public List<User> GetAll() => usersDAO.GetAll();

        public User GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return usersDAO.GetById(id);
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException(nameof(id));

            return usersDAO.Remove(id);
        }

        public bool Save(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            int id;
            if (!usersDAO.ContainsDB(entity))
                id = usersDAO.Add(entity);
            else
                return false;

            return id > 0;
        }

        public bool Update(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            CheckArgument(entity);

            return !usersDAO.ContainsDB(entity) && usersDAO.Update(entity);
        }

        private void CheckArgument(User client)
        {
            if (string.IsNullOrWhiteSpace(client.Name))
                throw new ArgumentException(nameof(client.Name));
        }

        public User GetByLoginAndPassword(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
                throw new ArgumentException(nameof(login));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentException(nameof(password));
            return usersDAO.GetByLoginAndPassword(login, password);
        }
    }
}
