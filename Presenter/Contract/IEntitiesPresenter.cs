using System;

namespace Presenter
{
    public interface IEntitiesPresenter<T> : IDisposable, IViewPresenter
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        T Entities { get; set; }
        void FillInputItem(T item);       
        void FillModel(T item);
    }
}
