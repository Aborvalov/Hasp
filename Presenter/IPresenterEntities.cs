using System;

namespace Presenter
{
    public interface IPresenterEntities<T> : IDisposable, IPresenterView
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        T Entities { get; set; }
        void FillInputItem(T item);       
        void FillModel(T item);
    }
}
