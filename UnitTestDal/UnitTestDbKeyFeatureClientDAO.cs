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
    [DeploymentItem("HASPKeyTest.db")]
    public class UnitTestDbKeyFeatureClientDAO
    {
        private const int erroneousId = -123;
        private IContractKeyFeatureClientDAO kfcDAO;

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void NullEntitesContextKeyFeatureClient()
        {
            Assert.ThrowsException<ArgumentNullException>(() => kfcDAO = new DbKeyFeatureClientDAO(null));
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void AddKeyFeatureClient()
        {
            int idExpected = 1;
            int add;

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                kfcDAO = new DbKeyFeatureClientDAO(db);
                add = kfcDAO.Add(CreateNew());                
            }

            Assert.AreEqual(idExpected, add);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void AddNullKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => kfcDAO.Add(null));
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
                kfcDAO = new DbKeyFeatureClientDAO(db);
                foreach(var kfc in keyFeatCls)
                    kfcDAO.Add(kfc);

                getAll = kfcDAO.GetAll();                
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
                kfcDAO = new DbKeyFeatureClientDAO(db);
                
                getAll = kfcDAO.GetAll();
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
                kfcDAO = new DbKeyFeatureClientDAO(db);
                kfcDAO.Add(CreateNew());
                getById = kfcDAO.GetById(1);                
            }

            Assert.AreEqual(getById, kfcExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByErroneousIdKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                Assert.ThrowsException<ArgumentException>(() => kfcDAO.GetById(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByIdNoDBKeyFeatureClient()
        {
            KeyFeatureClient getById;

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                kfcDAO = new DbKeyFeatureClientDAO(db);
                getById = kfcDAO.GetById(1);
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
                kfcDAO = new DbKeyFeatureClientDAO(db);
                kfcDAO.Add(CreateNew());
                update = kfcDAO.Update(new KeyFeatureClient
                {
                    Id           = 1,
                    IdClient     = 3,
                    IdKeyFeature = 34,
                    Initiator    = "______",
                    Note         = "_________",
                });
            }
            Assert.IsTrue(update);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateNullKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => kfcDAO.Update(null));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateNoDBKeyFeatureClient()
        {
            KeyFeatureClient kfcNoDB = new KeyFeatureClient
            {
                Id           = 345,
                IdClient     = 2354,
                IdKeyFeature = 23,
                Initiator    = "__",
                Note         = "-++",
            };

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                kfcDAO = new DbKeyFeatureClientDAO(db);
                kfcDAO.Add(CreateNew());
                Assert.IsFalse(kfcDAO.Update(kfcNoDB));
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

                kfcDAO = new DbKeyFeatureClientDAO(db);
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = kfcDAO.Remove(1);
            }

            Assert.IsTrue(remove);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveErroneousIdKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                Assert.ThrowsException<ArgumentException>(() => kfcDAO.Remove(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveNoDBHaspKey()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                kfcDAO = new DbKeyFeatureClientDAO(db);
                kfcDAO.Add(CreateNew());
                Assert.IsFalse(kfcDAO.Remove(12));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void ContainsDBKeyFeatureClient()
        {
            var keyFeatCl = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                kfcDAO = new DbKeyFeatureClientDAO(db);
                kfcDAO.Add(keyFeatCl);
                Assert.IsTrue(kfcDAO.ContainsDB(keyFeatCl));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void NoContainsDBKeyFeatureClient()
        {
            var keyFeatCl = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatureClients(db);
                kfcDAO = new DbKeyFeatureClientDAO(db);
                kfcDAO.Add(keyFeatCl);
                keyFeatCl.IdClient = 234;
                Assert.IsFalse(kfcDAO.ContainsDB(keyFeatCl));
            }
        }

        private KeyFeatureClient CreateNew()
        {
            return new KeyFeatureClient
            {
                IdClient     = 1,
                IdKeyFeature = 1,
                Initiator    = "Test Testovich",
                Note         = "Bla bla bla.",
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
