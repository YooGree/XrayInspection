/*
 *  파 일 명 : RackControl.cs
 *  작 성 자 : 김현욱
 *  설    명 : Main화면에서 Rack 현황을 보여주기 위한 컨트롤
 *  이    력 : 2019/04/29 김현욱 - 최초 작성
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskManager.UserControls
{
    public partial class RackControl : UserControl
    {

        public string RackName
        {
            get { return lblRackName.Text; }
            }
        public string MaskName
        {
            get { return lblMaskName.Text; }
        }

        private string state = "";

        public event EventHandler RackControlClick;
        public RackControl()
        {
            InitializeComponent();
            lblRackName.Click += RackControl_Click;
            lblMaskName.Click += RackControl_Click;
        }


        private void RackControl_Resize(object sender, EventArgs e)
        {
          //  splRack.SplitterDistance = (this.Size.Height - 4) / 2;
        }

        public void ChangeRackName(string name)
        {
            lblRackName.Text = name;
        }

        public void ChangeMaskName(string name)
        {
            lblMaskName.Text = name;
        }

        public bool ChangeRackState(string state)
        {
            try
            {
                switch (state)
                {
                    case "empty":
                        //splRack.Panel1.BackgroundImage = Properties.Resources.Rack_White;
                        pnlMain.BackgroundImage = Properties.Resources.Rack_White_new;
                        state = "empty";
                        break;
                    case "warning":
                        //splRack.Panel1.BackgroundImage = Properties.Resources.Rack_Red;
                        pnlMain.BackgroundImage = Properties.Resources.Rack_Red_New;
                        state = "warning";
                        break;
                    case "stock":
                        //splRack.Panel1.BackgroundImage = Properties.Resources.Rack_Green;
                        pnlMain.BackgroundImage = Properties.Resources.Rack_Green_New;
                        state = "stock";
                        break;
                    case "using":
                        //splRack.Panel1.BackgroundImage = Properties.Resources.Rack_Blue;
                        pnlMain.BackgroundImage = Properties.Resources.Rack_Blue_New;
                        state = "using";
                        break;
                    default:
                        MessageBox.Show("올바르지 않은 상태값입니다.");
                        return false;

                }
            }
            catch (Exception e)
            {
                LogFactory.Log(e);
                return false;
            }

            return true;
        }


        private void RackControl_Click(object sender, EventArgs e)
        {
            if (RackControlClick != null)
            {
                Invoke(RackControlClick, new object[] { this, e });
            }
        }

        public string GetState()
        {
            return state;
        }
    }
}
