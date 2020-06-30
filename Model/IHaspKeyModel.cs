using ModelEntities;
using System.Collections.Generic;

namespace Model
{
    public interface IHaspKeyModel : IEntitesModel<ModelViewHaspKey>
    {
        List<ModelViewHaspKey> GetByClient(ModelViewClient client);
        /// <summary>
        /// Поиск просроченных ключей.
        /// </summary>
        /// <returns>Список просроченных ключей.</returns>
        List<ModelViewHaspKey> GetByPastDue();
        /// <summary>
        /// Поиск действующих ключей.
        /// </summary>
        /// <returns>Список действующих ключей.</returns>
        List<ModelViewHaspKey> GetByActive();
    }
}
