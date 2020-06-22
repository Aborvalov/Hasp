using DalContract;
using DalDB;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestDal
{
    [TestClass]
    [DeploymentItem("HASPKeyTest.db")]
    public class UnitTestDbKeyFeatureDAO
    {
        private const int erroneousId = -123;
        private IContractKeyFeatureDAO kfDAO;
        private readonly DateTime date = DateTime.Now.Date;

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void NullEntitesContextKeyFeature()
        {
            Assert.ThrowsException<ArgumentNullException>(() => kfDAO = new DbKeyFeatureDAO(null));
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
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
        [DeploymentItem("HASPKeyTest.db")]
        public void AddNullKeyFeature()
        {
            using (var db = new EntitesContext())
            {
                kfDAO = new DbKeyFeatureDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => kfDAO.Add(null));
            }
        }        
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetAllKeyFeature()
        {
            var getAll = new List<KeyFeature>();
            var keyFeats = CreateListEntities.KeyFeatures();

            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                kfDAO = new DbKeyFeatureDAO(db);

                foreach(var kf in keyFeats)
                    kfDAO.Add(kf);

                getAll = kfDAO.GetAll();                
            }

            CollectionAssert.AreEqual(getAll, keyFeats);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
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
        [DeploymentItem("HASPKeyTest.db")]
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
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByErroneousIdKeyFeaturey()
        {
            using (var db = new EntitesContext())
            {
                kfDAO = new DbKeyFeatureDAO(db);
                Assert.ThrowsException<ArgumentException>(() => kfDAO.GetById(erroneousId));
            }
        }
        /// <summary>
        /// Поиск id которого нет в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
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
        [DeploymentItem("HASPKeyTest.db")]
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
        [DeploymentItem("HASPKeyTest.db")]
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
        [DeploymentItem("HASPKeyTest.db")]
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
        [DeploymentItem("HASPKeyTest.db")]
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
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveErroneousIdKeyFeature()
        {
            using (var db = new EntitesContext())
            {
                kfDAO = new DbKeyFeatureDAO(db);
                Assert.ThrowsException<ArgumentException>(() => kfDAO.Remove(erroneousId));
            }
        }
        /// <summary>
        /// Удаление связи ключ-фича которой не существует в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
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
        [DeploymentItem("HASPKeyTest.db")]
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
        [DeploymentItem("HASPKeyTest.db")]
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
