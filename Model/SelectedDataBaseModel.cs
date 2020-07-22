using ModelEntities;
using System.IO;

namespace Model
{
    public class SelectedDataBaseModel : ISelectedDataBaseModel
    {
        private const string path = @".\DataBase.txt";

        public void EditItem(TypeDataBase dateBase)
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                sw.Write((int)dateBase);
            }
        }

        public TypeDataBase GetItem()
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return (TypeDataBase)int.Parse(sr.ReadToEnd());
                }
            }
            catch (FileNotFoundException)
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    sw.Write(-1);
                }
            }

            return (TypeDataBase)(-1);
        }
    }
}
