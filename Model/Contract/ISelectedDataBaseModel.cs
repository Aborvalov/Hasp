using ModelEntities;

namespace Model
{
    public interface ISelectedDataBaseModel : IItemModel<TypeDataBase>
    {
        void EditItem(TypeDataBase dateBase);
    }
}
