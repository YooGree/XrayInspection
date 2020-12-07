/*
 *  파 일 명 : MaskComboBox.cs
 *  작 성 자 : 김현욱
 *  설    명 : Label과 ComboBox를 합친 UserControl
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

namespace MaskManager.UserControls
{
    public partial class MaskComboBox : UserControl, IMaskUserControl
    {
        #region properties

        [Description("Label Text"), Category("Mask Manager Control Properties")]
        public string ucLabelText
        {
            get { return lblText.Text; }
            set { lblText.Text = value; }
        }

        [Description("ComboBox Value"), Category("Mask Manager Control Properties")]
        public object ucValue
        {
            get { return cboCombo.SelectedValue; }
            set { cboCombo.SelectedValue = value; }
        }

        [Description("ComboBox Text"), Category("Mask Manager Control Properties")]
        public string ucText
        {
            get { return cboCombo.Text; }
            set { cboCombo.Text = value; }
        }

        [Description("ComboBox Data Source"), Category("Mask Manager Control Properties")]
        public object ucComboBoxDataSource
        {
            get { return cboCombo.DataSource; }
            set { cboCombo.DataSource = value; }
        }

        [Description("ComboBox Display Member"), Category("Mask Manager Control Properties")]
        public string ucComboBoxDisplayMember
        {
            get { return cboCombo.DisplayMember; }
            set { cboCombo.DisplayMember = value; }
        }

        [Description("ComboBox Value Member"), Category("Mask Manager Control Properties")]
        public string ucComboBoxValueMember
        {
            get { return cboCombo.ValueMember; }
            set { cboCombo.ValueMember = value; }
        }
        [Description("ComboBox Drop Down Style"), Category("Mask Manager Control Properties")]
        public ComboBoxStyle ucComboBoxDropDownStyle
        {
            get { return cboCombo.DropDownStyle; }
            set { cboCombo.DropDownStyle = value; }
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

        [Description("ComboBox Enabled"), Category("Mask Manager Control Properties")]
        public bool ucComboEnabled
        {
            get { return cboCombo.Enabled; }
            set { cboCombo.Enabled = value; }
        }

        [Description("ComboBox Index"), Category("Mask Manager Control Properties")]
        public int ucComboIndex
        {
            get { return cboCombo.SelectedIndex; }
            set { cboCombo.SelectedIndex = value; }
        }


        /// <summary>
        /// 입력이 안 되어있으면 true, 입력이 되어있으면 false 
        /// </summary>
        public bool ucMandatoryCheck
        {
            get
            {
                return CommonFuction.IsNullOrWhiteSpace(ucValue);
            }
        }
        /// <summary>
        /// ReadOnly
        /// </summary>
        public bool ucReadOnly
        {
            get
            {
                return txtReadOnly.Visible;
            }
            set
            {
                txtReadOnly.Visible = value;
                cboCombo.Visible = !value;
            }
        }

        #endregion

        #region Event

        [Description("TextBox Key Down 이벤트"), Category("Mask Manager Control Event")]
        public event EventHandler maskComboBoxValueChangedEvent;

        #endregion

        public MaskComboBox()
        {
            InitializeComponent();
            cboCombo.SelectedIndexChanged += cboCombo_SelectedIndexChanged;
        }

        private void cboCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtReadOnly.Text = cboCombo.Text;
            if (maskComboBoxValueChangedEvent != null)
            {
                try
                {
                    Invoke(maskComboBoxValueChangedEvent, new object[] { sender, e });
                }
                catch(Exception ee)
                {
                    LogFactory.Log(ee);
                }
            }
        }
    }
}
