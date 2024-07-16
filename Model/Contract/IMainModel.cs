using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IMainModel : IDisposable
    {
        List<ModelMain> GetActiveKeys();
        List<ModelMain> GetKeysNextNDays();
        List<ModelMain> GetKeysPastNDays();
        List<ModelMain> GetAll();
        List<ModelMain> GetByClient(ModelViewClient client);
        List<ModelMain> ShowExpiredKeys();
    }
}
