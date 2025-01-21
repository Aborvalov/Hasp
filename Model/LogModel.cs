using Entities;
using Logic;
using LogicContract;
using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public class LogModel : ILogModel
    {
        private readonly ILogLogic logLogic;
        private readonly IFactoryLogic factoryLogic;
        private readonly IEntitesContext db;

        public LogModel(IFactoryLogic factoryLogic)
        {
            this.factoryLogic = factoryLogic ?? throw new ArgumentNullException(nameof(factoryLogic));

            db = Context.GetContext();
            if (db == null)
                throw new ArgumentNullException(nameof(db));

            logLogic = this.factoryLogic.CreateLog(db);
        }

        public List<ModelViewLog> GetAll()
        {
            return Convert(logLogic.GetAll());
        }

        private List<ModelViewLog> Convert(List<Log> clients)
        {
            var viewClients = new List<ModelViewLog>();
            foreach (var cl in clients)
                viewClients.Add(new ModelViewLog(cl));
            return viewClients;
        }
    }
}
