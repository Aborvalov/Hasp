namespace Model
{
    public class ReferenceModel : IItemModel<string>
    {
        public string GetItem() 
            => "Тут должно быть какое-то описание.";
    }
}
