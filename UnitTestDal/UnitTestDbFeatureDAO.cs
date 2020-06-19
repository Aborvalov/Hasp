using DalContract;
using DalDB;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestDal
{
    [TestClass]
    public class UnitTestDbFeatureDAO
    {
        private const int erroneousId = -123;
        private IContractFeatureDAO featureDAO;
        [TestMethod]
        public void NullEntitesContextFeature()
        {
            Assert.ThrowsException<ArgumentNullException>(() => featureDAO = new DbFeatureDAO(null));
        }
        [TestMethod]

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
        public void AddNullFeature()
        {
            using (var db = new EntitesContext())
            {
                featureDAO = new DbFeatureDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => featureDAO.Add(null));
            }
        }        
        [TestMethod]
        public void GetAllFeature()
        {
            var getAll = new List<Feature>();
            var featureExpected = new List<Feature>();
            for (int i = 1; i <= 10; i++)
                featureExpected.Add(CreateNew(i, i, i.ToString() + "_sd"));

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureDAO = new DbFeatureDAO(db);

                for (int i = 1; i <= 10; i++)
                    featureDAO.Add(CreateNew(i, i, i.ToString() + "_sd"));

                getAll = featureDAO.GetAll();
            }

            CollectionAssert.AreEqual(getAll, featureExpected);            
        }
        [TestMethod]
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
        public void UpdateNullFeature()
        {
            using (var db = new EntitesContext())
            {
                featureDAO = new DbFeatureDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => featureDAO.Update(null));
            }
        } 
        [TestMethod]
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
