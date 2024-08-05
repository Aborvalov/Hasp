﻿using DalContract;
using DalDB;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using HelperForUnitTest;

namespace UnitTestDal
{
    [TestClass]
    [DeploymentItem("HASPKey.db")]
    public class UnitTestDbClientDAO
    {
        private const int erroneousId = -123;
        private IContractClientDAO clientDAO;

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void NullEntitesContextClient()
        {
            Assert.ThrowsException<ArgumentNullException>(() => clientDAO = new DbClientDAO(null));
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void AddClient()
        {
            int idExpected = 1;
            int add;
            var db = new EntitesContext();
            using (db)
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                add = clientDAO.Add(CreateNew());               
            }
            Assert.AreEqual(add, idExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void AddNullClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => clientDAO.Add(null));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetAllClient()
        {
            List<Client> getAll;
            var clients = CreateListEntities.Clients();

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);

                foreach(var cl in clients)
                    clientDAO.Add(cl);

                getAll = clientDAO.GetAll();               
            }

            CollectionAssert.AreEqual(getAll, clients);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetAllEmptyClient()
        {
            var getAll = new List<Client>();
            var clientExpected = new List<Client>();

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                getAll = clientDAO.GetAll();
            }
            CollectionAssert.AreEqual(getAll, clientExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByIdClient()
        {
            Client getById;
            Client clientExpected = CreateNew(1);

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(CreateNew());
                getById = clientDAO.GetById(1);               
            }

            Assert.AreEqual(getById, clientExpected);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByErroneousIdClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.ThrowsException<ArgumentException>(() => clientDAO.GetById(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByIdNoDBClient()
        {
            Client getById;

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                getById = clientDAO.GetById(1);
            }

            Assert.IsNull(getById);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateClient()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(CreateNew());
                update = clientDAO.Update(new Client
                {
                    Id            = 1,
                    Name          = "____",
                    Address       = "____",
                    ContactPerson = "____",
                    Phone         = "____",
                });
            }

            Assert.IsTrue(update);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateNullClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => clientDAO.Update(null));
            }
        }        

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void UpdateNoDBClient()
        {
            Client clientNoDB = new Client
            {
                Id            = 234,
                Name          = "______",
                ContactPerson = "______",
                Address       = "______",
                Phone         = "______",
            };

            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(CreateNew());

                Assert.IsFalse(clientDAO.Update(clientNoDB));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveClient()
        {
            bool remove;
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);

                clientDAO = new DbClientDAO(db);
                db.Clients.AddRange(CreateListEntities.Clients());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                remove = clientDAO.Remove(1);
            }

            Assert.IsTrue(remove);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveErroneousIdClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.ThrowsException<ArgumentException>(() => clientDAO.Remove(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void RemoveNoDBClient()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(CreateNew());
                Assert.IsFalse(clientDAO.Remove(123));
                
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByFeatureClient()
        {
            List<Client> getByFeature;

            using (var db = new EntitesContext())
            {
                ClearTable.Features(db);
                ClearTable.KeyFeatures(db);
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);

                clientDAO = new DbClientDAO(db);
                db.Features.AddRange(CreateListEntities.Features());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.Clients.AddRange(CreateListEntities.Clients());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                getByFeature = clientDAO.GetByFeature(new Feature
                {
                    Id     = 1,
                    Number = 1,
                    Name   = "qwe",
                });
            }

            CollectionAssert.AreEqual(getByFeature, CreateListEntities.Clients());
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByNullFeatureClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => clientDAO.GetByFeature(null));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByErroneousNumberKeyClient()
        {
            using (var db = new EntitesContext())
            {
                clientDAO = new DbClientDAO(db);
                Assert.ThrowsException<ArgumentException>(() => clientDAO.GetByNumberKey(erroneousId));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByNumberKeyNoDBClient()
        {
            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                clientDAO = new DbClientDAO(db);
                Assert.IsNull(clientDAO.GetByNumberKey(2));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void GetByNumberKeyClient()
        {
            Client getByNumberKey;
            Client actual = CreateListEntities.Clients()[0];

            using (var db = new EntitesContext())
            {
                ClearTable.HaspKeys(db);
                ClearTable.KeyFeatures(db);
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);

                clientDAO = new DbClientDAO(db);
                db.HaspKeys.AddRange(CreateListEntities.HaspKeys());
                db.KeyFeatures.AddRange(CreateListEntities.KeyFeatures());
                db.Clients.AddRange(CreateListEntities.Clients());
                db.KeyFeatureClients.AddRange(CreateListEntities.KeyFeatureClients());
                db.SaveChanges();

                getByNumberKey = clientDAO.GetByNumberKey(1);
            }

            Assert.AreEqual(getByNumberKey, actual);
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void ContainsDBClient()
        {
            var client = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(client);
                Assert.IsTrue(clientDAO.ContainsDB(client));
            }
        }

        [TestMethod]
        [DeploymentItem("HASPKey.db")]
        public void NoContainsDBClient()
        {
            var client = CreateNew();
            using (var db = new EntitesContext())
            {
                ClearTable.Clients(db);
                clientDAO = new DbClientDAO(db);
                clientDAO.Add(client);
                client.Name = "asdasd";
                Assert.IsFalse(clientDAO.ContainsDB(client));
            }
        }

        private Client CreateNew()
        {
            return new Client
            {
                Name          = "OOO Forst 98",
                Address       = "pr.Stroiteley 45",
                ContactPerson = "Ivanov Ivan",
                Phone         = "8-123-432-12-21",
            };
        }

        private Client CreateNew(int id)
        {
            Client client = CreateNew();
            client.Id     = id;
            return client;
        }
    }
}
