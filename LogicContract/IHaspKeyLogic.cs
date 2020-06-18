﻿using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    public interface IHaspKeyLogic : IEntitesLogic<HaspKey>
    {
        List<HaspKey> GetByClient(Client client);
        /// <summary>
        /// Поиск просроченных ключей.
        /// </summary>
        /// <returns>Список просроченных ключей.</returns>
        List<HaspKey> GetByPastDue();
        /// <summary>
        /// Поиск действующих ключей.
        /// </summary>
        /// <returns>Список действующих ключей.</returns>
        List<HaspKey> GetByActive();
    }
}
