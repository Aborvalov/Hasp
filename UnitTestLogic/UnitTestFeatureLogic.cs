using System;
using System.Collections.Generic;
using DalDB;
using Entities;
using Logic;
using LogicContract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helper;
namespace UnitTestLogic
{
    [TestClass]
    [DeploymentItem("HASPKeyTest.db")]
    public class UnitTestFeatureLogic
    {
        private const int erroneousId = -123;
        private IFeatureLogic featureL;

        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void NullEntitesContextFeature()
        {
            Assert.ThrowsException<ArgumentNullException>(() => featureL = new FeatureLogic(null));
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void SaveFeature()
        {
            bool add;
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                add = featureL.Save(CreateNew());
            }

            Assert.IsTrue(add);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void SaveDuplicateFeature()
        {
            bool add;
            Feature feature = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                featureL.Save(feature);
                add = featureL.Save(feature);
            }

            Assert.IsFalse(add);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void ErroneousArgumentSaveFeature()
        {
            Feature feature = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = new FeatureLogic(new DbFeatureDAO(db));

                feature.Name = null;
                Assert.ThrowsException<ArgumentException>(() => featureL.Save(feature));
                feature.Name = string.Empty;
                Assert.ThrowsException<ArgumentException>(() => featureL.Save(feature));

                feature.Name = "_____";
                feature.Number = 0;
                Assert.ThrowsException<ArgumentException>(() => featureL.Save(feature));
                feature.Number = -456;
                Assert.ThrowsException<ArgumentException>(() => featureL.Save(feature));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void SaveNullFeature()
        {
            using (var db = new EntitesContext())
            {
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                Assert.ThrowsException<ArgumentNullException>(() => featureL.Save(null));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetAllFeature()
        {
            var getAll = new List<Feature>();
            var features = CreateListEntities.Features();

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = new FeatureLogic(new DbFeatureDAO(db));

                foreach (var feat in features)
                    featureL.Save(feat);

                getAll = featureL.GetAll();
            }

            CollectionAssert.AreEqual(getAll, features);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetAllEmptyFeature()
        {
            var getAll = new List<Feature>();
            var featureExpected = new List<Feature>();

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                getAll = featureL.GetAll();
            }

            CollectionAssert.AreEqual(getAll, featureExpected);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByIdFeature()
        {
            Feature getById;
            Feature featureExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                featureL.Save(CreateNew());
                getById = featureL.GetById(1);
            }

            Assert.AreEqual(getById, featureExpected);
        }
        /// <summary>
        /// Поиск неправильного id.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByErroneousIdFeaturey()
        {
            using (var db = new EntitesContext())
            {
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                Assert.ThrowsException<ArgumentException>(() => featureL.GetById(erroneousId));
            }
        }
        /// <summary>
        /// Поиск id которого нет в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void GetByIdNoDBFeature()
        {
            Feature getById;
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                getById = featureL.GetById(1);
            }
            Assert.IsNull(getById);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateFeature()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                featureL.Save(CreateNew());
                update = featureL.Update(new Feature
                {
                    Id = 1,
                    Number = 1002,
                    Name = "TestUpdate",
                    Description = "Test ______",
                });
            }
            Assert.IsTrue(update);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateDuplicateFeature()
        {
            bool update;
            var faeture = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                featureL.Save(faeture);
                faeture.Number = 111;
                featureL.Save(faeture);
                update = featureL.Update(CreateNew(2));
            }
            Assert.IsFalse(update);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateNullFeature()
        {
            using (var db = new EntitesContext())
            {
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                Assert.ThrowsException<ArgumentNullException>(() => featureL.Update(null));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateNoDBFeature()
        {
            var featureNoDB = new Feature
            {
                Id = 234234,
                Number = 54,
                Name = "____________",
                Description = "ssdsssss",
            };

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                featureL.Save(CreateNew());
                Assert.IsFalse(featureL.Update(featureNoDB));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveFeature()
        {
            bool remove;
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                ClearTable.KeyFeatures(db);
                ClearTable.KeyFeatureClients(db);

                featureL = new FeatureLogic(new DbFeatureDAO(db));
                db.Features.AddRange(CreateListEntities.Features());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = featureL.Remove(1);
            }

            Assert.IsTrue(remove);
        }
        /// <summary>
        /// Удаление неправильного id.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveErroneousIdFeature()
        {
            using (var db = new EntitesContext())
            {
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                Assert.ThrowsException<ArgumentException>(() => featureL.Remove(erroneousId));
            }
        }
        /// <summary>
        /// Удаление фичи которой не существует в базе.
        /// </summary>
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void RemoveNoDBFeature()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = new FeatureLogic(new DbFeatureDAO(db));
                featureL.Save(CreateNew());
                Assert.IsFalse(featureL.Remove(1235));
            }
        }
        private Feature CreateNew()
        {
            return new Feature
            {
                Name = "print",
                Number = 123,
                Description = "asd sdf dfg",
            };
        }
        private Feature CreateNew(int id)
        {
            Feature feature = CreateNew();
            feature.Id = id;
            return feature;
        }
        private Feature CreateNew(int id, int number, string name)
        {
            Feature feature = CreateNew(id);
            feature.Number = number;
            feature.Name = name;
            return feature;
        }
    }
}
