using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ModelEntities
{
    public class DXModelFeature
    {
        public string Name { get; set; }

        private string endDate;
        [DisplayName("Окончание действия")]
        public string EndDate
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
        }


    }
}
