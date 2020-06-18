using DalContract;
using DalDB;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestDal
{
    [TestClass]
    public class UnitTestDbClientDAO
    {
        private IContractClientDAO clientDAO;
        [TestMethod]
        public void NullEntitesContextClient()
        {
            Assert.ThrowsException<ArgumentNullException>(() => clientDAO = new DbClientDAO(null));
        }
        [TestMethod]
        public void AddClient()
        {
            int idExpected = 1;
            int add;

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                add = clientDAO.Add(CreateNew());               
            }

            Assert.AreEqual(add, idExpected);
        }
        [TestMethod]
        public void AddNullClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => clientDAO.Add(null));
            }
        }       
        [TestMethod]
        public void GetAllClient()
        {
            var getAll = new List<Client>();
            var clientExpected = new List<Client>();

            for (int i = 1; i <= 10; i++)
                clientExpected.Add(CreateNew(i, i.ToString() + "_eer cvc"));

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);

                for (int i = 1; i <= 10; i++)
                    clientDAO.Add(CreateNew(i, i.ToString() + "_eer cvc"));

                getAll = clientDAO.GetAll();               
            }

            CollectionAssert.AreEqual(getAll, clientExpected);
        }
        public void GetAllEmptyHaspKey()
        {
            var getAll = new List<Client>();
            var clientExpected = new List<Client>();

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                getAll = clientDAO.GetAll();
            }
            CollectionAssert.AreEqual(getAll, clientExpected);
        }
        [TestMethod]
        public void GetByIdClient()
        {
            Client getById;
            Client clientExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(CreateNew());
                getById = clientDAO.GetById(1);               
            }

            Assert.AreEqual(getById, clientExpected);
        }
        /// <summary>
        /// Поиск неправильного id.
        /// </summary>
        [TestMethod]
        public void GetByErroneousIdClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.ThrowsException<ArgumentException>(() => clientDAO.GetById(-236));
            }
        }
        /// <summary>
        /// Поиск id которого нет в базе.
        /// </summary>
        [TestMethod]
        public void GetByIdNoDBClient()
        {
            Client getById;

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                getById = clientDAO.GetById(1);
            }

            Assert.AreEqual(getById, null);
        }
        [TestMethod]
        public void UpdateClient()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(CreateNew());
                update = clientDAO.Update(new Client
                {
                    Id            = 1,
                    Name          = "____",
                    Address       = "____",
                    ContactPerson = "____",
                    Phone         = "____",
                });
            }

            Assert.AreEqual(update, true);
        }
        [TestMethod]
        public void UpdateNullClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => clientDAO.Update(null));
            }
        }        
        /// <summary>
        /// Обновление клиента которого не существует в базе.
        /// </summary>
        [TestMethod]
        public void UpdateNoDBClient()
        {
            Client clientNoDB = new Client
            {
                Id            = 234,
                Name          = "______",
                ContactPerson = "______",
                Address       = "______",
                Phone         = "______",
            };

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(CreateNew());

                Assert.AreEqual(clientDAO.Update(clientNoDB), false);
            }
        }
        [TestMethod]
        public void RemoveClient()
        {
            bool removeExpected = true;
            bool remove;
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);

                clientDAO = new DbClientDAO(db);
                db.Clients.AddRange(CreateListEntities.Clients());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = clientDAO.Remove(1);
            }

            Assert.AreEqual(remove, removeExpected);
        }
        /// <summary>
        /// Удаление неправильного id.
        /// </summary>
        [TestMethod]
        public void RemoveErroneousIdClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.ThrowsException<ArgumentException>(() => clientDAO.Remove(-3453));
            }
        }
        /// <summary>
        /// Удаление фичи которой не существует в базе.
        /// </summary>
        [TestMethod]
        public void RemoveNoDBClient()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(CreateNew());
                Assert.AreEqual(clientDAO.Remove(123), false);
                
            }
        }
        [TestMethod]
        public void GetByFeatureClient()
        {
            List<Client> getByFeature;

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                ClearTable.KeyFeatures(db);
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);

                clientDAO = new DbClientDAO(db);
                db.Features.AddRange(CreateListEntities.Features());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.Clients.AddRange(CreateListEntities.Clients());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                getByFeature = clientDAO.GetByFeature(new Feature
                {
                    Id     = 1,
                    Number = 1,
                    Name   = "qwe",
                });
            }

            CollectionAssert.AreEqual(getByFeature, CreateListEntities.Clients());
        }
        [TestMethod]
        public void GetByNullFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => clientDAO.GetByFeature(null));
            }
        }
        [TestMethod]
        public void GetByErroneousNumberKeyClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.ThrowsException<ArgumentException>(() => clientDAO.GetByNumberKey(-234));
            }
        }
        [TestMethod]
        public void GetByNumberKeyNoDBClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.AreEqual(clientDAO.GetByNumberKey(2), null);
            }
        }
        [TestMethod]
        public void GetByNumberKeyClient()
        {
            Client getByNumberKey;

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);

                clientDAO = new DbClientDAO(db);
                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.Clients.AddRange(CreateListEntities.Clients());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                getByNumberKey = clientDAO.GetByNumberKey(1);
            }

            Assert.AreEqual(getByNumberKey, CreateListEntities.Clients()[0]);
        }
        [TestMethod]
        public void ContainsDBClient()
        {
            var client = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(client);
                Assert.AreEqual(clientDAO.ContainsDB(client), true);
            }
        }
        [TestMethod]
        public void NoContainsDBClient()
        {
            var client = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(client);
                client.Name = "asdasd";
                Assert.AreEqual(clientDAO.ContainsDB(client), false);
            }
        }
        private Client CreateNew()
        {
            return new Client
            {
                Name          = "OOO Forst 98",
                Address       = "pr.Stroiteley 45",
                ContactPerson = "Ivanov Ivan",
                Phone         = "8-123-432-12-21",
            };
        }
        private Client CreateNew(int id)
        {
            Client client = CreateNew();
            client.Id     = id;
            return client;
        }
        private Client CreateNew(int id, string name)
        {
            Client client = CreateNew(id);
            client.Name   = name;
            return client;
        }
    }
}
