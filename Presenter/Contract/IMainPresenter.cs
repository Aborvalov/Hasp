using ModelEntities;
using System;

namespace Presenter
{
    public interface IMainPresenter : IDisposable
    {
       void Views();
       void GetByClient(ModelViewClient client);
       void ShowExpiredKeys();
        int GetDaysFromXml();
    }
}