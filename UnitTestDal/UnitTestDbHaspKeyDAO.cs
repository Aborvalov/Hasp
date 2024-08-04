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
    public class UnitTestDbHaspKeyDAO
    {
        private const int erroneousId = -123;
        private IContractHaspKeyDAO haspKeyDAO;
        private Client client;

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void NullEntitesContextHaspKey()
        {
            Assert.ThrowsException<ArgumentNullException>(() => haspKeyDAO = new DbHaspKeyDAO(null));
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void AddHaspKey()
        {
            int idExpected = 1;
            int add;

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);
                add = haspKeyDAO.Add(CreateNew());
            }
            Assert.AreEqual(add, idExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void AddNullHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => haspKeyDAO.Add(null));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void AddDuplicateHaspKey()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(CreateNew());
                Assert.AreEqual(haspKeyDAO.Add(CreateNew()), -1);
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetAllHaspKey()
        {
            var getAll = new List<HaspKey>(); ;
            var haspKeys = CreateListEntities.HaspKeys();

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);

                foreach(var key in haspKeys)
                    haspKeyDAO.Add(key);

                getAll = haspKeyDAO.GetAll();
            }

            CollectionAssert.AreEqual(getAll, haspKeys);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetAllEmptyHaspKey()
        {
            var getAll = new List<HaspKey>();
            var haspKeysExpected = new List<HaspKey>();

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);
                getAll = haspKeyDAO.GetAll();
            }

            CollectionAssert.AreEqual(getAll, haspKeysExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByIdHaspKey()
        {
            HaspKey getById;
            HaspKey keyExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(CreateNew());
                getById = haspKeyDAO.GetById(1);
            }

            Assert.AreEqual(getById, keyExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByErroneousIdHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentException>(() => haspKeyDAO.GetById(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByIdNoDBHaspKey()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.IsNull(haspKeyDAO.GetById(1));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateHaspKey()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);

                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(CreateNew());
                update = haspKeyDAO.Update(new HaspKey
                {
                    Id = 1,
                    InnerId = 23,
                    Number = "u2322",
                    IsHome = false,
                    TypeKey = TypeKey.Time,
                });
            }

            Assert.IsTrue(update);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateNullHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => haspKeyDAO.Update(null));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateDuplicateHaspKey()
        {
            var haspKey = CreateNew();

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);

                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(haspKey);
                haspKey.InnerId = 12;
                haspKeyDAO.Add(haspKey);

                Assert.IsFalse(haspKeyDAO.Update(CreateNew(2)));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateNoDBHaspKey()
        {
            var keyNoDB = new HaspKey
            {
                Id = 234,
                InnerId = 1546,
                Number = "uz-265",
                IsHome = false,
                TypeKey = TypeKey.NetTime,
            };

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(CreateNew());
                Assert.IsFalse(haspKeyDAO.Update(keyNoDB));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByActiveHaspKey()
        {
            List<HaspKey> GetByActive;
            var GetByActiveExpected = new List<HaspKey>
            {
                CreateNew(1),
            };

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);

                haspKeyDAO = new DbHaspKeyDAO(db);

                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.SaveChanges();

                GetByActive = haspKeyDAO.GetByActive();
            }

            CollectionAssert.AreEqual(GetByActive, GetByActiveExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByPastDueHaspKey()
        {
            List<HaspKey> GetByActive;
            var GetByActiveExpected = new List<HaspKey>
            { new HaspKey
                {
                    Id       = 2,
                    InnerId  = 2,
                    Number   = "uz-3",
                    IsHome = true,
                    TypeKey  = TypeKey.Pro,
                }
            };

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);
                haspKeyDAO = new DbHaspKeyDAO(db);

                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.SaveChanges();

                GetByActive = haspKeyDAO.GetByPastDue(client);
            }

            CollectionAssert.AreEqual(GetByActive, GetByActiveExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByClientHaspKey()
        {
            List<HaspKey> getByClient;
            var getByClientExpected = new List<HaspKey>
            {
                CreateNew(1),
            };

            var client = new Client
            {
                Id = 1,
                Name = "Ivanov Ivan",
            };

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);
                ClearTable.KeyFeatureClients(db);

                haspKeyDAO = new DbHaspKeyDAO(db);
                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                getByClient = haspKeyDAO.GetByClient(client);
            }

            CollectionAssert.AreEqual(getByClient, getByClientExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByNullClientHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => haspKeyDAO.GetByClient(null));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveHaspKey()
        {
            bool remove;
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);
                ClearTable.KeyFeatureClients(db);

                haspKeyDAO = new DbHaspKeyDAO(db);
                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = haspKeyDAO.Remove(1);
            }

            Assert.IsTrue(remove);
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveErroneousIdHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentException>(() => haspKeyDAO.Remove(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveNoDBHaspKey()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(CreateNew());
                Assert.IsFalse(haspKeyDAO.Remove(123));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void ContainsDBHaspKey()
        {
            var key = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(key);
                Assert.IsTrue(haspKeyDAO.ContainsDB(key));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void NoContainsDBHaspKey()
        {
            var key = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(key);
                key.InnerId = 234;
                Assert.IsFalse(haspKeyDAO.ContainsDB(key));
            }
        }

        private HaspKey CreateNew()
        {
            return new HaspKey
            {
                InnerId  = 1,
                Number   = "uz-2",
                IsHome = true,
                TypeKey  = TypeKey.Pro,
            };
        }

        private HaspKey CreateNew(int id)
        {
            HaspKey haspKey = CreateNew();
            haspKey.Id      = id;
            return haspKey;
        }
    }
}