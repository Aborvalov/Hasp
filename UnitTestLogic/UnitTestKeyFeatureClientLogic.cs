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
    public class UnitTestKeyFeatureClientLogic
    {
        private const int erroneousId = -123;
        private IKeyFeatureClientLogic keyFeatureClientL;
        private IKeyFeatureClientLogic Get(EntitesContext db) => new Logics().CreateKeyFeatureClient(db);

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void NullEntitesContextKeyFeatureClient()
        {
            Assert.ThrowsException<ArgumentNullException>(() => keyFeatureClientL = Get(null));
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void SaveKeyFeatureClient()
        {
            bool add;

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = Get(db);
                add = keyFeatureClientL.Save(CreateNew());
            }

            Assert.IsTrue(add);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void SaveNullKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                keyFeatureClientL = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => keyFeatureClientL.Save(null));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void SaveDuplicateKeyFeatureClient()
        {
            bool add;
            KeyFeatureClient keyFeatureClient = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = Get(db);
                keyFeatureClientL.Save(keyFeatureClient);
                add = keyFeatureClientL.Save(keyFeatureClient);
            }

            Assert.IsFalse(add);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void ErroneousArgumentSaveKeyFeatureClient()
        {
            KeyFeatureClient keyFeatureClient = CreateNew();

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = Get(db);

                keyFeatureClient.Initiator = null;
                Assert.ThrowsException<ArgumentException>(() => keyFeatureClientL.Save(keyFeatureClient));
                keyFeatureClient.Initiator = string.Empty;
                Assert.ThrowsException<ArgumentException>(() => keyFeatureClientL.Save(keyFeatureClient));

                keyFeatureClient.Initiator = "____";
                keyFeatureClient.IdClient = 0;
                Assert.ThrowsException<ArgumentException>(() => keyFeatureClientL.Save(keyFeatureClient));
                keyFeatureClient.IdClient = -2;
                Assert.ThrowsException<ArgumentException>(() => keyFeatureClientL.Save(keyFeatureClient));

                keyFeatureClient.IdClient = 2;
                keyFeatureClient.IdKeyFeature = 0;
                Assert.ThrowsException<ArgumentException>(() => keyFeatureClientL.Save(keyFeatureClient));
                keyFeatureClient.IdKeyFeature = -2;
                Assert.ThrowsException<ArgumentException>(() => keyFeatureClientL.Save(keyFeatureClient));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetAllKeyFeatureClient()
        {
            var getAll = new List<KeyFeatureClient>(); ;
            var keyFeatCls = CreateListEntities.KeyFeatureClients();

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = Get(db);
                foreach (var kfc in keyFeatCls)
                    keyFeatureClientL.Save(kfc);

                getAll = keyFeatureClientL.GetAll();
            }

            CollectionAssert.AreEqual(getAll, keyFeatCls);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetAllEmptyKeyFeatureClient()
        {
            var getAll = new List<KeyFeatureClient>(); ;
            var kfcExpected = new List<KeyFeatureClient>();

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = Get(db);

                getAll = keyFeatureClientL.GetAll();
            }

            CollectionAssert.AreEqual(getAll, kfcExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByIdKeyFeatureClient()
        {
            KeyFeatureClient getById;
            KeyFeatureClient kfcExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = Get(db);
                keyFeatureClientL.Save(CreateNew());
                getById = keyFeatureClientL.GetById(1);
            }

            Assert.AreEqual(getById, kfcExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByErroneousIdKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                keyFeatureClientL = Get(db);
                Assert.ThrowsException<ArgumentException>(() => keyFeatureClientL.GetById(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByIdNoDBKeyFeatureClient()
        {
            KeyFeatureClient getById;

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = Get(db);
                getById = keyFeatureClientL.GetById(1);
            }

            Assert.IsNull(getById);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateKeyFeatureClient()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = Get(db);
                keyFeatureClientL.Save(CreateNew());
                update = keyFeatureClientL.Update(new KeyFeatureClient
                {
                    Id = 1,
                    IdClient = 3,
                    IdKeyFeature = 34,
                    Initiator = "______",
                    Note = "_________",
                });
            }
            Assert.IsTrue(update);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateDuplicateKeyFeatureClient()
        {
            bool update;
            var keyFeatureClient = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = Get(db);
                keyFeatureClientL.Save(keyFeatureClient);
                keyFeatureClient.Initiator = "?????";
                update = keyFeatureClientL.Update(CreateNew(2));
            }
            Assert.IsFalse(update);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateNullKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                keyFeatureClientL = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => keyFeatureClientL.Update(null));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateNoDBKeyFeatureClient()
        {
            KeyFeatureClient kfcNoDB = new KeyFeatureClient
            {
                Id = 345,
                IdClient = 2354,
                IdKeyFeature = 23,
                Initiator = "__",
                Note = "-++",
            };

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = Get(db);
                keyFeatureClientL.Save(CreateNew());
                Assert.IsFalse(keyFeatureClientL.Update(kfcNoDB));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveKeyFeatureClient()
        {
            bool remove;
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);

                keyFeatureClientL = Get(db);
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = keyFeatureClientL.Remove(1);
            }

            Assert.IsTrue(remove);
        }
 
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveErroneousIdKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                keyFeatureClientL = Get(db);
                Assert.ThrowsException<ArgumentException>(() => keyFeatureClientL.Remove(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveNoDBHaspKey()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                keyFeatureClientL = Get(db);
                keyFeatureClientL.Save(CreateNew());
                Assert.IsFalse(keyFeatureClientL.Remove(12));
            }
        }

        private KeyFeatureClient CreateNew()
        {
            return new KeyFeatureClient
            {
                IdClient = 1,
                IdKeyFeature = 1,
                Initiator = "Test Testovich",
                Note = "Bla bla bla.",
            };
        }

        private KeyFeatureClient CreateNew(int id)
        {
            KeyFeatureClient kfc = CreateNew();
            kfc.Id = id;
            return kfc;
        }
    }
}
