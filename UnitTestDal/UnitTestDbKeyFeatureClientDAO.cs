using System;
using DalContract;
using Entities;
using DalDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDal
{
    [TestClass]
    public class UnitTestDbKeyFeatureClientDAO
    {
        private IContractKeyFeatureClientDAO keyFeatureClientDAO;

        //[TestMethod]
        //public void AddTest()
        //{
        //    int idExpected = 1;
        //    int add;
        //    KeyFeatureClient kfc = new KeyFeatureClient
        //    {
        //        IdClient     = 1,
        //        IdKeyFeature = 1,
        //        Initiator    = "Test Testovich",
        //        Note         = "Bla bla bla.",
        //    };

        //    using (var db = new EntitesContext())
        //    {
        //        keyFeatureClientDAO = new DbKeyFaetureClientDAO(db);
        //        add = keyFeatureClientDAO.Add(kfc);
        //    }

        //    Assert.AreEqual(idExpected, add);
        //}  
    }
}
