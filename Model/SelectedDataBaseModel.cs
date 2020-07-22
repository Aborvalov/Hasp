using ModelEntities;

namespace Model
{
    public class SelectedDataBaseModel : ISelectedDataBaseModel
    {
        static TypeDataBase typeDateBase = (TypeDataBase)4;

        public void EditItem(TypeDataBase dateBase)
        {
            typeDateBase = dateBase;
        }

        public TypeDataBase GetItem()
        {
            return typeDateBase;
        }

    }
}
