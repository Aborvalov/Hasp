namespace Presenter
{
    public interface IPresenterEntities<T>
    {
        void Display();
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        T Entities { get; set; }
    }
}
