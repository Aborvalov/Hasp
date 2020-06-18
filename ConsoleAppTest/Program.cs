using DalContract;
using DalDB;
using Entities;
using Logic;
using LogicContract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EntitesContext())
            {

                IClientLogic clientLogic = new ClientLogic(new DbClientDAO(db));

                var all = clientLogic.GetAll();
            }








             TestHaspKey();
            // TestFeature();
            // TestClient();
            // TestKeyFeature();
            // TestKeyFeatureCliet();
        }
        //static void TestKeyFeatureCliet()
        //{
        //    IContractKeyFeatureClientDAO test;
        //    KeyFeatureClient kfc = new KeyFeatureClient
        //    {
        //        IdClient = 13,
        //        IdKeyFeature = 4,
        //        Note = "fdsfsdfsf",
        //        Initiator = "Ivano pp",
        //    };

        //    KeyFeatureClient kfcUp = new KeyFeatureClient
        //    {
        //        Id = 10,
        //        IdClient = 10,
        //        IdKeyFeature = 5,
        //        Initiator = "Ivano pp",
        //    };
        //    using (var db = new EntitesContext())
        //    {
        //        test = new DbKeyFeatureClientDAO(db);
        //        //int idAdd = test.Add(kfc);
        //        //var all = test.GetAll();
        //        //var gatId = test.GetById(6);
        //        // var update = test.Update(kfcUp);
        //        var remove = test.Remove(6);
        //    }
        //}
        //static void TestKeyFeature()
        //{
        //    IContractKeyFeatureDAO test;

        //    KeyFeature kf = new KeyFeature
        //    {
        //        IdFeature = 1,
        //        IdHaspKey = 1,
        //        StartDate = DateTime.Now.Date.Date,
        //        EndDate = DateTime.Now.AddMonths(2).Date,
        //    };
        //    KeyFeature kfUpdate = new KeyFeature
        //    {
        //        Id = 6,
        //        IdFeature = 1,
        //        IdHaspKey = 1,
        //        StartDate = DateTime.Now.Date.Date,
        //        EndDate = DateTime.Now.AddMonths(2).Date,
        //    };


        //    using (var db = new EntitesContext())
        //    {
        //        test = new DbKeyFeatureDAO(db);
        //        // int KeyF = test.Add(kf);
        //        // var all = test.GetAll();
        //        // bool update = test.Update(kfUpdate);
        //        bool remove = test.Remove(6);
        //    }
        //}
        //static void TestClient()
        //{
        //    IContractClientDAO test;

        //    Client client = new Client
        //    {
        //        Address = "ul. Rachova d.1",
        //        ContactPerson = "Ivanov E.F.",
        //        Name = "OOO Frost",
        //        Phone = "333".ToString(),
        //    };

        //    Client update = new Client
        //    {
        //        Id = 2,
        //        Address = "ul. Lunnaya d.1",
        //        ContactPerson = "Iv E.F.",
        //        Name = "ost",
        //        Phone = "3456--3-5".ToString(),
        //    };

        //    using (var db = new EntitesContext())
        //    {
        //        test = new DbClientDAO(db);
        //        //var clientGetByNumberKey = test.GetByNumberKey(1235);

        //        Feature feature = new Feature
        //        {
        //            Id = 1235,
        //            Number = 1,
        //            Name = "FitPrint",
        //            Description = "qqq-www-eee",
        //        };


        //        //var clientGetByFeature = test.GetByFeature(feature).ToList();
        //        //var temp = test.GetAll();
        //        //int id = test.Add(client);
        //        // var client_ = test.GetById(10);
        //         var update_ = test.Update(update);
        //        // var remove = test.Remove(10);
        //    }
        //}
        //static void TestFeature()
        //{
        //    IContractFeatureDAO test;

        //    Feature feature = new Feature
        //    {
        //        Number = 27813,
        //        Name = "12-qwe-v",
        //        Description = null,
        //    };
        //    Feature update = new Feature
        //    {
        //        Id = 3,
        //        Number = 213445446,
        //        Name = "12-qwe-v",
        //        Description = "sdfdrt",
        //    };

        //    using (var db = new EntitesContext())
        //    {
        //        test = new DbFeatureDAO(db);


        //        var all = test.GetAll();

        //        // int id = test.Add(feature);
        //        //foreach(var str in test.GetAll())
        //        //     Console.WriteLine(str.Id +"-"+'\t'+str.Name+"-" + '\t'+str.Number+ "-" + '\t'+str.Description);

        //        // var feat = test.GetById(8);
        //        // var updateTest = test.Update(update);

        //        var remove = test.Remove(5);
        //    }
        //}
        static void TestHaspKey()
        {
            IContractHaspKeyDAO test;

            HaspKey key = new HaspKey
            {

                InnerId = 125,
                IsHome = true,
                Number = "12-34-df g",
                TypeKey = TypeKey.Pro,
            };

            HaspKey update = new HaspKey
            {
                Id = 5,
                InnerId = 125,
                IsHome = true,
                Number = "12-34-df g",
                TypeKey = TypeKey.Pro,
            };

            var ConnectionString =
            new SQLiteConnectionStringBuilder()
            {
               
                
            }
            .ConnectionString;


            // DataSource = @"D:\Новая папка\HASPKey\UnitTestDal\HASPKey"
            using (var db = new EntitesContext())
            {

                var jdj = db.Database.Connection.ConnectionString;
                

                test = new DbHaspKeyDAO(db);
                
               // var ff = test.GetAll();

                
                // var active = test.GaetByActive().ToList();
                Client client = new Client
                {
                    Id = 10,
                };

                //var keyClient = test.GetByClient(client).ToList();
                //var pastDue = test.GetByPastDue().ToList();
                //var ff = test.GetAll();

                bool id = test.Update(update);                
                /*
                 foreach(var str in test.GetAll())
                     Console.WriteLine(str.Id +"-"+'\t' + str.InnerId + "-"+'\t' + str.Number + "-"+ '\t' + str.TypeKey + "-"+ '\t' + str.Location);
                 
                 */
                //var haspKey = test.GetById(5);
                //var remove = test.Remove(2);
                //var updateTest = test.Update(update);               
            }
        }
    }
}
