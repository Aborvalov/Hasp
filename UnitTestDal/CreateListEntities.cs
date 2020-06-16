using Entities;
using System;
using System.Collections.Generic;

namespace UnitTestDal
{
    internal static class CreateListEntities
    {
        private static DateTime date = DateTime.Now.Date;
        static internal List<HaspKey> HaspKeys()
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
        static internal List<Feature> Features()
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
        static internal List<Client> Clients()
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
        static internal List<KeyFeature> KeyFeatures()
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
        static internal List<KeyFeatureClient> KeyFeatureClients()
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
