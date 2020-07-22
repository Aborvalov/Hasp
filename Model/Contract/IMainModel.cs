using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IMainModel : IDisposable
    {
        List<ModelViewMain> GetAll();
        List<ModelViewMain> GetByClient(ModelViewClient client);
    }
}
