using Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace DalDB
{
    public class Logging
    {
        private readonly EntitesContext db;
        public event EventHandler<LogEventArgs> LoggingEvent;

        public Logging(EntitesContext db)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public void OnLogging(LogEventArgs e)
        {
            LoggingEvent?.Invoke(this, e);
        }

        public void Subscribe(EventHandler<LogEventArgs> handler, string tableName, string action, int id)
        {
            LoggingEvent += handler;
            OnLogging(new LogEventArgs(tableName, action, id));
        }

        public void UpdateLog(string tableName, string action, int id)
        {
            var latestLog = db.Logs.OrderByDescending(l => l.LogId).FirstOrDefault();
            if (latestLog != null)
            {
                var log = $"{tableName}-{action}-{id}; ";
                latestLog.Actions += log;
                db.Entry(latestLog).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
