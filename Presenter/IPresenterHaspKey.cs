using ModelEntities;
using System.Collections.Generic;

namespace Presenter
{
    public interface IPresenterHaspKey : IPresenterEntites<ModelViewHaspKey>
    {
        
        
        //void GetByClient(Client client);






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
