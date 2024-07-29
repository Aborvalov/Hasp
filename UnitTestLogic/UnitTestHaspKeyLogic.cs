using Entities;
using HelperForUnitTest;
using Logic;
using LogicContract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestLogic
{
    /// <summary>
    /// Summary description for UnitTestHaspKey
    /// </summary>
    [TestClass]
    [DeploymentItem("HASPKey.db")]
    public class UnitTestHaspKeyLogic
    {
        private const int erroneousId = -123;
        private IHaspKeyLogic haspKeyL;
        private Client client;

        private IHaspKeyLogic Get(EntitesContext db) => new Logics().CreateHaspKey(db);
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void NullEntitesContextHaspKey()
        {
            Assert.ThrowsException<ArgumentNullException>(() => haspKeyL = Get(null));
        }
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void SaveHaspKey()
        {
            bool add;

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyL = Get(db);
                add = haspKeyL.Save(CreateNew());
            }
            Assert.IsTrue(add);
        }
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void SaveNullHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyL = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => haspKeyL.Save(null));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void SaveDuplicateHaspKey()
        {
            bool add;
            HaspKey haspKey = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyL = Get(db);
                haspKeyL.Save(haspKey);
                add = haspKeyL.Save(haspKey);
            }
            Assert.IsFalse(add);
        }
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void ErroneousArgumentSaveHaspKey()
        {
            HaspKey haspKey = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyL = Get(db);

                haspKey.InnerId = -1456;                        
                Assert.ThrowsException<ArgumentException>(() => haspKeyL.Save(haspKey));

                haspKey.InnerId = 234;
                haspKey.Number = null;
                Assert.ThrowsException<ArgumentException>(() => haspKeyL.Save(haspKey));
                haspKey.Number = string.Empty;
                Assert.ThrowsException<ArgumentException>(() => haspKeyL.Save(haspKey));

                haspKey.Number = "____";
                haspKey.TypeKey = (TypeKey)12;
                Assert.ThrowsException<ArgumentException>(() => haspKeyL.Save(haspKey));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetAllHaspKey()
        {
            var getAll = new List<HaspKey>(); ;
            var haspKeys = CreateListEntities.HaspKeys();

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyL = Get(db);

                foreach (var key in haspKeys)
                    haspKeyL.Save(key);

                getAll = haspKeyL.GetAll();
            }

            CollectionAssert.AreEqual(getAll, haspKeys);
        }
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetAllEmptyHaspKey()
        {
            var getAll = new List<HaspKey>();
            var haspKeysExpected = new List<HaspKey>();

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyL = Get(db);
                getAll = haspKeyL.GetAll();
            }

            CollectionAssert.AreEqual(getAll, haspKeysExpected);
        }
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByIdHaspKey()
        {
            HaspKey getById;
            HaspKey keyExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyL = Get(db);
                haspKeyL.Save(CreateNew());
                getById = haspKeyL.GetById(1);
            }

            Assert.AreEqual(getById, keyExpected);
        }
        /// <summary>
        /// Поиск неправильного id.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByErroneousIdHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyL = Get(db);
                Assert.ThrowsException<ArgumentException>(() => haspKeyL.GetById(erroneousId));
            }
        }
        /// <summary>
        /// Поиск id которого нет в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByIdNoDBHaspKey()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyL = Get(db);
                Assert.IsNull(haspKeyL.GetById(1));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateHaspKey()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);

                haspKeyL = Get(db);
                haspKeyL.Save(CreateNew());
                update = haspKeyL.Update(new HaspKey
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
        [DeploymentItem("HASPKey.db")]
        public void UpdateNullHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyL = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => haspKeyL.Update(null));
            }
        }
        /// <summary>
        /// Дублирование ключа при обновлении.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateDuplicateHaspKey()
        {
            var haspKey = CreateNew();

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);

                haspKeyL = Get(db);
                haspKeyL.Save(haspKey);
                haspKey.InnerId = 12;
                haspKeyL.Save(haspKey);

                Assert.IsFalse(haspKeyL.Update(CreateNew(2)));
            }
        }
        /// <summary>
        /// Обновление ключа которого не существует в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
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
                haspKeyL = Get(db);
                haspKeyL.Save(CreateNew());
                Assert.IsFalse(haspKeyL.Update(keyNoDB));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
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

                haspKeyL = Get(db);

                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.SaveChanges();

                GetByActive = haspKeyL.GetByActive();
            }

            CollectionAssert.AreEqual(GetByActive, GetByActiveExpected);
        }
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
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
                haspKeyL = Get(db);

                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.SaveChanges();

                GetByActive = haspKeyL.GetByPastDue(client);
            }

            CollectionAssert.AreEqual(GetByActive, GetByActiveExpected);
        }
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
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

                haspKeyL = Get(db);
                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                getByClient = haspKeyL.GetByClient(client);
            }

            CollectionAssert.AreEqual(getByClient, getByClientExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByNullClientHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyL = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => haspKeyL.GetByClient(null));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveHaspKey()
        {
            bool remove;
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);
                ClearTable.KeyFeatureClients(db);

                haspKeyL = Get(db);
                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = haspKeyL.Remove(1);
            }

            Assert.IsTrue(remove);
        }
        /// <summary>
        /// Удаление неправильного id.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveErroneousIdHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyL = Get(db);
                Assert.ThrowsException<ArgumentException>(() => haspKeyL.Remove(erroneousId));
            }
        }
        /// <summary>
        /// Удаление ключа которого не существует в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveNoDBHaspKey()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyL = Get(db);
                haspKeyL.Save(CreateNew());
                Assert.IsFalse(haspKeyL.Remove(123));
            }
        }
        private HaspKey CreateNew()
        {
            return new HaspKey
            {
                InnerId = 1,
                Number = "uz-2",
                IsHome = true,
                TypeKey = TypeKey.Pro,
            };
        }
        private HaspKey CreateNew(int id)
        {
            HaspKey haspKey = CreateNew();
            haspKey.Id = id;
            return haspKey;
        }
        private HaspKey CreateNew(int id, int innerId)
        {
            HaspKey haspKey = CreateNew(id);
            haspKey.InnerId = innerId;
            return haspKey;
        }
    }
}
