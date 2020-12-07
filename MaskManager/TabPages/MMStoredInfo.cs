using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskManager.TabPages
{
    /// <summary>
    /// 현재 Rack 위치와 Mask 상태를 보여주는 현황판
    /// </summary>
    public partial class MMStoredInfo : UserControl
    {
        private DataTable RackDesign = new DataTable();
        private DataTable RackList = new DataTable();
        private DBManager conn = new DBManager();
        private DataSet MainDataSet = new DataSet();

        private string ProcedureName = "GetMainStatusScreen";

        public MMStoredInfo()
        {
            InitializeComponent();
            tlpRack.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.SizeChanged += MMStoredInfo_SizeChanged;
        }

        private void MMStoredInfo_SizeChanged(object sender, EventArgs e)
        {
            if (MainDataSet.Tables.Count < 1) return;
            Initialization();
        }

        /// <summary>
        /// Rack과 Mask정보를 가져옴
        /// </summary>
        public void GetData()
        {
            MainDataSet = conn.CallSelectProcedure_ds(ProcedureName, new System.Data.SqlClient.SqlParameter[] { });
        }

        /// <summary>
        /// Table Layout View 초기화
        /// Rack의 배치 레이아웃에 맞춰 세팅해줌.
        /// </summary>
        public void Initialization()
        {
            try
            {
                if (MainDataSet != null)
                {
                    RackDesign = MainDataSet.Tables[0];
                    if (Program.MaxX.Equals(0) && !CommonFuction.IsNullOrWhiteSpace(RackDesign.Rows[0]["MAX_X"]))
                        Program.MaxX = (int)RackDesign.Rows[0]["MAX_X"];
                    if (Program.MaxY.Equals(0) && !CommonFuction.IsNullOrWhiteSpace(RackDesign.Rows[0]["MAX_Y"]))
                        Program.MaxY = (int)RackDesign.Rows[0]["MAX_Y"];

                }

                tlpRack.Hide();

                tlpRack.ColumnCount = Program.MaxX + 1;
                tlpRack.RowCount = Program.MaxY + 1;

                tlpRack.ColumnStyles.Clear();
                tlpRack.RowStyles.Clear();

                for (var i = 0; i < tlpRack.ColumnCount; i++)
                {
                    tlpRack.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, this.Size.Width / Program.MaxX));
                }

                for (var i = 0; i < tlpRack.RowCount; i++)
                {
                    tlpRack.RowStyles.Add(new RowStyle(SizeType.Absolute, this.Size.Height / Program.MaxY));
                }
                tlpRack.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 1));
                tlpRack.RowStyles.Add(new RowStyle(SizeType.Absolute, 1));

                tlpRack.Show();
            }
            catch(Exception ee)
            {
                LogFactory.Log(ee);
            }
        }

        /// <summary>
        /// 실제 Rack을 나타내는 컨트롤을 위치에 맞게 세팅해줌 
        /// </summary>
        public void DrawRacks()
        {
            if (MainDataSet != null)
            {
                RackList = MainDataSet.Tables[1];
            }

            tlpRack.Hide();
            try
            {
                tlpRack.Controls.Clear();

                foreach (DataRow x in RackList.Rows)
                {
                    UserControls.RackControl NewCtrl = new UserControls.RackControl();
                    NewCtrl.RackControlClick += NewCtrl_Click;
                    NewCtrl.ChangeRackName(x["EQUIPMENTID"] as string);
                    NewCtrl.Dock = DockStyle.Fill;
                    if (CommonFuction.IsNullOrWhiteSpace(x["DURABLEPRODUCTNAME"]))
                    {
                        x["DURABLEPRODUCTNAME"] = "";
                    }
                    NewCtrl.ChangeMaskName((string)x["DURABLEPRODUCTNAME"]);
                    tlpRack.Controls.Add(NewCtrl, (int)x["LOCATIONX"] - 1, (int)x["LOCATIONY"] - 1);

                    if (CommonFuction.IsNullOrWhiteSpace(x["DURABLEID"]))
                    {
                        NewCtrl.ChangeRackState("empty");
                    }
                    else if ((int)x["WARNINGUSEQTY"] <= (int)x["TOTUSEQTY"])
                    {
                        NewCtrl.ChangeRackState("warning");
                    }
                    else
                    {
                        if ((string)x["WORKSTATE"] == "WORKSTATE_USED" || (string)x["WORKSTATE"] == "WORKSTATE_USING")
                        {
                            NewCtrl.ChangeRackState("using");
                        }
                        else
                        {
                            NewCtrl.ChangeRackState("stock");
                        }
                    }
                }
            }
            catch(Exception e)
            {
                LogFactory.Log(e);
            }

            tlpRack.Show();
        }


        /// <summary>
        /// Rack 컨트롤을 클릭했을 때 발생하는 이벤트.
        /// MainFrm의 SetMaskDatas이벤트가 있는 경우 해당 이벤트를 호출함
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCtrl_Click(object sender, EventArgs e)
        {
            try
            {

                var obj = sender as UserControls.RackControl;

                var parentfrm = this.Parent;

                while (parentfrm.Parent != null && parentfrm.GetType().ToString() != "MaskManager.PopUp.MainFrm")
                {
                    parentfrm = parentfrm.Parent;
                }

                (parentfrm as MaskManager.PopUp.MainForm).SetMaskDatas(obj.RackName);

            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
            }
           //MessageBox.Show((parentfrm as MainFrm).SetMaskDatas(obj.RackName) + " -> " + obj.RackName);
        }
    }
}
