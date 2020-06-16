using DalContract;
using DalDB;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestDal
{
    [TestClass]
    public class UnitTestDbHaspKeyDAO
    {
        private IContractHaspKeyDAO haspKeyDAO;
        private DateTime date = DateTime.Now.Date;
        [TestMethod]
        public void NullEntitesContext()
        {
            Assert.ThrowsException<ArgumentNullException>(() => haspKeyDAO = new DbHaspKeyDAO(null));
        }
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
                ClearTable.HaspKeys(db);
            }

            Assert.AreEqual(add, idExpected);
        }
        [TestMethod]
        public void AddNullHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => haspKeyDAO.Add(null));
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
                ClearTable.HaspKeys(db);
            }
        }
        [TestMethod]
        public void GetAllHaspKey()
        {
            List<HaspKey> getAll = new List<HaspKey>(); ;
            List<HaspKey> haspKeysExpected = new List<HaspKey>();

            for (int i = 1; i <= 10; i++)
            {
                HaspKey key = new HaspKey
                {
                    Id = i,
                    InnerId = i,
                    Number = "uz-2",
                    Location = true,
                    TypeKey = TypeKey.Pro,
                };

                haspKeysExpected.Add(key);
            }

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);

                for (int i = 1; i <= 10; i++)
                {
                    HaspKey key = new HaspKey
                    {
                        Id = i,
                        InnerId = i,
                        Number = "uz-2",
                        Location = true,
                        TypeKey = TypeKey.Pro,
                    };

                    haspKeyDAO.Add(key);
                }

                getAll = haspKeyDAO.GetAll().ToList();
                ClearTable.HaspKeys(db);
            }

            CollectionAssert.AreEqual(getAll, haspKeysExpected);
        }
        [TestMethod]
        public void GetByIdHaspKey()
        {
            HaspKey getbyId;
            HaspKey keyExpected = new HaspKey
            {
                Id = 1,
                InnerId = 1,
                Number = "uz-2",
                Location = true,
                TypeKey = TypeKey.Pro,
            };

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);

                haspKeyDAO.Add(new HaspKey
                {
                    InnerId = 1,
                    Number = "uz-2",
                    Location = true,
                    TypeKey = TypeKey.Pro,
                });

                getbyId = haspKeyDAO.GetById(1);
                ClearTable.HaspKeys(db);
            }

            Assert.AreEqual(getbyId, keyExpected);
        }
        /// <summary>
        /// Поиск неправильного id.
        /// </summary>
        [TestMethod]
        public void GetByErroneousIdHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentException>(() => haspKeyDAO.GetById(-412536));
            }
        }
        /// <summary>
        /// Поиск id которого нет в базе.
        /// </summary>
        [TestMethod]
        public void GetByIdNoDBHaspKey()
        {
            HaspKey getbyId;

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                getbyId = haspKeyDAO.GetById(1);
            }

            Assert.AreEqual(getbyId, null);
        }
        [TestMethod]
        public void UpdateHaspKey()
        {
            bool update;
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(new HaspKey
                {
                    Id = 1,
                    InnerId = 12,
                    Number = "Qwres",
                    Location = false,
                    TypeKey = TypeKey.NetTime,
                });
                update = haspKeyDAO.Update(new HaspKey
                {
                    Id = 1,
                    InnerId = 1,
                    Number = "uz-2",
                    Location = true,
                    TypeKey = TypeKey.Pro,
                });

                ClearTable.HaspKeys(db);
            }

            Assert.AreEqual(update, true);
        }
        [TestMethod]
        public void UpdateNullHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => haspKeyDAO.Update(null));
            }
        }
        /// <summary>
        /// Дублирование ключа при обновлении.
        /// </summary>
        [TestMethod]
        public void UpdateDuplicateHaspKey()
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
                Assert.ThrowsException<Exception>(
                    () => haspKeyDAO.Update(new HaspKey
                    {
                        Id = 2,
                        InnerId = 1,
                        Number = "uz-2",
                        Location = true,
                        TypeKey = TypeKey.Pro,
                    }));
                ClearTable.HaspKeys(db);
            }
        }
        /// <summary>
        /// Обновление ключа которого не существует в базе.
        /// </summary>
        [TestMethod]
        public void UpdateNoDBHaspKey()
        {
            HaspKey haspKey = new HaspKey
            {
                InnerId = 1,
                Number = "uz-2",
                Location = true,
                TypeKey = TypeKey.Pro,
            };
            HaspKey keyNoDB = new HaspKey
            {
                Id = 234,
                InnerId = 1546,
                Number = "uz-265",
                Location = false,
                TypeKey = TypeKey.NetTime,
            };

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                haspKeyDAO.Add(haspKey);
                Assert.ThrowsException<NullReferenceException>(
                    () => haspKeyDAO.Update(keyNoDB));
                ClearTable.HaspKeys(db);
            }
        }
        [TestMethod]
        public void GetByActiveHaspKey()
        {
            List<HaspKey> GetByActive;
            List<HaspKey> GetByActiveExpected = new List<HaspKey>
            { new HaspKey
                {
                    Id       = 1,
                    InnerId  = 1,
                    Number   = "uz-2",
                    Location = true,
                    TypeKey  = TypeKey.Pro,
                }
            };

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);

                db.HaspKeys.AddRange(CreateArreyHaspKeys());
                db.Features.AddRange(CreateArrayFeatures());
                db.KeyFeatures.AddRange(CreateArrayKeyFeatures());
                db.SaveChanges();

                GetByActive = haspKeyDAO.GetByActive().ToList();

                ClearTable.HaspKeys(db);
                ClearTable.Features(db);
                ClearTable.KeyFeatures(db);
            }

            CollectionAssert.AreEqual(GetByActive, GetByActiveExpected);
        }
        [TestMethod]
        public void GetByPastDueHaspKey()
        {
            List<HaspKey> GetByActive;
            List<HaspKey> GetByActiveExpected = new List<HaspKey>
            { new HaspKey
                {
                    Id       = 2,
                    InnerId  = 2,
                    Number   = "uz-3",
                    Location = true,
                    TypeKey  = TypeKey.Pro,
                }
            };

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);

                db.HaspKeys.AddRange(CreateArreyHaspKeys());
                db.Features.AddRange(CreateArrayFeatures());
                db.KeyFeatures.AddRange(CreateArrayKeyFeatures());
                db.SaveChanges();

                GetByActive = haspKeyDAO.GetByPastDue().ToList();

                ClearTable.HaspKeys(db);
                ClearTable.Features(db);
                ClearTable.KeyFeatures(db);
            }

            CollectionAssert.AreEqual(GetByActive, GetByActiveExpected);
        }
        [TestMethod]
        public void GetByClientHaspKey()
        {
            List<HaspKey> GetByClient;
            List<HaspKey> GetByClientExpected = new List<HaspKey>
            { new HaspKey
                {
                    Id       = 1,
                    InnerId  = 1,
                    Number   = "uz-2",
                    Location = true,
                    TypeKey  = TypeKey.Pro,
                }
            };

            Client client = new Client
            {
                Id = 1,
                Name = "Ivanov Ivan",
            };

            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                db.HaspKeys.AddRange(CreateArreyHaspKeys());
                db.Features.AddRange(CreateArrayFeatures());
                db.KeyFeatures.AddRange(CreateArrayKeyFeatures());
                db.Clients.AddRange(CreateArrayClients());
                db.KeyFeatureClients.AddRange(CreateArrayKeyFeatureClients());
                db.SaveChanges();

                GetByClient = haspKeyDAO.GetByClient(client).ToList();

                ClearTable.HaspKeys(db);
                ClearTable.Features(db);
                ClearTable.KeyFeatures(db);
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);
            }

            CollectionAssert.AreEqual(GetByClient, GetByClientExpected);
        }

        [TestMethod]
        public void GetByNullClientHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentNullException>(() => haspKeyDAO.GetByClient(null));
            }
        }

        [TestMethod]
        public void RemoveHaspKey()
        {
            bool removeExpected = true;
            bool remove;
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                db.HaspKeys.AddRange(CreateArreyHaspKeys());
                db.Features.AddRange(CreateArrayFeatures());
                db.KeyFeatures.AddRange(CreateArrayKeyFeatures());
                db.Clients.AddRange(CreateArrayClients());
                db.KeyFeatureClients.AddRange(CreateArrayKeyFeatureClients());
                db.SaveChanges();

                remove = haspKeyDAO.Remove(1);
                
                ClearTable.HaspKeys(db);
                ClearTable.Features(db);
                ClearTable.KeyFeatures(db);
                ClearTable.Clients(db);
                ClearTable.KeyFeatureClients(db);
            }

            Assert.AreEqual(remove, removeExpected);
        }
        /// <summary>
        /// Удаление неправильного id.
        /// </summary>
        [TestMethod]
        public void RemoveErroneousIdHaspKey()
        {
            using (var db = new EntitesContext())
            {
                haspKeyDAO = new DbHaspKeyDAO(db);
                Assert.ThrowsException<ArgumentException>(() => haspKeyDAO.Remove(-412536));
            }
        }
        private List<HaspKey> CreateArreyHaspKeys()
        {
            return new List<HaspKey>
            {
                new HaspKey
            {
                InnerId  = 1,
                Number   = "uz-2",
                Location = true,
                TypeKey  = TypeKey.Pro,
            },
            new HaspKey
            {
                InnerId  = 2,
                Number   = "uz-3",
                Location = true,
                TypeKey  = TypeKey.Pro,
            },
        };
        }
        private List<Feature> CreateArrayFeatures()
        {
            return new List<Feature>
            {
                new Feature
                {
                    Number = 1,
                    Name   = "qwe",
                },
                new Feature
                {
                    Number = 2,
                    Name = "qwe",
                },
            };            
        }
        private List<Client> CreateArrayClients()
        {
            return new List<Client>
            {
                new Client
                {
                    Id   = 1,
                    Name = "Ivanov Ivan",
                },
                new Client
                {
                    Id = 2,
                    Name = "Petrov FD",
                },
        };
        }
        private List<KeyFeature> CreateArrayKeyFeatures()
        {
            return new List<KeyFeature>
            {
                new KeyFeature
                {
                    IdHaspKey = 1,
                    IdFeature = 1,
                    StartDate = date,
                    EndDate   = date.AddDays(12),
                },
                new KeyFeature
                {
                    IdHaspKey = 1,
                    IdFeature = 2,
                    StartDate = date,
                    EndDate   = date.AddDays(-12),
                },
                new KeyFeature
                {
                    IdHaspKey = 2,
                    IdFeature = 1,
                    StartDate = date.AddDays(-30),
                    EndDate   = date.AddDays(-12),
                },
                new KeyFeature
                {
                    IdHaspKey = 2,
                    IdFeature = 2,
                    StartDate = date.AddDays(-50),
                    EndDate   = date.AddDays(-12),
                },
            };
        }
        private List<KeyFeatureClient> CreateArrayKeyFeatureClients()
        {
            return new List<KeyFeatureClient>
            {
                new KeyFeatureClient
                {
                    IdClient     = 1,
                    IdKeyFeature = 1,
                },
                new KeyFeatureClient
                {
                    IdClient     = 1,
                    IdKeyFeature = 2,
                },
                new KeyFeatureClient
                {
                    IdClient     = 2,
                    IdKeyFeature = 3,
                },
                new KeyFeatureClient
                {
                    IdClient     = 2,
                    IdKeyFeature = 4,
                },
            };
        }
    }
}
