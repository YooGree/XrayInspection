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
    public partial class DBConnSettingPop : ParentsPop
    {
        public DBConnSettingPop()
        {
            InitializeComponent();
            mtxtPW.txtText.UseSystemPasswordChar = true;
            mtxtAdmin.txtText.UseSystemPasswordChar = true;
            SetEvent();
            GetData();
        }

        private void SetEvent()
        {
            btnSave.Click += BtnSave_Click;
            btnClose.Click += BtnClose_Click;
            mtxtAdmin.maskTextBoxKeyDownEvent += MtxtAdmin_maskTextBoxKeyDownEvent;
        }

        private void MtxtAdmin_maskTextBoxKeyDownEvent(object sender, EventArgs e)
        {
            KeyEventArgs ke = e as KeyEventArgs;
            if(ke.KeyCode.Equals(Keys.Enter))
            {
                if(mtxtAdmin.ucValue.Equals("SEM-M/M-DB"))
                {
                    mtxtAdmin.Visible = false;
                    pnlHide.Visible = false;
                }
                else
                {
                    mtxtAdmin.ucValue = string.Empty;
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void GetData()
        {
            string connStr = CommonFuction.GetAppSetting("DBConnectionString");
            Dictionary<string, string> connDic = new Dictionary<string, string>();
            List<string> arrConnStr = new List<string>();

            arrConnStr.AddRange(connStr.Split(';'));

            foreach(string x in arrConnStr)
            {
                string[] temp = x.Trim().Split('=');
                connDic.Add(temp[0], temp[1]);
            }

            string value = "";
            if (connDic.TryGetValue("Data Source", out value))
                mtxtIP.ucValue = value;
            if (connDic.TryGetValue("initial Catalog", out value))
                mtxtCatalog.ucValue = value;
            if (connDic.TryGetValue("user", out value))
                mtxtID.ucValue = value;
            if (connDic.TryGetValue("password", out value))
                mtxtPW.ucValue = value;

        }

        private void SaveData()
        {
            string ctrlname = "";
            bool chkMand = CommonFuction.CheckMandatory(groupBox1, ref ctrlname);

            if(!chkMand)
            {
                return;
            }

            StringBuilder sBuilder = new StringBuilder();

            sBuilder.Append("Data Source=");
            sBuilder.Append(mtxtIP.ucValue);
            sBuilder.Append("; initial Catalog=");
            sBuilder.Append(mtxtCatalog.ucValue);
            sBuilder.Append("; user=");
            sBuilder.Append(mtxtID.ucValue);
            sBuilder.Append("; password=");
            sBuilder.Append(mtxtPW.ucValue);

            CommonFuction.SetAppSetting("DBConnectionString", sBuilder.ToString());
        }

    }
}
