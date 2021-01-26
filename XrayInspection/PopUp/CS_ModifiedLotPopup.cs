using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrayInspection.UserControls;

namespace XrayInspection.PopUp
{
    /// <summary>
    /// 작   성   자  : 유태근
    /// 작   성   일  : 2021-01-26
    /// 설        명  : Xray 판독화면에서 LOT NO를 수정하기 위해 호출되는 팝업이다.
    /// 이        력  : 
    /// </summary>
    public partial class CS_ModifiedLotPopup : ParentsPop
    {
        #region 변수

        private DBManager _dbManager = new DBManager(); // DB 접속정보    
        public string _originalLotId; // 원래 LOT ID
        public string _currentLotId; // 현재 LOT ID

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="type"></param>
        /// <param name="parentCode"></param>
        public CS_ModifiedLotPopup(string originalLotId)
        {
            InitializeComponent();
            InitializeControlSetting(originalLotId);
            InitializeEvent();
        }

        #endregion

        #region 이벤트

        /// <summary>
        /// 이벤트 등록
        /// </summary>
        private void InitializeEvent()
        {
            btnSave.Click += BtnSave_Click;
            btnClose.Click += BtnClose_Click;
        }

        /// <summary>
        /// 닫기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 기존 LOT ID와 변경사항이 없다면 알림
            if (_originalLotId.Trim() == txtLotNo.Text.Trim())
            {
                MsgBoxHelper.Show("변경할 내용이 없습니다.");
                return;
            }
            else
            {
                if (MsgBoxHelper.Show("LOT NO를 변경하시겠습니까?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    try
                    {
                        DBManager dbManager = new DBManager();

                        Dictionary<string, object> parameters = new Dictionary<string, object>();
                        parameters.Add("@SITE", Properties.Settings.Default.Site);
                        parameters.Add("@ORIGINALLOTNO", _originalLotId);
                        parameters.Add("@CURRENTLOTNO", txtLotNo.Text);

                        SqlParameter[] sqlPamaters = dbManager.GetSqlParameters(parameters);

                        int SaveResult = dbManager.CallNonSelectProcedure("USP_UPDATE_XRAYDECIPHER_LOTNO", sqlPamaters);

                        if (SaveResult > 0) MsgBoxHelper.Show("변경하였습니다.");                      
                        else MsgBoxHelper.Show("변경에 실패하였습니다");

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MsgBoxHelper.Error(ex.Message);
                    }
                }
            }
        }

        #endregion

        #region 사용자 정의 함수

        /// <summary>
        /// 컨트롤 라벨세팅
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="type"></param>
        private void InitializeControlSetting(string originalLotId)
        {
            // Footer 안보이게 처리
            Footer.Visible = false;

            // 팝업 최초 진입시 LOT NO 세팅
            txtLotNo.Text = originalLotId;

            // 원래 LOT ID 세팅
            _originalLotId = originalLotId;
        }

        #endregion
    }
}
