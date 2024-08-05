using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ModelEntities
{
    public class DXModelClient
    {
        [DisplayName("Ключ")]
        public List<DXModelKeys> Keys { get; set; }

        [DisplayName("Лицензия закончится в следующие <N> дней")]
        public string Client { get; set; }

    }
}