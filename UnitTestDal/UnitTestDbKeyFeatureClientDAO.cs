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
    public class UnitTestDbKeyFeatureClientDAO
    {
        private IContractKeyFeatureClientDAO kfcDAO;
        public void NullEntitesContextKeyFeatureClient()
        {
            Assert.ThrowsException<ArgumentNullException>(() => kfcDAO = new DbKeyFeatureClientDAO(null));
        }
        [TestMethod]
        public void AddKeyFeatureClient()
        {
            int idExpected = 1;
            int add;

            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                add = kfcDAO.Add(CreateNew());
                ClearTable.KeyFeatureClients(db);
            }

            Assert.AreEqual(idExpected, add);
        }
        [TestMethod]
        public void AddNullKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => kfcDAO.Add(null));
            }
        }
        [TestMethod]
        public void AddDuplicateKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                kfcDAO.Add(CreateNew());
                Assert.ThrowsException<DuplicateException>(() => kfcDAO.Add(CreateNew()));
                ClearTable.KeyFeatureClients(db);
            }
        }
        [TestMethod]
        public void GetAllKeyFeatureClient()
        {
            List<KeyFeatureClient> getAll = new List<KeyFeatureClient>(); ;
            List<KeyFeatureClient> kfcExpected = new List<KeyFeatureClient>();

            for (int i = 1; i <= 10; i++)
                kfcExpected.Add(CreateNew(i, i, i));

            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                for (int i = 1; i <= 10; i++)
                    kfcDAO.Add(CreateNew(i, i, i));

                getAll = kfcDAO.GetAll();
                ClearTable.KeyFeatureClients(db);
            }

            CollectionAssert.AreEqual(getAll, kfcExpected);
        }
        [TestMethod]
        public void GetByIdKeyFeatureClient()
        {
            KeyFeatureClient getById;
            KeyFeatureClient kfcExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                kfcDAO.Add(CreateNew());
                getById = kfcDAO.GetById(1);
                ClearTable.KeyFeatureClients(db);
            }

            Assert.AreEqual(getById, kfcExpected);
        }
        /// <summary>
        /// Поиск неправильного id.
        /// </summary>
        [TestMethod]
        public void GetByErroneousIdKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                Assert.ThrowsException<ArgumentException>(() => kfcDAO.GetById(-4136));
            }
        }
        /// <summary>
        /// Поиск id которого нет в базе.
        /// </summary>
        [TestMethod]
        public void GetByIdNoDBKeyFeatureClient()
        {
            KeyFeatureClient getById;

            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                getById = kfcDAO.GetById(1);
            }

            Assert.AreEqual(getById, null);
        }
        [TestMethod]
        public void UpdateKeyFeatureClient()
        {
            bool update;
            using (var db = new EntitesContext())
            {
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

                ClearTable.KeyFeatureClients(db);
            }
            Assert.AreEqual(update, true);
        }
        [TestMethod]
        public void UpdateNullKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => kfcDAO.Update(null));
            }
        }
        /// <summary>
        /// Дублирование связи (ключ-фича)-клиент при обновлении.
        /// </summary>
        [TestMethod]
        public void UpdateDuplicateKeyFeatureClient()
        {
            KeyFeatureClient kfc = CreateNew();

            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                kfcDAO.Add(kfc);

                KeyFeatureClient update = CreateNew(1);

                Assert.ThrowsException<DuplicateException>(
                    () => kfcDAO.Update(update));
                ClearTable.KeyFeatureClients(db);
            }
        }
        /// <summary>
        /// Обновление связи (ключ-фича)-клиент которой не существует в базе.
        /// </summary>
        [TestMethod]
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
            { ClearTable.KeyFeatureClients(db); 

                kfcDAO = new DbKeyFeatureClientDAO(db);
                kfcDAO.Add(CreateNew());
                Assert.ThrowsException<NullReferenceException>(
                    () => kfcDAO.Update(kfcNoDB));
                ClearTable.KeyFeatureClients(db);
            }
        }
        [TestMethod]
        public void RemoveKeyFeatureClient()
        {
            bool removeExpected = true;
            bool remove;
            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = kfcDAO.Remove(1);

                ClearTable.KeyFeatureClients(db);
            }

            Assert.AreEqual(remove, removeExpected);
        }
        /// <summary>
        /// Удаление неправильного id.
        /// </summary>
        [TestMethod]
        public void RemoveErroneousIdKeyFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                Assert.ThrowsException<ArgumentException>(() => kfcDAO.Remove(-41036));
            }
        }
        /// <summary>
        /// Удаление связи (ключ-фича)-клиент которой не существует в базе.
        /// </summary>
        [TestMethod]
        public void RemoveNoDBHaspKey()
        {
            using (var db = new EntitesContext())
            {
                kfcDAO = new DbKeyFeatureClientDAO(db);
                kfcDAO.Add(CreateNew());
                Assert.ThrowsException<NullReferenceException>(
                    () => kfcDAO.Remove(123));
                ClearTable.HaspKeys(db);
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
        private KeyFeatureClient CreateNew(int id, int idClient, int idKeyFeature)
        {
            KeyFeatureClient kfc = CreateNew(id);
            kfc.IdClient         = idClient;
            kfc.IdKeyFeature     = idKeyFeature;
            return kfc;
        }

    }
}
