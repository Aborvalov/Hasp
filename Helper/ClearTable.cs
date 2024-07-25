using Entities;

namespace HelperForUnitTest
{
    public static class ClearTable
    {
        public static void HaspKeys(EntitesContext db)
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
        public static void Features(EntitesContext db)
        {
            db.Database.ExecuteSqlCommand("DROP TABLE Features");
            db.Database.ExecuteSqlCommand(@"CREATE TABLE Features (
                                                Id          INTEGER PRIMARY KEY AUTOINCREMENT
                                                                    NOT NULL
                                                                    UNIQUE,
                                                Number      INTEGER NOT NULL,
                                                Name        STRING  NOT NULL,
                                                Description STRING
                                            ); ");
            db.SaveChanges();
        }
        public static void Clients(EntitesContext db)
        {
            db.Database.ExecuteSqlCommand("DROP TABLE Clients");
            db.Database.ExecuteSqlCommand(@"CREATE TABLE Clients (
                                                Id            INTEGER PRIMARY KEY AUTOINCREMENT
                                                                      NOT NULL
                                                                      UNIQUE,
                                                Name          STRING  NOT NULL,
                                                Address       STRING,
                                                Phone         TEXT,
                                                ContactPerson STRING
                                            ); ");
            db.SaveChanges();
        }
        public static void KeyFeatures(EntitesContext db)
        {
            db.Database.ExecuteSqlCommand("DROP TABLE KeyFeatures");
            db.Database.ExecuteSqlCommand(@"CREATE TABLE KeyFeatures (
                                                Id        INTEGER PRIMARY KEY AUTOINCREMENT
                                                                  NOT NULL
                                                                  UNIQUE,
                                                IdHaspKey INTEGER NOT NULL
                                                                  REFERENCES HASPKeys (Id),
                                                idFeature INTEGER REFERENCES Features (Id) 
                                                                  NOT NULL,
                                                StartDate DATE    NOT NULL,
                                                EndDate   DATE    NOT NULL
                                            ); ");
            db.SaveChanges();
        }
        public static void KeyFeatureClients(EntitesContext db)
        {
            db.Database.ExecuteSqlCommand("DROP TABLE KeyFeatureClients");
            db.Database.ExecuteSqlCommand(@"CREATE TABLE KeyFeatureClients (
                                                Id           INTEGER PRIMARY KEY AUTOINCREMENT
                                                                     NOT NULL
                                                                     UNIQUE,
                                                IdKeyFeature INTEGER REFERENCES KeyFeatures (Id) 
                                                                     NOT NULL,
                                                IdClient     INTEGER REFERENCES Clients (Id) 
                                                                     NOT NULL,
                                                Note         STRING,
                                                Initiator    STRING
                                            ); ");
            db.SaveChanges();
        }
    }
}
