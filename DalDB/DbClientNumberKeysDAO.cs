using DalContract;
using Entities;
using System;
using System.Collections.Generic;
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
                throw new ArgumentNullException(nameof(entity));

            var keyFeatureClient = db.ClientNumberKeys.Add(entity);

            db.SaveChanges();

            return keyFeatureClient.Id;
        }

        public bool ContainsDB(ClientNumberKeys entity)
        {
            var kfc = db.ClientNumberKeys.SingleOrDefault(x => x.Id == entity.Id);
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

            var clientNumberKeys = GetById(entity.Id);
            
            if (clientNumberKeys == null)
                return false;

            clientNumberKeys.Id = entity.Id;
            clientNumberKeys.Name = entity.Name;
   
            //clientNumberKeys.NumberKeys = entity.NumberKeys;
            //clientNumberKeys.NumberFeatures = entity.NumberFeatures;

            db.SaveChanges();

            return true;
        }
    }
}