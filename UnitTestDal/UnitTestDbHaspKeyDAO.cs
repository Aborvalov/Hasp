using System;
using DalContract;
using Entities;
using DalDB;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestDal
{
    [TestClass]
    public class UnitTestDbHaspKeyDAO
    {
        private IContractHaspKeyDAO haspKeyDAO;

        [TestMethod]
        public void AddHaspKey()
        {
            int idExpected = 1;
            int add;
            HaspKey haspKey = new HaspKey
            {
                InnerId = 1,
                Number = "uz-2",
                Location = false,
                TypeKey = TypeKey.Net,
            };

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);                
                add = haspKeyDAO.Add(haspKey);
                ClearTable(db);
            }

            Assert.AreEqual(idExpected, add);
        }
        [TestMethod]
        public void AddNullHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentNullException>(()=>haspKeyDAO.Add(null));
            }            
        }
        [TestMethod]
        public void AddDuplicateHaspKey()
        {
            HaspKey haspKey = new HaspKey
            {
                InnerId = 1,
                Number = "uz-2",
                Location = true,
                TypeKey = TypeKey.Pro,
            };

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(haspKey);
                Assert.ThrowsException<Exception>(() => haspKeyDAO.Add(haspKey));
                ClearTable(db);
            }
        }

        private void ClearTable(EntitesContext db)
        {
            db.Database.ExecuteSqlCommand("DROP TABLE HASPKeys");
            db.Database.ExecuteSqlCommand(@"CREATE TABLE HASPKeys (
                                                Id       INTEGER PRIMARY KEY AUTOINCREMENT
                                                                 NOT NULL
                                                                 UNIQUE,
                                                InnerId  INTEGER NOT NULL
                                                                 UNIQUE,
                                                Number   TEXT    NOT NULL,
                                                TypeKey  STRING  NOT NULL,
                                                Location BOOLEAN NOT NULL
                                            ); ");
            db.SaveChanges();
        }
    }
}
