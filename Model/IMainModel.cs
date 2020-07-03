using ModelEntities;
using System.Collections.Generic;

namespace Model
{
    public interface IMainModel
    {
        void UpdateHome(ModelViewMain home);
        List<ModelViewMain> GetAll();
        ModelViewMain GetById(int Id);
    }
}
