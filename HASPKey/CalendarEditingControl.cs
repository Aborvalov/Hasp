using System;
using System.Windows.Forms;

namespace HASPKey
{
    public class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        DataGridView dataGridView;
        private bool valueChanged = false;
        int chType = 0;
        int rowIndex;
        private DateTime? val = null;

        public DateTime? NValue
        {
            get { return val; }
            set
            {
                val = value;
                chType = 1;
                DateTime? t = null;
                try { t = (DateTime)val; }
                catch (Exception) { }
                chType = 0;
            }
        }


        public CalendarEditingControl()
        {
            this.Format = DateTimePickerFormat.Short;
            this.ValueChanged += CalendarEditingControl_ValueChanged;
        }

        void CalendarEditingControl_ValueChanged(object sender, EventArgs e)
        {
            if (chType == 0)
                val = this.Value;
        }
                
        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToShortDateString();
            }
            set
            {
                if (value is String)
                {
                    try
                    {
                        this.Value = DateTime.Parse((String)value);
                    }
                    catch
                    {
                        this.Value = DateTime.Now;
                    }
                }
            }
        }

        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        public int EditingControlRowIndex
        {
            get{return rowIndex;}
            set{rowIndex = value;}
        }

        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }

        public bool RepositionEditingControlOnValueChange
        {
            get{ return false; }
        }
        public DataGridView EditingControlDataGridView
        {
            get{ return dataGridView; }
            set{ dataGridView = value; }
        }

        public bool EditingControlValueChanged
        {
            get{ return valueChanged; }
            set{ valueChanged = value; }
        }
        public Cursor EditingPanelCursor
        {
            get{return base.Cursor;}
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            valueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventargs);
        }
    }
}
