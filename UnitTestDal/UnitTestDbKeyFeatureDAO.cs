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
    public class UnitTestDbKeyFeatureDAO
    {
        private IContractKeyFeatureDAO kfDAO;
        private DateTime date = DateTime.Now.Date;

        [TestMethod]
        public void NullEntitesContextKeyFeature()
        {
            Assert.ThrowsException<ArgumentNullException>(() => kfDAO = new DbKeyFeatureDAO(null));
        }
        [TestMethod]
        public void AddKeyFeature()
        {
            int idExpected = 1;
            int add;

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                kfDAO = new DbKeyFeatureDAO(db);
                add = kfDAO.Add(CreateNew());                
            }
            Assert.AreEqual(add, idExpected);
        }
        [TestMethod]
        public void AddNullKeyFeature()
        {
            using (var db = new EntitesContext())
            {
                kfDAO = new DbKeyFeatureDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => kfDAO.Add(null));
            }
        }        
        [TestMethod]
        public void GetAllKeyFeature()
        {
            var getAll = new List<KeyFeature>();
            var kfExpected = new List<KeyFeature>();

            for (int i = 1; i <= 10; i++)
                kfExpected.Add(CreateNew(i, i, i));

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                kfDAO = new DbKeyFeatureDAO(db);

                for (int i = 1; i <= 10; i++)
                    kfDAO.Add(CreateNew(i, i, i));

                getAll = kfDAO.GetAll();                
            }

            CollectionAssert.AreEqual(getAll, kfExpected);
        }
        [TestMethod]
        public void GetAllEmptyKeyFeature()
        {
            var getAll = new List<KeyFeature>();
            var kfExpected = new List<KeyFeature>();

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                kfDAO = new DbKeyFeatureDAO(db);

                getAll = kfDAO.GetAll();
            }
            CollectionAssert.AreEqual(getAll, kfExpected);
        }
        [TestMethod]
        public void GetByIdKeyFeature()
        {
            KeyFeature getById;
            KeyFeature kfExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                kfDAO = new DbKeyFeatureDAO(db);
                kfDAO.Add(CreateNew());
                getById = kfDAO.GetById(1);                
            }

            Assert.AreEqual(getById, kfExpected);
        }
        /// <summary>
        /// Поиск неправильного id.
        /// </summary>
        [TestMethod]
        public void GetByErroneousIdKeyFeaturey()
        {
            using (var db = new EntitesContext())
            {
                kfDAO = new DbKeyFeatureDAO(db);
                Assert.ThrowsException<ArgumentException>(() => kfDAO.GetById(-456));
            }
        }
        /// <summary>
        /// Поиск id которого нет в базе.
        /// </summary>
        [TestMethod]
        public void GetByIdNoDBKeyFeature()
        {
            KeyFeature getById;

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                kfDAO = new DbKeyFeatureDAO(db);
                getById = kfDAO.GetById(1);
            }

            Assert.IsNull(getById);
        }
        [TestMethod]
        public void UpdateKeyFeature()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                kfDAO = new DbKeyFeatureDAO(db);
                kfDAO.Add(CreateNew());

                update = kfDAO.Update(new KeyFeature
                {
                    Id        = 1,
                    IdFeature = 2,
                    IdHaspKey = 3,
                    StartDate = date.AddDays(5),
                    EndDate   = date.AddDays(10),
                });
            }

            Assert.IsTrue(update);
        }
        [TestMethod]
        public void UpdateNullKeyFeature()
        {
            using (var db = new EntitesContext())
            {
                kfDAO = new DbKeyFeatureDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => kfDAO.Update(null));
            }
        }        
        /// <summary>
        /// Обновление связи ключ-фича которой не существует в базе.
        /// </summary>
        [TestMethod]
        public void UpdateNoDBKeyFeature()
        {
            var kfNoDB = new KeyFeature
            {
                Id        = 32,
                IdFeature = 3,
                IdHaspKey = 24,
                EndDate   = date.AddDays(100),
                StartDate = date,
            };
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                kfDAO = new DbKeyFeatureDAO(db);
                kfDAO.Add(CreateNew());
                Assert.IsFalse(kfDAO.Update(kfNoDB));
            }
        }
        [TestMethod]
        public void RemoveKeyFeature()
        {
            bool remove;
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                ClearTable.KeyFeatureClients(db);

                kfDAO = new DbKeyFeatureDAO(db);
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = kfDAO.Remove(1);
            }

            Assert.IsTrue(remove);
        }
        /// <summary>
        /// Удаление неправильного id.
        /// </summary>
        [TestMethod]
        public void RemoveErroneousIdKeyFeature()
        {
            using (var db = new EntitesContext())
            {
                kfDAO = new DbKeyFeatureDAO(db);
                Assert.ThrowsException<ArgumentException>(() => kfDAO.Remove(-412536));
            }
        }
        /// <summary>
        /// Удаление связи ключ-фича которой не существует в базе.
        /// </summary>
        [TestMethod]
        public void RemoveNoDBKeyFeature()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                kfDAO = new DbKeyFeatureDAO(db);
                kfDAO.Add(CreateNew());
                Assert.IsFalse(kfDAO.Remove(123));
            }
        }
        [TestMethod]
        public void ContainsDBKeyFeature()
        {
            var keyFeat = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                kfDAO = new DbKeyFeatureDAO(db);
                kfDAO.Add(keyFeat);
                Assert.IsTrue(kfDAO.ContainsDB(keyFeat));
            }
        }
        [TestMethod]
        public void NoContainsDBKeyFeature()
        {
            var keyFeat = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                kfDAO = new DbKeyFeatureDAO(db);
                kfDAO.Add(keyFeat);
                keyFeat.IdFeature = 3423;
                Assert.IsFalse(kfDAO.ContainsDB(keyFeat));
            }
        }
        private KeyFeature CreateNew()
        {
            return new KeyFeature
            {
                IdFeature = 1,
                IdHaspKey = 1,
                StartDate = date,
                EndDate   = date.AddDays(14),
            };
        }
        private KeyFeature CreateNew(int id)
        {
            KeyFeature kf = CreateNew();
            kf.Id = id;
            return kf;
        }
        private KeyFeature CreateNew(int id, int idHaspKey, int idFeature)
        {
            KeyFeature kf = CreateNew(id);
            kf.IdHaspKey  = idHaspKey;
            kf.IdFeature  = idFeature;
            return kf;
        }
    }
}
