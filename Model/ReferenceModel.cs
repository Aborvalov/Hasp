using System;

namespace Model
{
    public class ReferenceModel : IItemModel<string>
    {
        private const string text1 = @"Программа для учета HASP-ключей, реализующая:

1.	Возможность добавления, обновления и удаления ключей.
2.	Поиск компании-пользователя по номеру ключа и по
    функциональности, содержащейся на ключе.
3.	Поиск ключей по компании-пользователю.
4.	Поиск ключей с истекшим сроком действия.
";
        public string GetItem()
            => text1;
    }
}
