using System;
using ComponentFactory.Krypton.Toolkit;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Threading;

namespace Landlord2
{
    #region Old Code
    ///// <summary>
    ///// 继承KryptonDataGridViewDateTimePickerColumn列，改写了针对 "DateTime?"类型的Bug。
    ///// //参考：在 Windows 窗体 DataGridView 单元格中承载控件http://msdn.microsoft.com/zh-cn/library/7tas5c80.aspx
    ///// </summary>
    //public class MyDataGridViewDateTimePickerColumn : KryptonDataGridViewDateTimePickerColumn
    //{
    //    public MyDataGridViewDateTimePickerColumn()
    //        : base()
    //    {
    //        base.CellTemplate = new MyDataGridViewDateTimePickerCell();
    //    }

    //    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
    //    public override DataGridViewCell CellTemplate
    //    {
    //        get
    //        {
    //            return base.CellTemplate;
    //        }
    //        set
    //        {
    //            MyDataGridViewDateTimePickerCell cell = value as MyDataGridViewDateTimePickerCell;
    //            if ((value != null) && (cell == null))
    //            {
    //                throw new InvalidCastException("Value provided for CellTemplate must be of type KryptonDataGridViewDateTimePickerCell or derive from it.");
    //            }
    //            base.CellTemplate = value;
    //        }
    //    }
    //}

    //public class MyDataGridViewDateTimePickerCell : KryptonDataGridViewDateTimePickerCell
    //{
    //    private static DateTimeConverter _dtc = new DateTimeConverter();
    //    public MyDataGridViewDateTimePickerCell()
    //        : base()
    //    {
    //        // Use the short date format.
    //        this.Style.Format = "d";
    //    }
    //    public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
    //    {
    //        if (formattedValue == null)
    //        {
    //            //return DBNull.Value;
    //            return null;
    //        }
    //        string str = (string)formattedValue;
    //        if (string.IsNullOrEmpty(str))
    //        {
    //            //return DBNull.Value;
    //            return null;
    //        }
    //        return _dtc.ConvertFromInvariantString(str);
    //    }
    //} 
    #endregion

    #region New Code

    public class MyDataGridViewDateTimePickerCell : DataGridViewTextBoxCell
    {
        private bool _autoShift;
        private bool _calendarCloseOnTodayClick;
        private Size _calendarDimensions;
        private Day _calendarFirstDayOfWeek;
        private bool _calendarShowToday;
        private bool _calendarShowTodayCircle;
        private bool _calendarShowWeekNumbers;
        private DateTime _calendarTodayDate;
        private string _calendarTodayText;
        private bool _checked;
        private string _customFormat;
        private string _customNullText;
        private static readonly System.Type _defaultEditType = typeof(MyDataGridViewDateTimePickerEditingControl);
        private static readonly System.Type _defaultValueType = typeof(DateTime);
        private static DateTimeConverter _dtc = new DateTimeConverter();
        private DateTimePickerFormat _format;
        private DateTime _maxDate;
        private DateTime _minDate;
        [ThreadStatic]
        private static KryptonDateTimePicker _paintingDateTime;
        private bool _showCheckBox;
        private bool _showUpDown;
        private static readonly Size _sizeLarge = new Size(0x2710, 0x2710);

        public MyDataGridViewDateTimePickerCell()
        {
            if (_paintingDateTime == null)
            {
                _paintingDateTime = new KryptonDateTimePicker();
                _paintingDateTime.ShowBorder = false;
                _paintingDateTime.StateCommon.Border.Width = 0;
                _paintingDateTime.StateCommon.Border.Draw = InheritBool.False;
            }
            this._showCheckBox = false;
            this._showUpDown = false;
            this._autoShift = false;
            this._checked = false;
            this._customFormat = string.Empty;
            this._customNullText = " ";
            this._maxDate = DateTime.MaxValue;
            this._minDate = DateTime.MinValue;
            this._format = DateTimePickerFormat.Long;
            this._calendarDimensions = new Size(1, 1);
            this._calendarTodayText = "Today:";
            this._calendarFirstDayOfWeek = Day.Default;
            this._calendarShowToday = true;
            this._calendarCloseOnTodayClick = false;
            this._calendarShowTodayCircle = true;
            this._calendarShowWeekNumbers = false;
            this._calendarTodayDate = DateTime.Now.Date;
        }

        public override object Clone()
        {
            MyDataGridViewDateTimePickerCell cell = base.Clone() as MyDataGridViewDateTimePickerCell;
            if (cell != null)
            {
                cell.AutoShift = this.AutoShift;
                cell.Checked = this.Checked;
                cell.ShowCheckBox = this.ShowCheckBox;
                cell.ShowUpDown = this.ShowUpDown;
                cell.CustomFormat = this.CustomFormat;
                cell.CustomNullText = this.CustomNullText;
                cell.MaxDate = this.MaxDate;
                cell.MinDate = this.MinDate;
                cell.Format = this.Format;
                cell.CalendarDimensions = this.CalendarDimensions;
                cell.CalendarTodayText = this.CalendarTodayText;
                cell.CalendarFirstDayOfWeek = this.CalendarFirstDayOfWeek;
                cell.CalendarShowToday = this.CalendarShowToday;
                cell.CalendarCloseOnTodayClick = this.CalendarCloseOnTodayClick;
                cell.CalendarShowTodayCircle = this.CalendarShowTodayCircle;
                cell.CalendarShowWeekNumbers = this.CalendarShowWeekNumbers;
                cell.CalendarTodayDate = this.CalendarTodayDate;
            }
            return cell;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public override void DetachEditingControl()
        {
            DataGridView dataGridView = base.DataGridView;
            if ((dataGridView == null) || (dataGridView.EditingControl == null))
            {
                throw new InvalidOperationException("Cell is detached or its grid has no editing control.");
            }
            KryptonDateTimePicker editingControl = dataGridView.EditingControl as KryptonDateTimePicker;
            if (editingControl != null)
            {
                foreach (ButtonSpec spec in editingControl.ButtonSpecs)
                {
                    spec.Click -= new EventHandler(this.OnButtonClick);
                }
                editingControl.ButtonSpecs.Clear();
            }
            base.DetachEditingControl();
        }

        private Rectangle GetAdjustedEditingControlBounds(Rectangle editingControlBounds, DataGridViewCellStyle cellStyle)
        {
            int num = _paintingDateTime.GetPreferredSize(_sizeLarge).Height + 2;
            if (num < editingControlBounds.Height)
            {
                DataGridViewContentAlignment alignment = cellStyle.Alignment;
                if (alignment <= DataGridViewContentAlignment.MiddleRight)
                {
                    switch (alignment)
                    {
                        case DataGridViewContentAlignment.MiddleLeft:
                        case DataGridViewContentAlignment.MiddleCenter:
                        case DataGridViewContentAlignment.MiddleRight:
                            editingControlBounds.Y += (editingControlBounds.Height - num) / 2;
                            return editingControlBounds;
                    }
                    return editingControlBounds;
                }
                switch (alignment)
                {
                    case DataGridViewContentAlignment.BottomLeft:
                    case DataGridViewContentAlignment.BottomCenter:
                    case DataGridViewContentAlignment.BottomRight:
                        editingControlBounds.Y += editingControlBounds.Height - num;
                        return editingControlBounds;
                }
            }
            return editingControlBounds;
        }

        protected override Rectangle GetErrorIconBounds(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex)
        {
            Rectangle rectangle = base.GetErrorIconBounds(graphics, cellStyle, rowIndex);
            if (base.DataGridView.RightToLeft == RightToLeft.Yes)
            {
                rectangle.X = rectangle.Left + 0x10;
                return rectangle;
            }
            rectangle.X = rectangle.Left - 0x10;
            return rectangle;
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if ((value == null) || (value == DBNull.Value))
            {
                return string.Empty;
            }
            DateTime time = (DateTime)value;
            return _dtc.ConvertToInvariantString(time);
        }

        protected override Size GetPreferredSize(Graphics graphics, DataGridViewCellStyle cellStyle, int rowIndex, Size constraintSize)
        {
            if (base.DataGridView == null)
            {
                return new Size(-1, -1);
            }
            Size size = base.GetPreferredSize(graphics, cellStyle, rowIndex, constraintSize);
            if (constraintSize.Width == 0)
            {
                size.Width += 0x18;
            }
            return size;
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            KryptonDateTimePicker editingControl = base.DataGridView.EditingControl as KryptonDateTimePicker;
            if (editingControl != null)
            {
                MyDataGridViewDateTimePickerColumn owningColumn = base.OwningColumn as MyDataGridViewDateTimePickerColumn;
                if (owningColumn != null)
                {
                    editingControl.ShowCheckBox = this.ShowCheckBox;
                    editingControl.ShowUpDown = this.ShowUpDown;
                    editingControl.AutoShift = this.AutoShift;
                    editingControl.Checked = this.Checked;
                    editingControl.CustomFormat = this.CustomFormat;
                    editingControl.CustomNullText = this.CustomNullText;
                    editingControl.MaxDate = this.MaxDate;
                    editingControl.MinDate = this.MinDate;
                    editingControl.Format = this.Format;
                    editingControl.CalendarDimensions = this.CalendarDimensions;
                    editingControl.CalendarTodayText = this.CalendarTodayText;
                    editingControl.CalendarFirstDayOfWeek = this.CalendarFirstDayOfWeek;
                    editingControl.CalendarShowToday = this.CalendarShowToday;
                    editingControl.CalendarCloseOnTodayClick = this.CalendarCloseOnTodayClick;
                    editingControl.CalendarShowTodayCircle = this.CalendarShowTodayCircle;
                    editingControl.CalendarShowWeekNumbers = this.CalendarShowWeekNumbers;
                    editingControl.CalendarTodayDate = this.CalendarTodayDate;
                    editingControl.CalendarAnnuallyBoldedDates = owningColumn.CalendarAnnuallyBoldedDates;
                    editingControl.CalendarMonthlyBoldedDates = owningColumn.CalendarMonthlyBoldedDates;
                    editingControl.CalendarBoldedDates = owningColumn.CalendarBoldedDates;
                    editingControl.ButtonSpecs.Clear();
                    editingControl.ButtonSpecs.Owner = base.DataGridView.Rows[rowIndex].Cells[base.ColumnIndex];
                    foreach (ButtonSpec spec in owningColumn.ButtonSpecs)
                    {
                        spec.Click += new EventHandler(this.OnButtonClick);
                        editingControl.ButtonSpecs.Add(spec);
                    }
                }
                string str = initialFormattedValue as string;
                if ((str == null) || string.IsNullOrEmpty(str))
                {
                    editingControl.ValueNullable = null;
                }
                else
                {
                    DateTime time = (DateTime)_dtc.ConvertFromInvariantString(str);
                    editingControl.Value = time;
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            MyDataGridViewDateTimePickerColumn owningColumn = base.OwningColumn as MyDataGridViewDateTimePickerColumn;
            DataGridViewButtonSpecClickEventArgs args = new DataGridViewButtonSpecClickEventArgs(owningColumn, this, (ButtonSpecAny)sender);
            owningColumn.PerfomButtonSpecClick(args);
        }

        private void OnCommonChange()
        {
            if (((base.DataGridView != null) && !base.DataGridView.IsDisposed) && !base.DataGridView.Disposing)
            {
                if (base.RowIndex == -1)
                {
                    base.DataGridView.InvalidateColumn(base.ColumnIndex);
                }
                else
                {
                    base.DataGridView.UpdateCellValue(base.ColumnIndex, base.RowIndex);
                }
            }
        }

        private bool OwnsEditingDateTimePicker(int rowIndex)
        {
            if ((rowIndex == -1) || (base.DataGridView == null))
            {
                return false;
            }
            MyDataGridViewDateTimePickerEditingControl editingControl = base.DataGridView.EditingControl as MyDataGridViewDateTimePickerEditingControl;
            return ((editingControl != null) && (rowIndex == editingControl.EditingControlRowIndex));
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            if (base.DataGridView != null)
            {
                _paintingDateTime.RightToLeft = base.DataGridView.RightToLeft;
                _paintingDateTime.Format = this.Format;
                _paintingDateTime.CustomFormat = this.CustomFormat;
                _paintingDateTime.CustomNullText = this.CustomNullText;
                _paintingDateTime.MaxDate = this.MaxDate;
                _paintingDateTime.MinDate = this.MinDate;
                string customNullText = this.CustomNullText;
                if ((value == null) || (value == DBNull.Value))
                {
                    _paintingDateTime.ValueNullable = value;
                    _paintingDateTime.PerformLayout();
                }
                else
                {
                    _paintingDateTime.Value = (DateTime)value;
                    _paintingDateTime.PerformLayout();
                    customNullText = _paintingDateTime.Text;
                }
                base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, customNullText, errorText, cellStyle, advancedBorderStyle, paintParts);
            }
        }

        public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle, TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
        {
            if (formattedValue == null)
            {
                //return DBNull.Value;
                return null;
            }
            string str = (string)formattedValue;
            if (string.IsNullOrEmpty(str))
            {
                //return DBNull.Value;
                return null;
            }
            return _dtc.ConvertFromInvariantString(str);
        }

        private static bool PartPainted(DataGridViewPaintParts paintParts, DataGridViewPaintParts paintPart)
        {
            return ((paintParts & paintPart) != DataGridViewPaintParts.None);
        }

        public override void PositionEditingControl(bool setLocation, bool setSize, Rectangle cellBounds, Rectangle cellClip, DataGridViewCellStyle cellStyle, bool singleVerticalBorderAdded, bool singleHorizontalBorderAdded, bool isFirstDisplayedColumn, bool isFirstDisplayedRow)
        {
            Rectangle editingControlBounds = this.PositionEditingPanel(cellBounds, cellClip, cellStyle, singleVerticalBorderAdded, singleHorizontalBorderAdded, isFirstDisplayedColumn, isFirstDisplayedRow);
            editingControlBounds = this.GetAdjustedEditingControlBounds(editingControlBounds, cellStyle);
            base.DataGridView.EditingControl.Location = new Point(editingControlBounds.X, editingControlBounds.Y);
            base.DataGridView.EditingControl.Size = new Size(editingControlBounds.Width, editingControlBounds.Height);
        }

        private void ResetCalendarTodayDate()
        {
            this.CalendarTodayDate = DateTime.Now.Date;
        }

        private void ResetMaxDate()
        {
            this.MaxDate = DateTime.MaxValue;
        }

        private void ResetMinDate()
        {
            this.MinDate = DateTime.MinValue;
        }

        internal void SetAutoShift(int rowIndex, bool value)
        {
            this._autoShift = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.AutoShift = value;
            }
        }

        internal void SetCalendarCloseOnTodayClick(int rowIndex, bool value)
        {
            this._calendarCloseOnTodayClick = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.CalendarCloseOnTodayClick = value;
            }
        }

        internal void SetCalendarDimensions(int rowIndex, Size value)
        {
            this._calendarDimensions = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.CalendarDimensions = value;
            }
        }

        internal void SetCalendarFirstDayOfWeek(int rowIndex, Day value)
        {
            this._calendarFirstDayOfWeek = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.CalendarFirstDayOfWeek = value;
            }
        }

        internal void SetCalendarShowToday(int rowIndex, bool value)
        {
            this._calendarShowToday = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.CalendarShowToday = value;
            }
        }

        internal void SetCalendarShowTodayCircle(int rowIndex, bool value)
        {
            this._calendarShowTodayCircle = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.CalendarShowTodayCircle = value;
            }
        }

        internal void SetCalendarShowWeekNumbers(int rowIndex, bool value)
        {
            this._calendarShowWeekNumbers = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.CalendarShowWeekNumbers = value;
            }
        }

        internal void SetCalendarTodayDate(int rowIndex, DateTime value)
        {
            this._calendarTodayDate = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.CalendarTodayDate = value;
            }
        }

        internal void SetCalendarTodayText(int rowIndex, string value)
        {
            this._calendarTodayText = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.CalendarTodayText = value;
            }
        }

        internal void SetChecked(int rowIndex, bool value)
        {
            this._checked = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.Checked = value;
            }
        }

        internal void SetCustomFormat(int rowIndex, string value)
        {
            this._customFormat = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.CustomFormat = value;
            }
        }

        internal void SetCustomNullText(int rowIndex, string value)
        {
            this._customNullText = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.CustomNullText = value;
            }
        }

        internal void SetFormat(int rowIndex, DateTimePickerFormat value)
        {
            this._format = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.Format = value;
            }
        }

        internal void SetMaxDate(int rowIndex, DateTime value)
        {
            this._maxDate = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.MaxDate = value;
            }
        }

        internal void SetMinDate(int rowIndex, DateTime value)
        {
            this._minDate = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.MinDate = value;
            }
        }

        internal void SetShowCheckBox(int rowIndex, bool value)
        {
            this._showCheckBox = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.ShowCheckBox = value;
            }
        }

        internal void SetShowUpDown(int rowIndex, bool value)
        {
            this._showUpDown = value;
            if (this.OwnsEditingDateTimePicker(rowIndex))
            {
                this.EditingDateTimePicker.ShowUpDown = value;
            }
        }

        private bool ShouldSerializeCalendarTodayDate()
        {
            return (this.CalendarTodayDate != DateTime.Now.Date);
        }

        public bool ShouldSerializeMaxDate()
        {
            return ((this.MaxDate != DateTimePicker.MaximumDateTime) && (this.MaxDate != DateTime.MaxValue));
        }

        public bool ShouldSerializeMinDate()
        {
            return ((this.MinDate != DateTimePicker.MinimumDateTime) && (this.MinDate != DateTime.MinValue));
        }

        public override string ToString()
        {
            return ("KryptonDataGridViewDateTimePickerCell { ColumnIndex=" + base.ColumnIndex.ToString(CultureInfo.CurrentCulture) + ", RowIndex=" + base.RowIndex.ToString(CultureInfo.CurrentCulture) + " }");
        }

        [DefaultValue(false)]
        public bool AutoShift
        {
            get
            {
                return this._autoShift;
            }
            set
            {
                if (this._autoShift != value)
                {
                    this.SetAutoShift(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue(true)]
        public bool CalendarCloseOnTodayClick
        {
            get
            {
                return this._calendarCloseOnTodayClick;
            }
            set
            {
                if (this._calendarCloseOnTodayClick != value)
                {
                    this.SetCalendarCloseOnTodayClick(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue(typeof(Size), "1,1")]
        public Size CalendarDimensions
        {
            get
            {
                return this._calendarDimensions;
            }
            set
            {
                if (this._calendarDimensions != value)
                {
                    this.SetCalendarDimensions(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue(typeof(Day), "Default")]
        public Day CalendarFirstDayOfWeek
        {
            get
            {
                return this._calendarFirstDayOfWeek;
            }
            set
            {
                if (this._calendarFirstDayOfWeek != value)
                {
                    this.SetCalendarFirstDayOfWeek(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue(true)]
        public bool CalendarShowToday
        {
            get
            {
                return this._calendarShowToday;
            }
            set
            {
                if (this._calendarShowToday != value)
                {
                    this.SetCalendarShowToday(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue(true)]
        public bool CalendarShowTodayCircle
        {
            get
            {
                return this._calendarShowTodayCircle;
            }
            set
            {
                if (this._calendarShowTodayCircle != value)
                {
                    this.SetCalendarShowTodayCircle(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue(true)]
        public bool CalendarShowWeekNumbers
        {
            get
            {
                return this._calendarShowWeekNumbers;
            }
            set
            {
                if (this._calendarShowWeekNumbers != value)
                {
                    this.SetCalendarShowWeekNumbers(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue(true)]
        public DateTime CalendarTodayDate
        {
            get
            {
                return this._calendarTodayDate;
            }
            set
            {
                if (this._calendarTodayDate != value)
                {
                    this.SetCalendarTodayDate(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue("Today:")]
        public string CalendarTodayText
        {
            get
            {
                return this._calendarTodayText;
            }
            set
            {
                if (this._calendarTodayText != value)
                {
                    this.SetCalendarTodayText(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue(false)]
        public bool Checked
        {
            get
            {
                return this._checked;
            }
            set
            {
                if (this._checked != value)
                {
                    this.SetChecked(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue("")]
        public string CustomFormat
        {
            get
            {
                return this._customFormat;
            }
            set
            {
                if (this._customFormat != value)
                {
                    this.SetCustomFormat(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue(" ")]
        public string CustomNullText
        {
            get
            {
                return this._customNullText;
            }
            set
            {
                if (this._customNullText != value)
                {
                    this.SetCustomNullText(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        private MyDataGridViewDateTimePickerEditingControl EditingDateTimePicker
        {
            get
            {
                return (base.DataGridView.EditingControl as MyDataGridViewDateTimePickerEditingControl);
            }
        }

        public override System.Type EditType
        {
            get
            {
                return _defaultEditType;
            }
        }

        [DefaultValue(typeof(DateTimePickerFormat), "Long")]
        public DateTimePickerFormat Format
        {
            get
            {
                return this._format;
            }
            set
            {
                if (this._format != value)
                {
                    this.SetFormat(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        public DateTime MaxDate
        {
            get
            {
                return this._maxDate;
            }
            set
            {
                if (this._maxDate != value)
                {
                    this.SetMaxDate(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        public DateTime MinDate
        {
            get
            {
                return this._minDate;
            }
            set
            {
                if (this._minDate != value)
                {
                    this.SetMinDate(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue(false)]
        public bool ShowCheckBox
        {
            get
            {
                return this._showCheckBox;
            }
            set
            {
                if (this._showCheckBox != value)
                {
                    this.SetShowCheckBox(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        [DefaultValue(false)]
        public bool ShowUpDown
        {
            get
            {
                return this._showUpDown;
            }
            set
            {
                if (this._showUpDown != value)
                {
                    this.SetShowUpDown(base.RowIndex, value);
                    this.OnCommonChange();
                }
            }
        }

        public override System.Type ValueType
        {
            get
            {
                System.Type valueType = base.ValueType;
                if (valueType != null)
                {
                    return valueType;
                }
                return _defaultValueType;
            }
        }
    }

    [ToolboxItem(false)]
    public class MyDataGridViewDateTimePickerEditingControl : KryptonDateTimePicker, IDataGridViewEditingControl
    {
        private DataGridView _dataGridView;
        private static DateTimeConverter _dtc = new DateTimeConverter();
        private int _rowIndex;
        private bool _valueChanged;

        public MyDataGridViewDateTimePickerEditingControl()
        {
            base.TabStop = false;
            base.StateCommon.Border.Width = 0;
            base.StateCommon.Border.Draw = InheritBool.False;
            base.ShowBorder = false;
        }

        public virtual void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.StateCommon.Content.Font = dataGridViewCellStyle.Font;
            base.StateCommon.Content.Color1 = dataGridViewCellStyle.ForeColor;
            base.StateCommon.Back.Color1 = dataGridViewCellStyle.BackColor;
        }

        public virtual bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch ((keyData & Keys.KeyCode))
            {
                case Keys.Home:
                case Keys.Left:
                case Keys.Up:
                case Keys.Right:
                case Keys.Down:
                case Keys.Delete:
                    return true;
            }
            return !dataGridViewWantsInputKey;
        }

        public virtual object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            if ((base.ValueNullable != null) && (base.ValueNullable != DBNull.Value))
            {
                return _dtc.ConvertToInvariantString(base.Value);
            }
            return string.Empty;
        }

        private void NotifyDataGridViewOfValueChange()
        {
            if (!this._valueChanged)
            {
                this._valueChanged = true;
                this._dataGridView.NotifyCurrentCellDirty(true);
            }
        }

        protected override void OnValueNullableChanged(EventArgs e)
        {
            base.OnValueNullableChanged(e);
            if (this.Focused)
            {
                this.NotifyDataGridViewOfValueChange();
            }
        }

        public virtual void PrepareEditingControlForEdit(bool selectAll)
        {
        }

        public virtual DataGridView EditingControlDataGridView
        {
            get
            {
                return this._dataGridView;
            }
            set
            {
                this._dataGridView = value;
            }
        }

        public virtual object EditingControlFormattedValue
        {
            get
            {
                return this.GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting);
            }
            set
            {
                if ((value == null) || (value == DBNull.Value))
                {
                    base.ValueNullable = value;
                }
                else
                {
                    string str = value as string;
                    if (string.IsNullOrEmpty(str))
                    {
                        base.ValueNullable = (str == string.Empty) ? null : value;
                    }
                    else
                    {
                        base.Value = (DateTime)_dtc.ConvertFromInvariantString(str);
                    }
                }
            }
        }

        public virtual int EditingControlRowIndex
        {
            get
            {
                return this._rowIndex;
            }
            set
            {
                this._rowIndex = value;
            }
        }

        public virtual bool EditingControlValueChanged
        {
            get
            {
                return this._valueChanged;
            }
            set
            {
                this._valueChanged = value;
            }
        }

        public virtual Cursor EditingPanelCursor
        {
            get
            {
                return Cursors.Default;
            }
        }

        public virtual bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }
    }

    [ToolboxBitmap(typeof(MyDataGridViewDateTimePickerColumn), "ToolboxBitmaps.KryptonDateTimePicker.bmp"), Designer("ComponentFactory.Krypton.Toolkit.KryptonDateTimePickerColumnDesigner, ComponentFactory.Krypton.Design, Version=4.3.2.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
    public class MyDataGridViewDateTimePickerColumn : DataGridViewColumn
    {
        private DateTimeList _annualDates;
        private DataGridViewColumnSpecCollection _buttonSpecs;
        private DateTimeList _dates;
        private DateTimeList _monthlyDates;
        private EventHandler<DataGridViewButtonSpecClickEventArgs> _ButtonSpecClick;

        public event EventHandler<DataGridViewButtonSpecClickEventArgs> ButtonSpecClick
        {
            add
            {
                EventHandler<DataGridViewButtonSpecClickEventArgs> handler2;
                EventHandler<DataGridViewButtonSpecClickEventArgs> buttonSpecClick = this._ButtonSpecClick;
                do
                {
                    handler2 = buttonSpecClick;
                    EventHandler<DataGridViewButtonSpecClickEventArgs> handler3 = (EventHandler<DataGridViewButtonSpecClickEventArgs>)Delegate.Combine(handler2, value);
                    buttonSpecClick = Interlocked.CompareExchange<EventHandler<DataGridViewButtonSpecClickEventArgs>>(ref this._ButtonSpecClick, handler3, handler2);
                }
                while (buttonSpecClick != handler2);
            }
            remove
            {
                EventHandler<DataGridViewButtonSpecClickEventArgs> handler2;
                EventHandler<DataGridViewButtonSpecClickEventArgs> buttonSpecClick = this._ButtonSpecClick;
                do
                {
                    handler2 = buttonSpecClick;
                    EventHandler<DataGridViewButtonSpecClickEventArgs> handler3 = (EventHandler<DataGridViewButtonSpecClickEventArgs>)Delegate.Remove(handler2, value);
                    buttonSpecClick = Interlocked.CompareExchange<EventHandler<DataGridViewButtonSpecClickEventArgs>>(ref this._ButtonSpecClick, handler3, handler2);
                }
                while (buttonSpecClick != handler2);
            }
        }

        public MyDataGridViewDateTimePickerColumn()
            : base(new MyDataGridViewDateTimePickerCell())
        {
            this._buttonSpecs = new DataGridViewColumnSpecCollection(this);
            this._annualDates = new DateTimeList();
            this._monthlyDates = new DateTimeList();
            this._dates = new DateTimeList();
        }

        public override object Clone()
        {
            MyDataGridViewDateTimePickerColumn column = base.Clone() as MyDataGridViewDateTimePickerColumn;
            column.CalendarAnnuallyBoldedDates = this.CalendarAnnuallyBoldedDates;
            column.CalendarMonthlyBoldedDates = this.CalendarMonthlyBoldedDates;
            column.CalendarBoldedDates = this.CalendarBoldedDates;
            foreach (ButtonSpec spec in this.ButtonSpecs)
            {
                column.ButtonSpecs.Add(spec.Clone());
            }
            return column;
        }

        internal void PerfomButtonSpecClick(DataGridViewButtonSpecClickEventArgs args)
        {
            if (this._ButtonSpecClick != null)
            {
                this._ButtonSpecClick(this, args);
            }
        }

        private void ResetCalendarAnnuallyBoldedDates()
        {
            this.CalendarAnnuallyBoldedDates = null;
        }

        private void ResetCalendarBoldedDates()
        {
            this.CalendarBoldedDates = null;
        }

        private void ResetCalendarMonthlyBoldedDates()
        {
            this.CalendarMonthlyBoldedDates = null;
        }

        private void ResetCalendarTodayDate()
        {
            this.CalendarTodayDate = DateTime.Now.Date;
        }

        public void ResetCalendarTodayText()
        {
            this.CalendarTodayText = "Today:";
        }

        private void ResetMaxDate()
        {
            this.MaxDate = DateTime.MaxValue;
        }

        private void ResetMinDate()
        {
            this.MinDate = DateTime.MinValue;
        }

        public bool ShouldSerializeCalendarAnnuallyBoldedDates()
        {
            return (this._annualDates.Count > 0);
        }

        public bool ShouldSerializeCalendarBoldedDates()
        {
            return (this._dates.Count > 0);
        }

        public bool ShouldSerializeCalendarMonthlyBoldedDates()
        {
            return (this._monthlyDates.Count > 0);
        }

        private bool ShouldSerializeCalendarTodayDate()
        {
            return (this.CalendarTodayDate != DateTime.Now.Date);
        }

        public bool ShouldSerializeMaxDate()
        {
            return ((this.MaxDate != DateTimePicker.MaximumDateTime) && (this.MaxDate != DateTime.MaxValue));
        }

        public bool ShouldSerializeMinDate()
        {
            return ((this.MinDate != DateTimePicker.MinimumDateTime) && (this.MinDate != DateTime.MinValue));
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder(0x40);
            builder.Append("KryptonDataGridViewDateTimePickerColumn { Name=");
            builder.Append(base.Name);
            builder.Append(", Index=");
            builder.Append(base.Index.ToString(CultureInfo.CurrentCulture));
            builder.Append(" }");
            return builder.ToString();
        }

        [DefaultValue(false), Category("Behavior"), Description("Determines if keyboard input will automatically shift to the next input field.")]
        public bool AutoShift
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.AutoShift;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.AutoShift = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetAutoShift(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [Description("Set of extra button specs to appear with control."), Category("Data"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public DataGridViewColumnSpecCollection ButtonSpecs
        {
            get
            {
                return this._buttonSpecs;
            }
        }

        [Localizable(true), Description("Indicates which annual dates should be boldface."), Category("MonthCalendar")]
        public DateTime[] CalendarAnnuallyBoldedDates
        {
            get
            {
                return this._annualDates.ToArray();
            }
            set
            {
                if (value == null)
                {
                    value = new DateTime[0];
                }
                this._annualDates.Clear();
                this._annualDates.AddRange(value);
            }
        }

        [Category("MonthCalendar"), Localizable(true), Description("Indicates which dates should be boldface.")]
        public DateTime[] CalendarBoldedDates
        {
            get
            {
                return this._dates.ToArray();
            }
            set
            {
                if (value == null)
                {
                    value = new DateTime[0];
                }
                this._dates.Clear();
                this._dates.AddRange(value);
            }
        }

        [DefaultValue(false), Category("MonthCalendar"), Description("Indicates if clicking the Today button closes the drop down menu.")]
        public bool CalendarCloseOnTodayClick
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.CalendarCloseOnTodayClick;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.CalendarCloseOnTodayClick = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetCalendarCloseOnTodayClick(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [Category("MonthCalendar"), DefaultValue(typeof(Size), "1,1"), Description("Specifies the number of rows and columns of months displayed.")]
        public Size CalendarDimensions
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.CalendarDimensions;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.CalendarDimensions = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetCalendarDimensions(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [Category("MonthCalendar"), DefaultValue(typeof(Day), "Default"), Description("First day of the week.")]
        public Day CalendarFirstDayOfWeek
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.CalendarFirstDayOfWeek;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.CalendarFirstDayOfWeek = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetCalendarFirstDayOfWeek(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [Localizable(true), Category("MonthCalendar"), Description("Indicates which monthly dates should be boldface.")]
        public DateTime[] CalendarMonthlyBoldedDates
        {
            get
            {
                return this._monthlyDates.ToArray();
            }
            set
            {
                if (value == null)
                {
                    value = new DateTime[0];
                }
                this._monthlyDates.Clear();
                this._monthlyDates.AddRange(value);
            }
        }

        [Category("MonthCalendar"), DefaultValue(true), Description("Indicates whether this month calendar will display todays date.")]
        public bool CalendarShowToday
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.CalendarShowToday;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.CalendarShowToday = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetCalendarShowToday(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [DefaultValue(true), Description("Indicates whether this month calendar will circle the today date."), Category("MonthCalendar")]
        public bool CalendarShowTodayCircle
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.CalendarShowTodayCircle;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.CalendarShowTodayCircle = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetCalendarShowTodayCircle(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [Category("MonthCalendar"), Description("Indicates whether this month calendar will display week numbers to the left of each row."), DefaultValue(false)]
        public bool CalendarShowWeekNumbers
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.CalendarShowWeekNumbers;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.CalendarShowWeekNumbers = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetCalendarShowWeekNumbers(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [Description("Today's date."), Category("MonthCalendar")]
        public DateTime CalendarTodayDate
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.CalendarTodayDate;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.CalendarTodayDate = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetCalendarTodayDate(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [DefaultValue("Today:"), Description("Text used as label for todays date."), Category("MonthCalendar")]
        public string CalendarTodayText
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.CalendarTodayText;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.CalendarTodayText = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetCalendarTodayText(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                MyDataGridViewDateTimePickerCell cell = value as MyDataGridViewDateTimePickerCell;
                if ((value != null) && (cell == null))
                {
                    throw new InvalidCastException("Value provided for CellTemplate must be of type KryptonDataGridViewDateTimePickerCell or derive from it.");
                }
                base.CellTemplate = value;
            }
        }

        [Description("Determines if the check box is checked and if the ValueNullable is DBNull or a DateTime value."), DefaultValue(true), Category("Behavior")]
        public bool Checked
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.Checked;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.Checked = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetChecked(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [Description("The custom format string used to format the date and/or time displayed in the control."), DefaultValue(""), Category("Behavior")]
        public string CustomFormat
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.CustomFormat;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.CustomFormat = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetCustomFormat(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [Category("Behavior"), Description("The custom text to draw when the control is not checked. Provide an empty string for default action of showing the defined date."), DefaultValue(" ")]
        public string CustomNullText
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.CustomNullText;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.CustomNullText = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetCustomNullText(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        private MyDataGridViewDateTimePickerCell DateTimePickerCellTemplate
        {
            get
            {
                return (MyDataGridViewDateTimePickerCell)this.CellTemplate;
            }
        }

        [Description("Determines whether dates and times are displayed using standard or custom formatting."), DefaultValue(typeof(DateTimePickerFormat), "Long"), Category("Appearance"), RefreshProperties(RefreshProperties.Repaint)]
        public DateTimePickerFormat Format
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.Format;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.Format = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetFormat(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [Description("Maximum allowable date."), Category("Behavior")]
        public DateTime MaxDate
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.MaxDate;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.MaxDate = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetMaxDate(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [Category("Behavior"), Description("Minimum allowable date.")]
        public DateTime MinDate
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.MinDate;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.MinDate = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetMinDate(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [Category("Appearance"), DefaultValue(false), Description("Determines whether a check box is displayed in the control. When the box is unchecked, no value is selected.")]
        public bool ShowCheckBox
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.ShowCheckBox;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.ShowCheckBox = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetShowCheckBox(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }

        [DefaultValue(false), Category("Appearance"), Description("Indicates whether a spin box rather than a drop-down calendar is displayed for modifying the control value.")]
        public bool ShowUpDown
        {
            get
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                return this.DateTimePickerCellTemplate.ShowUpDown;
            }
            set
            {
                if (this.DateTimePickerCellTemplate == null)
                {
                    throw new InvalidOperationException("Operation cannot be completed because this DataGridViewColumn does not have a CellTemplate.");
                }
                this.DateTimePickerCellTemplate.ShowUpDown = value;
                if (base.DataGridView != null)
                {
                    DataGridViewRowCollection rows = base.DataGridView.Rows;
                    int count = rows.Count;
                    for (int i = 0; i < count; i++)
                    {
                        MyDataGridViewDateTimePickerCell cell = rows.SharedRow(i).Cells[base.Index] as MyDataGridViewDateTimePickerCell;
                        if (cell != null)
                        {
                            cell.SetShowUpDown(i, value);
                        }
                    }
                    base.DataGridView.InvalidateColumn(base.Index);
                }
            }
        }
    }

    #endregion
}
