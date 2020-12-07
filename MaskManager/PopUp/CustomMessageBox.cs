using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskManager.PopUp
{
    /// <summary>
    /// 디자인을 적용한 MessageBox
    /// ex) DialogResult bb = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "확인", "저장하시겠습니까?");
    ///     DialogResult aa = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "저장되었습니다.");
    /// </summary>
    public partial class CustomMessageBox : ParentsPop
    {
        static CustomMessageBox _messageBox;
        public CustomMessageBox(MessageBoxButtons buttons, string Caption, String Contents)
        {
            InitializeComponent();

            this.Caption = Caption;
            label1.Text = Contents;
            label1.TextAlign = ContentAlignment.MiddleLeft;

            if (buttons == MessageBoxButtons.OK)
            {
                btnClose.Visible = true;
                panel1.Visible = false;
                panel2.BackgroundImage = System.Drawing.SystemIcons.Information.ToBitmap();

            }
            else
            {
                btnClose.Visible = false;
                panel1.Visible = true;
                panel2.BackgroundImage = System.Drawing.SystemIcons.Question.ToBitmap();

            }
        }
        public static DialogResult Show(MessageBoxButtons buttons, string Caption, String Contents)
        {
            _messageBox = new CustomMessageBox(buttons, Caption, Contents);
            return _messageBox.ShowDialog();
        }
    }
}
