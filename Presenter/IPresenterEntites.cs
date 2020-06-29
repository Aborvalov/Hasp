using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presenter
{
    public interface IPresenterEntites<T>
    {
        void View();
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(int id);
    }
}
