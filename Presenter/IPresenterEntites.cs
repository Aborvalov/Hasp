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
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
    }
}
