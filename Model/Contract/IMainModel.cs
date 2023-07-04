using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IMainModel : IDisposable
    {
        List<ModelViewMain> GetActuallKeys();
        List<ModelViewMain> GetByClient(ModelViewClient client);
        List<ModelViewMain> ShowOldKeys();
    }
}
