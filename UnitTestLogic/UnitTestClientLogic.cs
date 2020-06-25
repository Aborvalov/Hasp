using System;
using System.Collections.Generic;
using DalDB;
using Entities;
using Logic;
using LogicContract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelperForUnitTest;

namespace UnitTestLogic
{
    [TestClass]
    [DeploymentItem("HASPKeyTest.db")]
    public class UnitTestClientLogic
    {
        private const int erroneousId = -123;
        private IClientLogic clientL;
        private IClientLogic Get(EntitesContext db) => new ClientLogic(new DbClientDAO(db));
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void NullIContractClientDAO()
        {
            Assert.ThrowsException<ArgumentNullException>(() => clientL = Get(null));
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void SaveClient()
        {
            bool add;

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientL = Get(db);
                add = clientL.Save(CreateNew());
            }

            Assert.IsTrue(add);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void SaveDuplicateClient()
        {
            bool add;
            Client client = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientL = Get(db);
                clientL.Save(client);
                add = clientL.Save(client);
            }

            Assert.IsFalse(add);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void SaveNullClient()
        {
            using (var db = new EntitesContext())
            {
                clientL = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => clientL.Save(null));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void ErroneousArgumentSaveClient()
        {
            Client client = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientL = Get(db);

                client.Name = null;
                Assert.ThrowsException<ArgumentException>(() => clientL.Save(client));
                client.Name = string.Empty;
                Assert.ThrowsException<ArgumentException>(() => clientL.Save(client));

                client.Name = "_____";
                client.Address = null;
                Assert.ThrowsException<ArgumentException>(() => clientL.Save(client));
                client.Address = string.Empty;
                Assert.ThrowsException<ArgumentException>(() => clientL.Save(client));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetAllClient()
        {
            List<Client> getAll;
            var clients = CreateListEntities.Clients();

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientL = Get(db);

                foreach (var cl in clients)
                    clientL.Save(cl);

                getAll = clientL.GetAll();
            }

            CollectionAssert.AreEqual(getAll, clients);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetAllEmptyClient()
        {
            var getAll = new List<Client>();
            var clientExpected = new List<Client>();

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientL = Get(db);
                getAll = clientL.GetAll();
            }
            CollectionAssert.AreEqual(getAll, clientExpected);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByIdClient()
        {
            Client getById;
            Client clientExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientL = Get(db);
                clientL.Save(CreateNew());
                getById = clientL.GetById(1);
            }

            Assert.AreEqual(getById, clientExpected);
        }
        /// <summary>
        /// Поиск неправильного id.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByErroneousIdClient()
        {
            using (var db = new EntitesContext())
            {
                clientL = Get(db);
                Assert.ThrowsException<ArgumentException>(() => clientL.GetById(erroneousId));
            }
        }
        /// <summary>
        /// Поиск id которого нет в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByIdNoDBClient()
        {
            Client getById;

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientL = Get(db);
                getById = clientL.GetById(1);
            }

            Assert.IsNull(getById);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateClient()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientL = Get(db);
                clientL.Save(CreateNew());
                update = clientL.Update(new Client
                {
                    Id = 1,
                    Name = "____",
                    Address = "____",
                    ContactPerson = "____",
                    Phone = "____",
                });
            }

            Assert.IsTrue(update);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateDuplicateClient()
        {
            bool update;
            var client = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientL = Get(db);
                clientL.Save(client);
                client.Address = "??????";
                clientL.Save(client);
                update = clientL.Update(CreateNew(2));
            }

            Assert.IsFalse(update);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateNullClient()
        {
            using (var db = new EntitesContext())
            {
                clientL = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => clientL.Update(null));
            }
        }
        /// <summary>
        /// Обновление клиента которого не существует в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateNoDBClient()
        {
            Client clientNoDB = new Client
            {
                Id = 234,
                Name = "______",
                ContactPerson = "______",
                Address = "______",
                Phone = "______",
            };

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientL = Get(db);
                clientL.Save(CreateNew());

                Assert.IsFalse(clientL.Update(clientNoDB));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveClient()
        {
            bool remove;
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);

                clientL = Get(db);
                db.Clients.AddRange(CreateListEntities.Clients());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = clientL.Remove(1);
            }

            Assert.IsTrue(remove);
        }
        /// <summary>
        /// Удаление неправильного id.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveErroneousIdClient()
        {
            using (var db = new EntitesContext())
            {
                clientL = Get(db);
                Assert.ThrowsException<ArgumentException>(() => clientL.Remove(erroneousId));
            }
        }
        /// <summary>
        /// Удаление фичи которой не существует в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveNoDBClient()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientL = Get(db);
                clientL.Save(CreateNew());
                Assert.IsFalse(clientL.Remove(123));

            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByFeatureClient()
        {
            List<Client> getByFeature;

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                ClearTable.KeyFeatures(db);
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);

                clientL = Get(db);
                db.Features.AddRange(CreateListEntities.Features());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.Clients.AddRange(CreateListEntities.Clients());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                getByFeature = clientL.GetByFeature(new Feature
                {
                    Id = 1,
                    Number = 1,
                    Name = "qwe",
                });
            }

            CollectionAssert.AreEqual(getByFeature, CreateListEntities.Clients());
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByNullFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                clientL = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => clientL.GetByFeature(null));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByErroneousNumberKeyClient()
        {
            using (var db = new EntitesContext())
            {
                clientL = Get(db);
                Assert.ThrowsException<ArgumentException>(() => clientL.GetByNumberKey(erroneousId));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByNumberKeyNoDBClient()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                clientL = Get(db);
                Assert.IsNull(clientL.GetByNumberKey(2));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByNumberKeyClient()
        {
            Client getByNumberKey;
            Client actual = CreateListEntities.Clients()[0];

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);

                clientL = Get(db);
                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.Clients.AddRange(CreateListEntities.Clients());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                getByNumberKey = clientL.GetByNumberKey(1);
            }

            Assert.AreEqual(getByNumberKey, actual);
        }  
        private Client CreateNew()
        {
            return new Client
            {
                Name = "OOO Forst 98",
                Address = "pr.Stroiteley 45",
                ContactPerson = "Ivanov Ivan",
                Phone = "8-123-432-12-21",
            };
        }
        private Client CreateNew(int id)
        {
            Client client = CreateNew();
            client.Id = id;
            return client;
        }
        private Client CreateNew(int id, string name)
        {
            Client client = CreateNew(id);
            client.Name = name;
            return client;
        }
    }
}
