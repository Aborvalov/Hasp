using DalContract;
using DalDB;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Helper;

namespace UnitTestDal
{
    [TestClass]
    [DeploymentItem("HASPKeyTest.db")]
    public class UnitTestDbFeatureDAO
    {
        private const int erroneousId = -123;
        private IContractFeatureDAO featureDAO;
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void NullEntitesContextFeature()
        {
            Assert.ThrowsException<ArgumentNullException>(() => featureDAO = new DbFeatureDAO(null));
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void AddFeature()
        {
            int idExpected = 1;
            int add;

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureDAO = new DbFeatureDAO(db);
                add = featureDAO.Add(CreateNew());
            }

            Assert.AreEqual(add, idExpected);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void AddNullFeature()
        {
            using (var db = new EntitesContext())
            {
                featureDAO = new DbFeatureDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => featureDAO.Add(null));
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
                featureDAO = new DbFeatureDAO(db);

                foreach(var feat in features)
                    featureDAO.Add(feat);

                getAll = featureDAO.GetAll();
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
                featureDAO = new DbFeatureDAO(db);
                getAll = featureDAO.GetAll();
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
                featureDAO = new DbFeatureDAO(db);
                featureDAO.Add(CreateNew());
                getById = featureDAO.GetById(1);                
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
                featureDAO = new DbFeatureDAO(db);
                Assert.ThrowsException<ArgumentException>(() => featureDAO.GetById(erroneousId));
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
                featureDAO = new DbFeatureDAO(db);
                getById = featureDAO.GetById(1);
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
                featureDAO = new DbFeatureDAO(db);
                featureDAO.Add(CreateNew());
                update = featureDAO.Update(new Feature
                {
                    Id          = 1,
                    Number      = 1002,
                    Name        = "TestUpdate",
                    Description = "Test ______",
                });                
            }
            Assert.IsTrue(update);
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateNullFeature()
        {
            using (var db = new EntitesContext())
            {
                featureDAO = new DbFeatureDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => featureDAO.Update(null));
            }
        } 
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void UpdateNoDBFeature()
        {
            var featureNoDB = new Feature
            {
                Id          = 234234,
                Number      = -2354,
                Name        = "____________",
                Description = "ssdsssss",
            };

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureDAO = new DbFeatureDAO(db);
                featureDAO.Add(CreateNew());
                Assert.IsFalse(featureDAO.Update(featureNoDB));                
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

                featureDAO = new DbFeatureDAO(db);
                db.Features.AddRange(CreateListEntities.Features());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = featureDAO.Remove(1);
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
                featureDAO = new DbFeatureDAO(db);
                Assert.ThrowsException<ArgumentException>(() => featureDAO.Remove(erroneousId));
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
                featureDAO = new DbFeatureDAO(db);
                featureDAO.Add(CreateNew());
                Assert.IsFalse(featureDAO.Remove(1235));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void ContainsDBFeature()
        {
            var feature = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureDAO = new DbFeatureDAO(db);
                featureDAO.Add(feature);
                Assert.IsTrue(featureDAO.ContainsDB(feature));
            }
        }
        [TestMethod]
        [DeploymentItem("HASPKeyTest.db")]
        public void NoContainsDBFeature()
        {
            var feature = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureDAO = new DbFeatureDAO(db);
                featureDAO.Add(feature);
                feature.Name = "adasdsa___";
                Assert.IsFalse(featureDAO.ContainsDB(feature));
            }
        }
        private Feature CreateNew()
        {
            return new Feature
            {
                Name        = "print",
                Number      = 123,
                Description = "asd sdf dfg",
            };
        }
        private Feature CreateNew(int id)
        {
            Feature feature = CreateNew();
            feature.Id      = id;
            return feature;           
        }
        private Feature CreateNew(int id, int number, string name)
        {
            Feature feature = CreateNew(id);
            feature.Number  = number;
            feature.Name    = name;
            return feature;
        }
    }
}
