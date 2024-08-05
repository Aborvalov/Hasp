using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ModelEntities
{
    public class DXModelLicenseEnd
    {
        [DisplayName("Ключ")]
        public List<DXModelKeys> Keys { get; set; }

        [DisplayName("Лицензия закончилась в последующие <N> дней")]
        public string Client { get; set; }
    }

}