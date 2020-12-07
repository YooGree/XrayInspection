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
    /// 작성자 : 윤보미
    /// 설명 : 기본 팝업창 ParentsPop으로 상속 받아 사용할 수 있도록 변경
    /// 함수목록 : 
    /// 프로시저 : 
    /// 이력 : 2019-04-30 [윤보미] : 신규작성
    /// </summary>
    public partial class ParentsPop : Form
    {
        public string Caption
        {
            get { return lblTitle.Text; }
            set
            {
                lblTitle.Text = value;
            }
        }
        private Point mousePoint;

        public ParentsPop()
        {
            this.WindowState = FormWindowState.Normal;
            InitializeComponent();
            lblTitle.MouseMove += ParentsPop_MouseMove;
            lblTitle.MouseDown += ParentsPop_MouseDown;
            lblTitle.MouseDoubleClick += LblTitle_MouseDoubleClick;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        /// <summary>
        /// 2019-05-24 황지희 폼 사이즈 변경 추가 
        /// </summary>
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            //e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }

        private void LblTitle_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void ParentsPop_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void ParentsPop_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X),
                    this.Top - (mousePoint.Y - e.Y));
            }
        }
    }
}
