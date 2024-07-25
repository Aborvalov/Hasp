using DalContract;
using Entities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;

namespace DalDB
{
    public class DbClientNumberKeysDAO : IContractClientNumberKeysDAO
    {
        private readonly EntitesContext db;

        public DbClientNumberKeysDAO(IEntitesContext db)
        {
            this.db = (EntitesContext) db ?? throw new ArgumentNullException(nameof(db));
        }

        public int Add(ClientNumberKeys entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var client = db.ClientNumberKeys.Add(entity);

            
            var tmp = client.Id;
            db.SaveChanges();

            return client.Id;
        }

        public bool ContainsDB(ClientNumberKeys entity)
        {
            if (entity == null) 
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var kfc = db.ClientNumberKeys.SingleOrDefault(x => x.Id == entity.Id && x.Name == entity.Name);
            return kfc != null;
        }

        public List<ClientNumberKeys> GetAll() => db.ClientNumberKeys.ToList();

        public ClientNumberKeys GetById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("Неверное значение.", nameof(id));
            }

            var clnk = db.ClientNumberKeys.SingleOrDefault(kfc => kfc.Id == id);
            return clnk;
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var clientNumberKeys = GetById(id);
            if (clientNumberKeys == null)
                return false;

            db.ClientNumberKeys.Remove(clientNumberKeys);
            db.SaveChanges();
            return true;
        }

        public bool Update(ClientNumberKeys entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var existingEntity = db.ClientNumberKeys.Find(entity.Id);

            if (existingEntity == null)
                return false;

            existingEntity.Id = entity.Id;
            existingEntity.Name = entity.Name;

            db.SaveChanges();
            return true;
        }

    }
}