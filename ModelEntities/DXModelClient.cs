using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ModelEntities
{
    public class DXModelClient
    {
        [DisplayName("Ключ")]
        public List<DXModelKeys> Keys { get; set; }

        //[DisplayName("Функциональность")]
        //public List<DXModelFeature> Features { get; set; }
        [DisplayName("Клиент")]
        public string Client { get; set; }
        //public List<DXModelKeys> Feature { get; set; }
    }
}
