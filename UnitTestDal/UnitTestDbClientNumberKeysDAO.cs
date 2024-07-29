using DalContract;
using DalDB;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HelperForUnitTest;

namespace UnitTestDal
{
    [TestClass]
    [DeploymentItem("HASPKey.db")]
    public class UnitTestDbClientNumberKeys
    {
        private const int erroneousId = -123;
        private IContractClientNumberKeysDAO clientNumberKeysDAO;

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void NullEntitesContextClientNumberKeys()
        {
            Assert.ThrowsException<ArgumentNullException>(() => clientNumberKeysDAO = new DbClientNumberKeysDAO(null));
        }

        private ClientNumberKeys CreateNew()
        {
            return new ClientNumberKeys
            {
                Id = 1,
                Name = "OOO Forest 98",
            };
        }
        private ClientNumberKeys CreateNew(int id)
        {
            ClientNumberKeys client = CreateNew();
            client.Id = id;
            return client;
        }
        private ClientNumberKeys CreateNew(int id, string name)
        {
            ClientNumberKeys client = CreateNew(id);
            client.Name = name;
            return client;
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void AddClientNK()
        {
            int idExpected = 1;
            int add;

            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                add = clientNumberKeysDAO.Add(CreateNew());
            }

            Assert.AreEqual(add, idExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void AddNullClient()
        {
            using (var db = new EntitesContext())
            {
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => clientNumberKeysDAO.Add(null));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetAllClient()
        {
            List<ClientNumberKeys> getAll;
            var clients = CreateListEntities.ClientNumberKeys();

            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);

                foreach (var cl in clients)
                    clientNumberKeysDAO.Add(cl);

                getAll = clientNumberKeysDAO.GetAll();
            }

            CollectionAssert.AreEqual(getAll, clients);
        }
        
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByIdClient()
        {
            ClientNumberKeys getById;
            ClientNumberKeys clientExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                clientNumberKeysDAO.Add(CreateNew());
                getById = clientNumberKeysDAO.GetById(1);
            }

            Assert.AreEqual(getById, clientExpected);
        }
       
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByErroneousIdClient()
        {
            using (var db = new EntitesContext())
            {
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                Assert.ThrowsException<ArgumentException>(() => clientNumberKeysDAO.GetById(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByIdNoDBClient()
        {
            ClientNumberKeys getById;

            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                getById = clientNumberKeysDAO.GetById(1);
            }

            Assert.IsNull(getById);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateClient()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                clientNumberKeysDAO.Add(CreateNew());
                update = clientNumberKeysDAO.Update(new ClientNumberKeys
                {
                    Id = 1,
                    Name = "____",
                });
            }

            Assert.IsTrue(update);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateNullClient()
        {
            using (var db = new EntitesContext())
            {
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => clientNumberKeysDAO.Update(null));
            }
        }
        
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateNoDBClient()
        {
            ClientNumberKeys clientNoDB = new ClientNumberKeys
            {
                Id = 234,
                Name = "______",
            };

            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                clientNumberKeysDAO.Add(CreateNew());

                Assert.IsFalse(clientNumberKeysDAO.Update(clientNoDB));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveClient()
        {
            bool remove;
            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                ClearTable.KeyFeatureClients(db);

                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                db.ClientNumberKeys.AddRange(CreateListEntities.ClientNumberKeys());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = clientNumberKeysDAO.Remove(1);
            }

            Assert.IsTrue(remove);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveErroneousIdClient()
        {
            using (var db = new EntitesContext())
            {
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                Assert.ThrowsException<ArgumentException>(() => clientNumberKeysDAO.Remove(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveNoDBClient()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                clientNumberKeysDAO.Add(CreateNew());
                Assert.IsFalse(clientNumberKeysDAO.Remove(123));

            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void ContainsDBClient()
        {
            var client = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                clientNumberKeysDAO.Add(client);
                Assert.IsTrue(clientNumberKeysDAO.ContainsDB(client));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void NoContainsDBClient()
        {
            var client = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNumberKeysDAO = new DbClientNumberKeysDAO(db);
                clientNumberKeysDAO.Add(client);
                client.Name = "asdasd";
                Assert.IsFalse(clientNumberKeysDAO.ContainsDB(client));
            }
        }
    }
}