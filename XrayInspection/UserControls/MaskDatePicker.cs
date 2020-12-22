/*
 *  파 일 명 : MaskDatePicker.cs
 *  작 성 자 : 김현욱
 *  설    명 : Label과 DateTimePicker를 합친 UserControl
 *  이    력 : 2019/04/25 김현욱 - 최초 작성
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XrayInspection.UserControls
{
    public partial class MaskDatePicker : UserControl, IMaskUserControl
    {
        #region Properties

        [Description("Label Text"), Category("Mask Manager Control Properties")]
        public string ucLabelText
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        [Description("DatePicker Text"), Category("Mask Manager Control Properties")]
        public DateTime ucValue
        {
            get { return dtpDatePicker.Value; }
            set { dtpDatePicker.Value = value; }
        }

        [Description("필수입력여부"), Category("Mask Manager Control Properties")]
        public bool ucMandatory
        {
            get
            {
                if (lblMandatory.Text == "*") return true;
                else return false;
            }
            set
            {
                if (value)
                {
                    lblMandatory.Text = "*";
                }
                else
                {
                    lblMandatory.Text = "";
                }
            }
        }

        [Description("DatePicker Enabled"), Category("Mask Manager Control Properties")]
        public bool ucDatePickerEnabled
        {
            get { return dtpDatePicker.Enabled; }
            set { dtpDatePicker.Enabled = value; }
        }

        [Description("DatePicker Format"), Category("Mask Manager Control Properties")]
        public DateTimePickerFormat ucDatePickerFormat
        {
            get { return dtpDatePicker.Format; }
            set { dtpDatePicker.Format = value; }
        }

        [Description("DatePicker Custom Format"), Category("Mask Manager Control Properties")]
        public string ucDatePickerCustomFormat
        {
            get { return dtpDatePicker.CustomFormat; }
            set { dtpDatePicker.CustomFormat = value; }
        }

        public TextBox ucTextBox { get; set; }


        /// <summary>
        /// 입력이 안 되어있으면 true, 입력이 되어있으면 false 
        /// </summary>
        public bool ucMandatoryCheck
        {
            get
            {
                bool textCheck = ucTextBox == null ? true : CommonFuction.IsNullOrWhiteSpace(ucTextBox.Text);
                return CommonFuction.IsNullOrWhiteSpace(ucValue) || textCheck;
            }
        }

        #endregion

        #region Events

        [Description("DatePicker 값 변경 이벤트"), Category("Mask Manager Control Event")]
        public event EventHandler maskDatePickerValueChangedEvent;

        #endregion

        public MaskDatePicker()
        {
            InitializeComponent();
            dtpDatePicker.ValueChanged += dtpDatePicker_ValueChanged;
        }


        private void dtpDatePicker_ValueChanged(object sender, EventArgs e)
        {
            if (maskDatePickerValueChangedEvent != null)
            {
                Invoke(maskDatePickerValueChangedEvent, new object[] { sender, e });
            }
            if (ucTextBox != null)
            {
                ucTextBox.Text = dtpDatePicker.Value.ToShortDateString();
                ucTextBox.Height = dtpDatePicker.Height;
            }
        }
    }
}
