﻿using ModelEntities;

namespace Presenter
{
    public interface IPresenterHaspKey : IPresenterEntites<ModelViewHaspKey>
    {
        void GetByClient(ModelViewClient client);
        /// <summary>
        /// Поиск просроченных ключей.
        /// </summary>
        /// <returns>Список просроченных ключей.</returns>
        void GetByPastDue();
        /// <summary>
        /// Поиск действующих ключей.
        /// </summary>
        /// <returns>Список действующих ключей.</returns>
        void GetByActive();
    }
}
