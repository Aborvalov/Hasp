﻿using DalContract;
using DalDB;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestDal
{
    [TestClass]
    public class UnitTestDbHaspKeyDAO
    {
        private const int erroneousId = -123;
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
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);
                add = haspKeyDAO.Add(CreateNew());
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
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(CreateNew());
                Assert.AreEqual(haspKeyDAO.Add(CreateNew()), -1);
            }
        }
        [TestMethod]
        public void GetAllHaspKey()
        {
            var getAll = new List<HaspKey>(); ;
            var haspKeysExpected = new List<HaspKey>();

            for (int i = 1; i <= 10; i++)
                haspKeysExpected.Add(CreateNew(i, i));

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);

                for (int i = 1; i <= 10; i++)
                    haspKeyDAO.Add(CreateNew(i, i));

                getAll = haspKeyDAO.GetAll();
            }

            CollectionAssert.AreEqual(getAll, haspKeysExpected);
        }
        [TestMethod]
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
        /// <summary>
        /// Поиск неправильного id.
        /// </summary>
        [TestMethod]
        public void GetByErroneousIdHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentException>(() => haspKeyDAO.GetById(erroneousId));
            }
        }
        /// <summary>
        /// Поиск id которого нет в базе.
        /// </summary>
        [TestMethod]
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
        /// <summary>
        /// Обновление ключа которого не существует в базе.
        /// </summary>
        [TestMethod]
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

                GetByActive = haspKeyDAO.GetByPastDue();
            }

            CollectionAssert.AreEqual(GetByActive, GetByActiveExpected);
        }
        [TestMethod]
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
        /// <summary>
        /// Удаление неправильного id.
        /// </summary>
        [TestMethod]
        public void RemoveErroneousIdHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentException>(() => haspKeyDAO.Remove(erroneousId));
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
                ClearTable.HaspKeys(db);
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(CreateNew());
                Assert.IsFalse(haspKeyDAO.Remove(123));
            }
        }
        [TestMethod]
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
        private HaspKey CreateNew(int id, int innerId)
        {
            HaspKey haspKey = CreateNew(id);
            haspKey.InnerId = innerId;
            return haspKey;
        }
    }
}