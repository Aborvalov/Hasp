using System;
using System.Windows.Forms;

namespace HASPKey
{
    public class DataGridViewCalendarColumn : DataGridViewColumn
    {
        public DataGridViewCalendarColumn()
               : base(new CalendarCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get{ return base.CellTemplate;}
            set
            {
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(CalendarCell)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
