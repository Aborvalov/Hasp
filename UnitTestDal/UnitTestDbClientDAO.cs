using DalContract;
using DalDB;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

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
                clientDAO = new DbClientDAO(db);
                add = clientDAO.Add(CreateNew());
                ClearTable.Clients(db);
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
        public void AddDuplicateClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(CreateNew());
                Assert.ThrowsException<DuplicateException>(() => clientDAO.Add(CreateNew()));
                ClearTable.Clients(db);
            }
        }
        [TestMethod]
        public void GetAllClient()
        {
            List<Client> getAll = new List<Client>();
            List<Client> clientExpected = new List<Client>();

            for (int i = 1; i <= 10; i++)
                clientExpected.Add(CreateNew(i, i.ToString() + "_eer cvc"));

            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);

                for (int i = 1; i <= 10; i++)
                    clientDAO.Add(CreateNew(i, i.ToString() + "_eer cvc"));

                getAll = clientDAO.GetAll();
                ClearTable.Clients(db);
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
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(CreateNew());
                getById = clientDAO.GetById(1);
                ClearTable.Clients(db);
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

                ClearTable.Clients(db);
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
        /// Дублирование клиента при обновлении.
        /// </summary>
        [TestMethod]
        public void UpdateDuplicateClient()
        {
            Client сlient = CreateNew();

            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(сlient);

                Client update = CreateNew(1);

                Assert.ThrowsException<DuplicateException>(
                    () => clientDAO.Update(update));
                ClearTable.Clients(db);
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
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(CreateNew());

                Assert.ThrowsException<NullReferenceException>(
                    () => clientDAO.Update(clientNoDB));

                ClearTable.Clients(db);
            }
        }
        [TestMethod]
        public void RemoveClient()
        {
            bool removeExpected = true;
            bool remove;
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                db.Clients.AddRange(CreateListEntities.Clients());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = clientDAO.Remove(1);

                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);
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
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(CreateNew());
                Assert.ThrowsException<NullReferenceException>(
                    () => clientDAO.Remove(123));
                ClearTable.Clients(db);
            }
        }
        [TestMethod]
        public void GetByFeatureClient()
        {
            List<Client> getByFeature;

            using (var db = new EntitesContext())
            {
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

                ClearTable.Features(db);
                ClearTable.KeyFeatures(db);
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);
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
                Assert.ThrowsException<ArgumentNullException>(() => clientDAO.GetByNumberKey(2));
            }
        }
        [TestMethod]
        public void GetByNumberKeyClient()
        {
            Client getByNumberKey;

            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.Clients.AddRange(CreateListEntities.Clients());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                getByNumberKey = clientDAO.GetByNumberKey(1);

                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);
            }

            Assert.AreEqual(getByNumberKey, CreateListEntities.Clients()[0]);
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
