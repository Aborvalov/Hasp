using System;
using System.Windows.Forms;

namespace HASPKey
{
   public class CalendarCell : DataGridViewTextBoxCell
    {
        public CalendarCell() 
            : base()
        {
            this.Style.Format = "d";
        }
        public override void InitializeEditingControl(int rowIndex, object
                 initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {            
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            CalendarEditingControl ctl =
                DataGridView.EditingControl as CalendarEditingControl;

            ctl.MinDate = DateTime.Now.Date;
            if (this.Value == null)
                ctl.NValue = (DateTime?)this.DefaultNewRowValue;
            else
                try
                { ctl.NValue = (DateTime)this.Value; }
                catch (Exception)
                { ctl.NValue = (DateTime?)this.DefaultNewRowValue; }
        }

        public override Type EditType
        {
            get => typeof(CalendarEditingControl);
        }

        public override Type ValueType
        {
            get => typeof(DateTime);
        }

        public override object DefaultNewRowValue
        {
            get => null;
        }
    }
}