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
        [TestMethod]
        public void NullEntitesContextKeyFeature()
        {
            Assert.ThrowsException<ArgumentNullException>(() => kfDAO = new DbKeyFeatureDAO(null));
        }
        [TestMethod]
        public void TestMethod1()
        {
            //
            // TODO: Add test logic here
            //
        }
    }
}
