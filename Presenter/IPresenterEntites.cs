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
