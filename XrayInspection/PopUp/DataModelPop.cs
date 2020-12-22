using XrayInspection.TabPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XrayInspection.PopUp
{
    public partial class DataModelPop : ParentsPop
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);

            switch (key)
            {
                case Keys.F4:
                    this.Close();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        SelectedTabType selectedTabType
        {
            set
            {
                foreach (Button btn in btnList)
                {
                    btn.Font = CommonFuction.RegularFont;
                }

                if (value == SelectedTabType.User)
                {
                    userTabPageControl.BringToFront();
                    btnUser.Font = CommonFuction.BoldFont;
                }
                else if (value == SelectedTabType.Vender)
                {
                    venderTabPageControl.BringToFront();
                    btnVender.Font = CommonFuction.BoldFont;
                }
                else if (value == SelectedTabType.DurableProd)
                {
                    durableProdTabPageControl.BringToFront();
                    btnModel.Font = CommonFuction.BoldFont;
                }
                else if (value == SelectedTabType.Equipment)
                {
                    equipmentTabPageControl.BringToFront();
                    btnEquip.Font = CommonFuction.BoldFont;
                }
                else
                {
                    rackTabControl.BringToFront();
                    btnRack.Font = CommonFuction.BoldFont;
                }
            }
        }
        List<Button> btnList;
        UserTabPageControl userTabPageControl;
        DurableProdTabPageControl durableProdTabPageControl;
        EquipmentTabPageControl equipmentTabPageControl;
        VenderTabPageControl venderTabPageControl;
        RackTabControl rackTabControl;

        public DataModelPop(SelectedTabType type)
        {
            InitializeComponent();
            Caption = "기준정보";

            btnList = new List<Button>() { btnVender, btnEquip, btnUser, btnRack, btnModel };

            userTabPageControl = new UserTabPageControl();
            durableProdTabPageControl = new DurableProdTabPageControl();
            equipmentTabPageControl = new EquipmentTabPageControl();
            venderTabPageControl = new VenderTabPageControl();
            rackTabControl = new RackTabControl();

            MainPanel.Controls.Add(userTabPageControl);
            MainPanel.Controls.Add(durableProdTabPageControl);
            MainPanel.Controls.Add(equipmentTabPageControl);
            MainPanel.Controls.Add(venderTabPageControl);
            MainPanel.Controls.Add(rackTabControl);

            btnUser.Tag = SelectedTabType.User;
            btnVender.Tag = SelectedTabType.Vender;
            btnModel.Tag = SelectedTabType.DurableProd;
            btnEquip.Tag = SelectedTabType.Equipment;
            btnRack.Tag = SelectedTabType.Rack;

            btnUser.Click += Button_Click;
            btnVender.Click += Button_Click;
            btnModel.Click += Button_Click;
            btnEquip.Click += Button_Click;
            btnRack.Click += Button_Click;
            btnClose.Click += btnClose_Click;

            this.selectedTabType = type;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var tag = ((Button)sender).Tag;
            this.selectedTabType = tag is SelectedTabType ? (SelectedTabType)tag : SelectedTabType.User;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public enum SelectedTabType
    {
        User,
        Vender,
        DurableProd,
        Equipment,
        Rack
    }
}
