using Entities;
using HelperForUnitTest;
using Logic;
using LogicContract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestLogic
{
    [TestClass]
    [DeploymentItem("HASPKey.db")]
    public class UnitTestClientNumberKeysLogic
    {
        private const int erroneousId = -123;
        private IClientNumberKeysLogic clientNK;
        private IClientNumberKeysLogic Get(EntitesContext db) => new Logics().CreateClientNumberKeys(db);

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void NullIContractClientNumberKeysDAO() => Assert.ThrowsException<ArgumentNullException>(() => clientNK = Get(null));

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
        public void SaveClientNumberKeys()
        {
            bool add;
            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNK = Get(db);
                add = clientNK.Save(CreateNew());
            }
            Assert.IsTrue(add);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void SaveDuplicateClient()
        {
            bool add;
            ClientNumberKeys client = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNK = Get(db);
                clientNK.Save(client);
                add = clientNK.Save(client);
            }

            Assert.IsFalse(add);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void SaveNullClient()
        {
            using (var db = new EntitesContext())
            {
                clientNK = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => clientNK.Save(null));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void ErroneousArgumentSaveClient()
        {
            ClientNumberKeys client = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNK = Get(db);
                client.Id = 0;
                client.Name = null;
                Assert.ThrowsException<ArgumentException>(() => clientNK.Save(client));
                client.Name = string.Empty;
                Assert.ThrowsException<ArgumentException>(() => clientNK.Save(client));
                client.Name = "_____";
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
                clientNK = Get(db);

                foreach (var cl in clients)
                    clientNK.Save(cl);

                getAll = clientNK.GetAll();
            }
            CollectionAssert.AreEqual(getAll, clients);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetAllEmptyClient()
        {
            var getAll = new List<ClientNumberKeys>();
            var clientExpected = new List<ClientNumberKeys>();
            using (var db = new EntitesContext())
            {
                ClearTable.ClientNumberKeys(db);
                clientNK = Get(db);
                getAll = clientNK.GetAll();
            }
            CollectionAssert.AreEqual(getAll, clientExpected);
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
                clientNK = Get(db);
                clientNK.Save(CreateNew());
                getById = clientNK.GetById(1);
            }
            Assert.AreEqual(getById, clientExpected);
        }
    }
}
