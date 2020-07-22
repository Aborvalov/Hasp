using ModelEntities;
using System;

namespace Presenter
{
    public interface IPresenterMain : IDisposable
    {
       void Views();
       void GetByClient(ModelViewClient client);
    }
}