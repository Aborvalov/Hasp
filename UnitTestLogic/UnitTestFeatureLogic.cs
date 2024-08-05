using Entities;
using HelperForUnitTest;
using Logic;
using LogicContract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace UnitTestLogic
{
    [TestClass]
    [DeploymentItem("HASPKey.db")]
    public class UnitTestFeatureLogic
    {
        private const int erroneousId = -123;
        private IFeatureLogic featureL;
        private IFeatureLogic Get(EntitesContext db) => new Logics().CreateFeature(db);

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void NullEntitesContextFeature()
        {
            Assert.ThrowsException<ArgumentNullException>(() => featureL = Get(null));
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void SaveFeature()
        {
            bool add;
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = Get(db);
                add = featureL.Save(CreateNew());
            }

            Assert.IsTrue(add);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void SaveDuplicateFeature()
        {
            bool add;
            Feature feature = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = Get(db);
                featureL.Save(feature);
                add = featureL.Save(feature);
            }

            Assert.IsFalse(add);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void ErroneousArgumentSaveFeature()
        {
            Feature feature = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = Get(db);

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
        [DeploymentItem("HASPKey.db")]
        public void SaveNullFeature()
        {
            using (var db = new EntitesContext())
            {
                featureL = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => featureL.Save(null));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetAllFeature()
        {
            var getAll = new List<Feature>();
            var features = CreateListEntities.Features();

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = Get(db);

                foreach (var feat in features)
                    featureL.Save(feat);

                getAll = featureL.GetAll();
            }

            CollectionAssert.AreEqual(getAll, features);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetAllEmptyFeature()
        {
            var getAll = new List<Feature>();
            var featureExpected = new List<Feature>();

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = Get(db);
                getAll = featureL.GetAll();
            }

            CollectionAssert.AreEqual(getAll, featureExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByIdFeature()
        {
            Feature getById;
            Feature featureExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = Get(db);
                featureL.Save(CreateNew());
                getById = featureL.GetById(1);
            }

            Assert.AreEqual(getById, featureExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByErroneousIdFeaturey()
        {
            using (var db = new EntitesContext())
            {
                featureL = Get(db);
                Assert.ThrowsException<ArgumentException>(() => featureL.GetById(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByIdNoDBFeature()
        {
            Feature getById;
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = Get(db);
                getById = featureL.GetById(1);
            }
            Assert.IsNull(getById);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateFeature()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = Get(db);
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
        [DeploymentItem("HASPKey.db")]
        public void UpdateDuplicateFeature()
        {
            bool update;
            var feature = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = Get(db);
                featureL.Save(feature);
                feature.Number = 111;
                featureL.Save(feature);
                update = featureL.Update(CreateNew(2));
            }
            Assert.IsFalse(update);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateNullFeature()
        {
            using (var db = new EntitesContext())
            {
                featureL = Get(db);
                Assert.ThrowsException<ArgumentNullException>(() => featureL.Update(null));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
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
                featureL = Get(db);
                featureL.Save(CreateNew());
                Assert.IsFalse(featureL.Update(featureNoDB));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveFeature()
        {
            bool remove;
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                ClearTable.KeyFeatures(db);
                ClearTable.KeyFeatureClients(db);

                featureL = Get(db);
                db.Features.AddRange(CreateListEntities.Features());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = featureL.Remove(1);
            }

            Assert.IsTrue(remove);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveErroneousIdFeature()
        {
            using (var db = new EntitesContext())
            {
                featureL = Get(db);
                Assert.ThrowsException<ArgumentException>(() => featureL.Remove(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveNoDBFeature()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureL = Get(db);
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
    }
}
