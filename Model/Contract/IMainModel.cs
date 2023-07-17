using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IMainModel : IDisposable
    {
        List<ModelMain> GetActiveKeys();
        List<ModelMain> GetByClient(ModelViewClient client);
        List<ModelMain> ShowExpiredKeys();
    }
}
