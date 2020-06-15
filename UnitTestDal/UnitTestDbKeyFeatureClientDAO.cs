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

        [TestMethod]
        public void TestAdd()
        {
            KeyFeatureClient kfc = new KeyFeatureClient
            {
                Id           = 1,
                IdClient     = 1,
                IdKeyFeature = 1,
                Initiator    = "Test Testovich",
                Note         = "Bla bla bla.",
            };

            using (var db = new EntitesContext())
            {
                keyFeatureClientDAO = new DbKeyFaetureClientDAO(db);

                var add = keyFeatureClientDAO.Add(kfc);
            }
        }
    }
}
