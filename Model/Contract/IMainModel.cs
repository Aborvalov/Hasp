using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IMainModel : IDisposable
    {
        List<ModelViewMain> GetActiveKeys();
        List<ModelViewMain> GetByClient(ModelViewClient client);
        List<ModelViewMain> ShowExpiredKeys();
    }
}
