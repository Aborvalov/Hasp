using ModelEntities;
using System.Collections.Generic;

namespace Model
{
    public interface IHomeModel
    {
        void UpdateHome(ModelViewHome home);
        List<ModelViewHome> GetAll();
        ModelViewHome GetById(int Id);
    }
}
