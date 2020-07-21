using ModelEntities;

namespace Model
{
    public class SelectedDataBaseModel : IItemModel<TypeDateBase>
    {
        public TypeDateBase GetItem()
        {
            return (TypeDateBase)4;
        }
    }
}
