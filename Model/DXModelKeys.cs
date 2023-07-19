using System;
using System.ComponentModel;

namespace ModelEntities
{
    public class DXModelKeys
    {
        [DisplayName("Номер")]
        public string Number { get; set; }
        [DisplayName("Начало")]
        public DateTime StartDate { get; set; }
        [DisplayName("Конец")]
        public DateTime EndDate { get; set; }
    }
}
