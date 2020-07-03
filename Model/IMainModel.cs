using ModelEntities;
using System.Collections.Generic;

namespace Model
{
    public interface IMainModel
    {
        List<ModelViewMain> GetAll();
    }
}
