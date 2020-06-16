using System;
using System.Text;
using DalContract;
using DalDB;
using Entities;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
                kfDAO = new DbKeyFeatureDAO(db);
                add = kfDAO.Add(CreateNew());
                ClearTable.KeyFeatures(db);
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
        public void AddDuplicateKeyFeature()
        {
            using (var db = new EntitesContext())
            {
                kfDAO = new DbKeyFeatureDAO(db);
                kfDAO.Add(CreateNew());
                Assert.ThrowsException<Exception>(() => kfDAO.Add(CreateNew()));
                ClearTable.KeyFeatures(db);
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
