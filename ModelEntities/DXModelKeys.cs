using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ModelEntities
{
    public class DXModelKeys
    {
        [DisplayName("Номер")]
        public string Number { get; set; }
        //private string endDate;
        //[DisplayName("Окончание действия")]
        /*public string EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                if (value.IndexOf("2111") >= 0)
                {
                    endDate = "бессрочные";
                }
                else
                {
                    endDate = DateTime.Parse(value).ToString("dd.MM.yyyy");
                }
            }
        }*/
        //[DisplayName("Осталось дней")]
        /*public string RemainedDays { get; set; }
        public List<DXModelFeature> Keys { get; set; }*/
        public string Name { get; set; }
        public List<DXModelFeature> Feature { get; set; }
    }
}
