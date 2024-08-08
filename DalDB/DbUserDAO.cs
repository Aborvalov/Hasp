using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DalDB
{
    public class DbUserDAO : IContractUserDAO
    {
        private readonly EntitesContext db;

        public DbUserDAO(IEntitesContext db)
        {
            this.db = (EntitesContext)db ?? throw new ArgumentNullException(nameof(db));
        }

        public void UpdateLog(string tableName, string action, int id)
        {
            var latestLog = db.Logs.OrderByDescending(l => l.LogId).FirstOrDefault();
            if (latestLog != null)
            {
                var log = tableName + "-" + action + "-" + id + "; ";
                latestLog.Actions += log;
                db.Entry(latestLog).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<User> GetAll() => db.Users.ToList();

        public int GetByLoginAndPassword(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
                throw new ArgumentNullException(nameof(login));
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));
            var user = db.Users.ToList().SingleOrDefault(x => x.Login == login && x.Password == Hash(password));
            int access = -1;
            if (user != null) 
            {
                access = (int)user.LevelAccess;
                Log newLog = new Log
                {
                    User = user.Name + "-" + access,
                    LoginTime = DateTime.Now,
                    Actions = "Вход в программу. ",

                };
                var log = db.Logs.Add(newLog);
                db.SaveChanges();
            }

            return access;           
        }

        private string Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                string hash = builder.ToString();
                return hash;
            }
        }

        public int Add(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            
            entity.Password = Hash(entity.Password);

            var client = db.Users.Add(entity);

            db.SaveChanges();

            UpdateLog("Users", "добавлено", entity.Id);

            return client.Id;
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var client = GetById(id);
            if (client == null)
                return false;

            var keyFeatureClients = db.Users.Where(kfc => kfc.Id == id);

            db.Users.Remove(client);
            db.SaveChanges();

            UpdateLog("Users", "удалено", id);

            return true;
        }

        public bool Update(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var client = GetById(entity.Id);
            if (client == null)
                return false;

            client.Name = entity.Name;
            client.Login = entity.Login;
            client.Password = entity.Password;
            client.LevelAccess = entity.LevelAccess;

            db.SaveChanges();

            UpdateLog("Users", "обновлено", entity.Id);

            return true;
        }

        public User GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var client = db.Users.SingleOrDefault(c => c.Id == id);
            return client;
        }

        public bool ContainsDB(User entity)
        {
            var login = db.Users
                       .SingleOrDefault(c => c.Name == entity.Name &&
                                             c.Login == entity.Login &&
                                             c.Password == entity.Password &&
                                             c.LevelAccess == entity.LevelAccess);
            return login != null;
        }
    }
}
