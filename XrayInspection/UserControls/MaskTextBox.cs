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

namespace XrayInspection.UserControls
{
    public partial class MaskTextBox : UserControl, IMaskUserControl
    {
        #region Properties

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
            set
            {
                if (value)
                {
                    txtText.Multiline = true;
                    txtText.ScrollBars = ScrollBars.Vertical;
                    txtText.Size = new Size(txtText.Size.Width, 27);
                }
                else
                {
                    txtText.Multiline = false;
                    txtText.ScrollBars = ScrollBars.None;
                    txtText.Size = new Size(txtText.Size.Width, 27);
                }
            }
        }

        [Description("TextBox 정렬"), Category("Mask Manager Control Properties")]
        public HorizontalAlignment ucTextAlign
        {
            get { return txtText.TextAlign; }
            set { txtText.TextAlign = value; }
        }

        public bool ucMandatoryCheck
        {
            get
            {
                return CommonFuction.IsNullOrWhiteSpace(ucValue);
            }
        }

        #endregion

        #region Events

        [Description("TextBox Key Down 이벤트"), Category("Mask Manager Control Event")]
        public event EventHandler maskTextBoxKeyDownEvent;


        #endregion

        public MaskTextBox()
        {
            InitializeComponent();

            txtText.KeyDown += txtText_KeyDown;
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
