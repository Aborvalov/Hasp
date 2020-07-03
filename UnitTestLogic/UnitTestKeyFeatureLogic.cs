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
    /// Summary description for UnitTestKeyFeatureLogic
    /// </summary>
    [TestClass]
    [DeploymentItem("HASPKeyTest.db")]
    public class UnitTestKeyFeatureLogic
    {
        private const int erroneousId = -123;
        private IKeyFeatureLogic keyFeatureL;
        private IKeyFeatureLogic Get(EntitesContext db) => new Logics().CreateKeyFeature(db);
        private readonly DateTime date = DateTime.Now.Date;

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void NullEntitesContextKeyFeature()
        {
            Assert.ThrowsException<ArgumentNullException>(() => keyFeatureL = Get(null));
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void SaveKeyFeature()
        {
            bool add;
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                keyFeatureL = Get(db);
                add = keyFeatureL.Save(CreateNew());
            }
            Assert.IsTrue(add);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void SaveDuplicateKeyFeature()
        {
            bool add;
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                keyFeatureL = Get(db);
                keyFeatureL.Save(CreateNew());
                add = keyFeatureL.Save(CreateNew());
            }
            Assert.IsFalse(add);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void SaveNullKeyFeature()
        {
            using (var db = new EntitesContext())
            {
                keyFeatureL = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => keyFeatureL.Save(null));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void ErroneousArgumentSaveKeyFeature()
        {
            KeyFeature keyFeature = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                keyFeatureL = Get(db);

                keyFeature.IdFeature = 0;
                Assert.ThrowsException<ArgumentException>(() => keyFeatureL.Save(keyFeature));
                keyFeature.IdFeature = -12;
                Assert.ThrowsException<ArgumentException>(() => keyFeatureL.Save(keyFeature));

                keyFeature.IdFeature = 45;
                keyFeature.IdHaspKey = 0;
                Assert.ThrowsException<ArgumentException>(() => keyFeatureL.Save(keyFeature));
                keyFeature.IdHaspKey = -12;
                Assert.ThrowsException<ArgumentException>(() => keyFeatureL.Save(keyFeature));

                keyFeature.IdHaspKey = 12;                
                keyFeature.EndDate = date.AddDays(-45);
                Assert.ThrowsException<ArgumentException>(() => keyFeatureL.Save(keyFeature));
                               
                keyFeature.StartDate = keyFeature.EndDate.AddDays(-45);
                Assert.ThrowsException<ArgumentException>(() => keyFeatureL.Save(keyFeature));
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
                keyFeatureL = Get(db);

                // Добавляем на прямую, чтобы избежать проверки логики.
                foreach (var kf in keyFeats)
                    db.KeyFeatures.Add(kf);
                db.SaveChanges();

                getAll = keyFeatureL.GetAll();
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
                keyFeatureL = Get(db);

                getAll = keyFeatureL.GetAll();
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
                keyFeatureL = Get(db);
                keyFeatureL.Save(CreateNew());
                getById = keyFeatureL.GetById(1);
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
                keyFeatureL = Get(db);
                Assert.ThrowsException<ArgumentException>(() => keyFeatureL.GetById(erroneousId));
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
                keyFeatureL = Get(db);
                getById = keyFeatureL.GetById(1);
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
                keyFeatureL = Get(db);
                keyFeatureL.Save(CreateNew());

                update = keyFeatureL.Update(new KeyFeature
                {
                    Id = 1,
                    IdFeature = 2,
                    IdHaspKey = 3,
                    StartDate = date.AddDays(5),
                    EndDate = date.AddDays(10),
                });
            }

            Assert.IsTrue(update);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateDuplicateKeyKeyFeature()
        {
            bool update;
            var keyFeature = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                keyFeatureL = Get(db);
                keyFeatureL.Save(keyFeature);
                keyFeature.IdFeature = 111;
                update = keyFeatureL.Update(CreateNew(2));
            }

            Assert.IsFalse(update);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateNullKeyFeature()
        {
            using (var db = new EntitesContext())
            {
                keyFeatureL = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => keyFeatureL.Update(null));
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
                Id = 32,
                IdFeature = 3,
                IdHaspKey = 24,
                EndDate = date.AddDays(100),
                StartDate = date,
            };
            using (var db = new EntitesContext())
            {
                ClearTable.KeyFeatures(db);
                keyFeatureL = Get(db);
                keyFeatureL.Save(CreateNew());
                Assert.IsFalse(keyFeatureL.Update(kfNoDB));
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

                keyFeatureL = Get(db);
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = keyFeatureL.Remove(1);
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
                keyFeatureL = Get(db);
                Assert.ThrowsException<ArgumentException>(() => keyFeatureL.Remove(erroneousId));
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
                keyFeatureL = Get(db);
                keyFeatureL.Save(CreateNew());
                Assert.IsFalse(keyFeatureL.Remove(123));
            }
        }
        private KeyFeature CreateNew()
        {
            return new KeyFeature
            {
                IdFeature = 1,
                IdHaspKey = 1,
                StartDate = date,
                EndDate = date.AddDays(14),
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
            kf.IdHaspKey = idHaspKey;
            kf.IdFeature = idFeature;
            return kf;
        }
    }
}
