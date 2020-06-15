using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DalDB
{
    public class DbClientDAO : IContractClientDAO
    {
        private EntitesContext Db { get; }

        public DbClientDAO(EntitesContext db)
        {
            this.Db = db ?? throw new ArgumentNullException(nameof(db));
        }
        public int Add(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (ContainsDB(entity) != -1)
                throw new Exception("Данный клиент имеется в базе.");

            var client = Db.Clients.Add(entity);
            Db.SaveChanges();

            return client.Id;
        }

        public IEnumerable<Client> GetAll() => Db.Clients.ToList();
        
        public IEnumerable<Client> GetByFeature(Feature feature)
        {
            if (feature == null)
                throw new ArgumentNullException(nameof(feature));

            var keyFeatures = Db.KeyFeatures.ToList();
            var keyFeatureCliets = Db.KeyFeatureClients.ToList();
            var clients = GetAll();

            var clientFeature = (from kfc in keyFeatureCliets
                                 join kf in keyFeatures
                                   on kfc.IdKeyFeature equals kf.Id
                                 join c in clients
                                   on kfc.IdClient equals c.Id
                                where kf.IdFeature == feature.Id
                               select new Client
                                 {
                                     Id            = c.Id,
                                     Name          = c.Name,
                                     Address       = c.Address,
                                     ContactPerson = c.ContactPerson,
                                     Phone         = c.Phone,
                                 })
                                 .ToList();

            #region SQlзапрос
            /*
             select c.*
               from KeyFeatureClients as kfc join KeyFeatures as kf
                 on kfc.IdKeyFeature = kf.Id
               join Clients as c on c.Id = kfc.IdClient
              where kf.IdFeature = 1
             */
            #endregion

            return clientFeature;
        }

        public Client GetById(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            var client = Db.Clients.SingleOrDefault(c => c.Id == id);
            return client;
        }
        
        public Client GetByNumberKey(int numberKay)
        {
            if (numberKay < 1)
                throw new ArgumentException("Неверное значение.", nameof(numberKay));

            var haspKey = Db.HaspKeys.SingleOrDefault(hk => hk.InnerId == numberKay);
            if (haspKey == null)
                throw new ArgumentNullException(nameof(haspKey),"HASP-ключ с данным номерем не найдн.");

            var keyFeatures = Db.KeyFeatures.ToList();
            var keyFeatureCliets = Db.KeyFeatureClients.ToList();
            var haspKeys = Db.HaspKeys.ToList();

            int idClient = (from kfc in keyFeatureCliets
                            join kf in keyFeatures
                              on kfc.IdKeyFeature equals kf.Id
                            join hk in haspKeys
                              on kf.IdHaspKey equals hk.Id
                           where hk.InnerId == numberKay
                          select kfc.IdClient)
                           .First();

            return GetById(idClient);

            #region SQL запрос.
            /*
              select *
                from Clients
                where id = (select distinct kfc.IdClient
                              from KeyFeatureClients as kfc join KeyFeatures as kf
                                   on kfc.IdKeyFeature = kf.Id
                                   join HaspKeys as hk on kf.IdHaspKey = hk.Id
                             where hk.InnerId = 12 )

             */
            #endregion
        }

        public bool Remove(int id)
        {
            if (id < 1)
                throw new ArgumentException("Неверное значение.", nameof(id));

            Client client = CheckClientInDb(id);

            List<KeyFeatureClient> keyFeatureClients = Db.KeyFeatureClients
                                                         .Where(kfc => kfc.IdClient == id)
                                                         .ToList();

            List<KeyFeature> keyFeatures;
            try
            {
                Db.Clients.Remove(client);

                foreach (var kfc in keyFeatureClients)
                {
                    Db.KeyFeatureClients.Remove(kfc);

                    keyFeatures = Db.KeyFeatures
                                    .Where(kf => kf.Id == kfc.IdKeyFeature)
                                    .ToList();

                    foreach (var kf in keyFeatures)
                        Db.KeyFeatures.Remove(kf);
                }

                Db.SaveChanges();
            }
            catch(NullReferenceException)
            {
                return false;
            }
            catch
            {
                throw;
            }
            
            return true;
        }

        public bool Update(Client entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (ContainsDB(entity) != -1)
                throw new Exception("Данный клиент имеется в базе.");

            Client client = CheckClientInDb(entity.Id);

            client.Name          = entity.Name;
            client.Address       = entity.Address;
            client.ContactPerson = entity.ContactPerson;
            client.Phone         = entity.Phone;

            Db.SaveChanges();
            return true;
        }

        /// <summary>
        /// Проверка клиента на наличие в базе.
        /// </summary>
        /// <param name="id">id клиента.</param>
        /// <returns>Клиент.</returns>
        private Client CheckClientInDb(int id)
        {
            var client = GetById(id);
            if (client == null)
                throw new NullReferenceException("Объект не найден в базе, " + nameof(client));
            return client;
        }

        /// <summary>
        /// Проверка на дубли.
        /// </summary>
        /// <param name="entity">Клиент.</param>
        /// <returns>Результат проверки.</returns>
        private int ContainsDB(Client entity)
        {
            var tt = Db.Clients.ToList();
            int id = Db.Clients
                       .SingleOrDefault(c => c.Name == entity.Name)
                       ?.Id ?? -1;
            return id;
        }
    }
}
