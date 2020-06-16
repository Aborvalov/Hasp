using System;
using System.Text;
using System.Collections.Generic;
using DalContract;
using DalDB;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestDal
{
    [TestClass]
    public class UnitTestDbFeatureDAO
    {
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
                featureDAO = new DbFeatureDAO(db);
                add = featureDAO.Add(CreateNew());

                ClearTable.Features(db);
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
        public void AddDuplicateFeature()
        {
            using (var db = new EntitesContext())
            {
                featureDAO = new DbFeatureDAO(db);
                featureDAO.Add(CreateNew());
                Assert.ThrowsException<Exception>(() => featureDAO.Add(CreateNew()));
                ClearTable.Features(db);
            }
        }
        [TestMethod]
        public void GetAllFeature()
        {
            List<Feature> getAll = new List<Feature>();
            List<Feature> featureExpected = new List<Feature>();
            for (int i = 1; i <= 10; i++)
                featureExpected.Add(CreateNew(i, i, i.ToString() + "_sd"));

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                featureDAO = new DbFeatureDAO(db);

                for (int i = 1; i <= 10; i++)
                    featureDAO.Add(CreateNew(i, i, i.ToString() + "_sd"));

                getAll = featureDAO.GetAll().ToList();

                ClearTable.Features(db);
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
                featureDAO = new DbFeatureDAO(db);
                featureDAO.Add(CreateNew());
                getById = featureDAO.GetById(1);
                ClearTable.Features(db);
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
                Assert.ThrowsException<ArgumentException>(() => featureDAO.GetById(-412536));
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
                featureDAO = new DbFeatureDAO(db);
                getById = featureDAO.GetById(1);
            }

            Assert.AreEqual(getById, null);
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
