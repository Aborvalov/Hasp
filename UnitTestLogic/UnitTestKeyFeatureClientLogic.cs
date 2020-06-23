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
    /// <summary>
    /// Summary description for UnitTestKeyFeatureClient
    /// </summary>
    [TestClass]
    [DeploymentItem("HASPKeyTest.db")]
    public class UnitTestKeyFeatureClientLogic
    {
        private const int erroneousId = -123;
        private IKeyFeatureClientLogic keyFeatureClientL;
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void NullEntitesContextKeyFeatureClient()
        {
            Assert.ThrowsException<ArgumentNullException>(() => keyFeatureClientL = new KeyFeatureClientLogic(null));
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void SaveKeyFeatureClient()
        {
            bool add;

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
                add = keyFeatureClientL.Save(CreateNew());
            }

            Assert.IsTrue(add);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void SaveNullKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
                Assert.ThrowsException<ArgumentNullException>(() => keyFeatureClientL.Save(null));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void SaveDuplicateKeyFeatureClient()
        {
            bool add;
            KeyFeatureClient keyFeatureClient = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
                keyFeatureClientL.Save(keyFeatureClient);
                add = keyFeatureClientL.Save(keyFeatureClient);
            }

            Assert.IsFalse(add);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void ErroneousArgumentSaveKeyFeatureClient()
        {
            KeyFeatureClient keyFeatureClient = CreateNew();

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));

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
        [DeploymentItem("HASPKeyTest.db")]
        public void GetAllKeyFeatureClient()
        {
            var getAll = new List<KeyFeatureClient>(); ;
            var keyFeatCls = CreateListEntities.KeyFeatureClients();

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
                foreach (var kfc in keyFeatCls)
                    keyFeatureClientL.Save(kfc);

                getAll = keyFeatureClientL.GetAll();
            }

            CollectionAssert.AreEqual(getAll, keyFeatCls);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetAllEmptyKeyFeatureClient()
        {
            var getAll = new List<KeyFeatureClient>(); ;
            var kfcExpected = new List<KeyFeatureClient>();

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));

                getAll = keyFeatureClientL.GetAll();
            }

            CollectionAssert.AreEqual(getAll, kfcExpected);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByIdKeyFeatureClient()
        {
            KeyFeatureClient getById;
            KeyFeatureClient kfcExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
                keyFeatureClientL.Save(CreateNew());
                getById = keyFeatureClientL.GetById(1);
            }

            Assert.AreEqual(getById, kfcExpected);
        }
        /// <summary>
        /// Поиск неправильного id.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByErroneousIdKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
                Assert.ThrowsException<ArgumentException>(() => keyFeatureClientL.GetById(erroneousId));
            }
        }
        /// <summary>
        /// Поиск id которого нет в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByIdNoDBKeyFeatureClient()
        {
            KeyFeatureClient getById;

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
                getById = keyFeatureClientL.GetById(1);
            }

            Assert.IsNull(getById);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateKeyFeatureClient()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
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
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateDuplicateKeyFeatureClient()
        {
            bool update;
            var keyFeatureClient = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
                keyFeatureClientL.Save(keyFeatureClient);
                keyFeatureClient.Initiator = "?????";
                update = keyFeatureClientL.Update(CreateNew(2));
            }
            Assert.IsFalse(update);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateNullKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
                Assert.ThrowsException<ArgumentNullException>(() => keyFeatureClientL.Update(null));
            }
        }
        /// <summary>
        /// Обновление связи (ключ-фича)-клиент которой не существует в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
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
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
                keyFeatureClientL.Save(CreateNew());
                Assert.IsFalse(keyFeatureClientL.Update(kfcNoDB));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveKeyFeatureClient()
        {
            bool remove;
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);

                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = keyFeatureClientL.Remove(1);
            }

            Assert.IsTrue(remove);
        }
        /// <summary>
        /// Удаление неправильного id.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveErroneousIdKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
                Assert.ThrowsException<ArgumentException>(() => keyFeatureClientL.Remove(erroneousId));
            }
        }
        /// <summary>
        /// Удаление связи (ключ-фича)-клиент которой не существует в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveNoDBHaspKey()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                keyFeatureClientL = new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
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
        private KeyFeatureClient CreateNew(int id, int idClient, int idKeyFeature)
        {
            KeyFeatureClient kfc = CreateNew(id);
            kfc.IdClient = idClient;
            kfc.IdKeyFeature = idKeyFeature;
            return kfc;
        }
    }
}
