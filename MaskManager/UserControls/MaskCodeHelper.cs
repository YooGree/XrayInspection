/*
 *  파 일 명 : MaskTextBox.cs
 *  작 성 자 : 김현욱
 *  설    명 : Label과 TextBox를 합친 UserControl
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
using MaskManager.PopUp;

namespace MaskManager.UserControls
{
    public partial class MaskCodeHelper : UserControl
    {
        #region Properties
        public enum HelperType
        {
            VENDER = 0,
            EQUIPMENT = 1,
            USER = 2,
            LOGIN = 3,
            NONE = 4
        }
        private HelperType Type = HelperType.NONE;

        [Description("Label Text"), Category("Mask Manager Control Properties")]
        public string ucLabelText
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        [Description("TextBox Text"), Category("Mask Manager Control Properties")]
        public string ucValue
        {
            get { return txtText.Text; }
            set { txtText.Text = value; }
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

        [Description("TextBox ReadOnly"), Category("Mask Manager Control Properties")]
        public bool ucTextReadOnly
        {
            get { return txtText.ReadOnly; }
            set { txtText.ReadOnly = value; }
        }

        [Description("TextBox as TextArea"), Category("Mask Manager Control Properties")]
        public bool ucTextArea
        {
            get
            {
                return txtText.Multiline;
            }
        }

        [Description("TextBox as TextArea"), Category("Mask Manager Control Properties")]
        public HelperType ucHelperType
        {
            get
            {
                return Type;
            }
            set
            {
                Type = value;
            }
        }

        [Description("TextBox Align"), Category("Mask Manager Control Properties")]
        public HorizontalAlignment ucTextAlign
        {
            get { return txtText.TextAlign; }
            set { txtText.TextAlign = value; }
        }

        [Description("CodeHelper Readonly"), Category("Mask Manager Control Properties")]
        public bool ucReadOnly
        {
            get;
            set;
        }

        #endregion

        #region Events

        [Description("TextBox Key Down 이벤트"), Category("Mask Manager Control Event")]
        public event EventHandler maskTextBoxKeyDownEvent;

        #endregion

        public MaskCodeHelper()
        {
            InitializeComponent();
            SetEvent();
            ucReadOnly = false;
        }

        private void SetEvent()
        {
            btnHelper.Click += BtnHelper_Click;
        }


        private void BtnHelper_Click(object sender, EventArgs e)
        {
            string HelperType = "" ;
            if (ucReadOnly) return;
            switch ((int)Type)
            {
                case 0:
                    HelperType = "VENDER";
                    break;
                case 1:
                    HelperType = "EQUIP";
                    break;
                case 2:
                    HelperType = "USER";
                    break;
                case 3:
                    HelperType = "LOGIN";
                    break;
                case 4:
                default:
                    return;
            }
            MMCodeHelper Helper = new MMCodeHelper(HelperType);
            Helper.ShowDialog();
            ucValue = Helper.ReturnCodeValue;
        }

        private void txtText_KeyDown(object sender, EventArgs e)
        {
            if (maskTextBoxKeyDownEvent != null)
            {
                
                Invoke(maskTextBoxKeyDownEvent, new object[] { sender, e });
            }
        }
    }
}
