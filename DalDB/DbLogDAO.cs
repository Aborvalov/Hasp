using DalContract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DalDB
{
    public class DbLogDAO : IContractLogDAO
    {
        private readonly EntitesContext db;

        public DbLogDAO(IEntitesContext db)
        {
            this.db = (EntitesContext)db ?? throw new ArgumentNullException(nameof(db));
        }

        public List<Log> GetAll() => db.Logs.OrderByDescending(log => log.LoginTime).ToList();
    }
}
