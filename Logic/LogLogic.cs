using DalContract;
using Entities;
using LogicContract;
using System;
using System.Collections.Generic;


namespace Logic
{
    public class LogLogic : ILogLogic
    {
        private readonly IContractLogDAO logDAO;

        public LogLogic(IContractLogDAO logDAO)
        {
            this.logDAO = logDAO ?? throw new ArgumentNullException(nameof(logDAO));
        }

        public List<Log> GetAll() => logDAO.GetAll();

    }
}

