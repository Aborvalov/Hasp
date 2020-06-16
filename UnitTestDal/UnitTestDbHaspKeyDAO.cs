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
    public class UnitTestDbHaspKeyDAO
    {
        private IContractHaspKeyDAO haspKeyDAO;
        [TestMethod]
        public void NullEntitesContextHaspKey()
        {
            Assert.ThrowsException<ArgumentNullException>(() => haspKeyDAO = new DbHaspKeyDAO(null));
        }
        [TestMethod]
        public void AddHaspKey()
        {
            int idExpected = 1;
            int add;
            
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                add = haspKeyDAO.Add(CreateNew());
                ClearTable.HaspKeys(db);
            }

            Assert.AreEqual(add, idExpected);
        }
        [TestMethod]
        public void AddNullHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => haspKeyDAO.Add(null));
            }
        }
        [TestMethod]
        public void AddDuplicateHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(CreateNew());
                Assert.ThrowsException<Exception>(() => haspKeyDAO.Add(CreateNew()));
                ClearTable.HaspKeys(db);
            }
        }
        [TestMethod]
        public void GetAllHaspKey()
        {
            List<HaspKey> getAll = new List<HaspKey>(); ;
            List<HaspKey> haspKeysExpected = new List<HaspKey>();

            for (int i = 1; i <= 10; i++)
                haspKeysExpected.Add(CreateNew(i,i));

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);

                for (int i = 1; i <= 10; i++)
                    haspKeyDAO.Add(CreateNew(i,i));

                getAll = haspKeyDAO.GetAll().ToList();
                ClearTable.HaspKeys(db);
            }

            CollectionAssert.AreEqual(getAll, haspKeysExpected);
        }
        [TestMethod]
        public void GetByIdHaspKey()
        {
            HaspKey getById;
            HaspKey keyExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(CreateNew());
                getById = haspKeyDAO.GetById(1);
                ClearTable.HaspKeys(db);
            }

            Assert.AreEqual(getById, keyExpected);
        }
        /// <summary>
        /// Поиск неправильного id.
        /// </summary>
        [TestMethod]
        public void GetByErroneousIdHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentException>(() => haspKeyDAO.GetById(-412536));
            }
        }
        /// <summary>
        /// Поиск id которого нет в базе.
        /// </summary>
        [TestMethod]
        public void GetByIdNoDBHaspKey()
        {
            HaspKey getById;

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                getById = haspKeyDAO.GetById(1);
            }

            Assert.AreEqual(getById, null);
        }
        [TestMethod]
        public void UpdateHaspKey()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(CreateNew());
                update = haspKeyDAO.Update(new HaspKey
                {
                    Id       = 1,
                    InnerId  = 23,
                    Number   = "u2322",
                    Location = false,
                    TypeKey  = TypeKey.Time,
                });

                ClearTable.HaspKeys(db);
            }

            Assert.AreEqual(update, true);
        }
        [TestMethod]
        public void UpdateNullHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => haspKeyDAO.Update(null));
            }
        }
        /// <summary>
        /// Дублирование ключа при обновлении.
        /// </summary>
        [TestMethod]
        public void UpdateDuplicateHaspKey()
        {
            HaspKey haspKey = CreateNew();

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(haspKey);

                HaspKey update = CreateNew(1);
                
                Assert.ThrowsException<Exception>(
                    () => haspKeyDAO.Update(update));
                ClearTable.HaspKeys(db);
            }
        }
        /// <summary>
        /// Обновление ключа которого не существует в базе.
        /// </summary>
        [TestMethod]
        public void UpdateNoDBHaspKey()
        {
            HaspKey keyNoDB = new HaspKey
            {
                Id = 234,
                InnerId = 1546,
                Number = "uz-265",
                Location = false,
                TypeKey = TypeKey.NetTime,
            };

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(CreateNew());
                Assert.ThrowsException<NullReferenceException>(
                    () => haspKeyDAO.Update(keyNoDB));
                ClearTable.HaspKeys(db);
            }
        }
        [TestMethod]
        public void GetByActiveHaspKey()
        {
            List<HaspKey> GetByActive;
            List<HaspKey> GetByActiveExpected = new List<HaspKey>
            {
                CreateNew(1),
            };

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);

                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.SaveChanges();

                GetByActive = haspKeyDAO.GetByActive().ToList();

                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);
            }

            CollectionAssert.AreEqual(GetByActive, GetByActiveExpected);
        }
        [TestMethod]
        public void GetByPastDueHaspKey()
        {
            List<HaspKey> GetByActive;
            List<HaspKey> GetByActiveExpected = new List<HaspKey>
            { new HaspKey
                {
                    Id       = 2,
                    InnerId  = 2,
                    Number   = "uz-3",
                    Location = true,
                    TypeKey  = TypeKey.Pro,
                }
            };

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);

                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.SaveChanges();

                GetByActive = haspKeyDAO.GetByPastDue().ToList();

                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);
            }

            CollectionAssert.AreEqual(GetByActive, GetByActiveExpected);
        }
        [TestMethod]
        public void GetByClientHaspKey()
        {
            List<HaspKey> getByClient;
            List<HaspKey> getByClientExpected = new List<HaspKey>
            {
                CreateNew(1),
            };

            Client client = new Client
            {
                Id = 1,
                Name = "Ivanov Ivan",
            };

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());                
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                getByClient = haspKeyDAO.GetByClient(client).ToList();

                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);
                ClearTable.KeyFeatureClients(db);
            }

            CollectionAssert.AreEqual(getByClient, getByClientExpected);
        }

        [TestMethod]
        public void GetByNullClientHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => haspKeyDAO.GetByClient(null));
            }
        }

        [TestMethod]
        public void RemoveHaspKey()
        {
            bool removeExpected = true;
            bool remove;
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = haspKeyDAO.Remove(1);
                
                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);
                ClearTable.KeyFeatureClients(db);
            }

            Assert.AreEqual(remove, removeExpected);
        }
        /// <summary>
        /// Удаление неправильного id.
        /// </summary>
        [TestMethod]
        public void RemoveErroneousIdHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentException>(() => haspKeyDAO.Remove(-412536));
            }
        }
        /// <summary>
        /// Удаление ключа которого не существует в базе.
        /// </summary>
        [TestMethod]
        public void RemoveNoDBHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(CreateNew());
                Assert.ThrowsException<NullReferenceException>(
                    () => haspKeyDAO.Remove(123));
                ClearTable.HaspKeys(db);
            }
        }
        private HaspKey CreateNew()
        {
            return new HaspKey
            {
                InnerId  = 1,
                Number   = "uz-2",
                Location = true,
                TypeKey  = TypeKey.Pro,
            };
        }
        private HaspKey CreateNew(int id)
        {
            HaspKey haspKey = CreateNew();
            haspKey.Id      = id;
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
