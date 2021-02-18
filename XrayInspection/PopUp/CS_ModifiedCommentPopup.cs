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
    /// 작   성   일  : 2021-02-16
    /// 설        명  : Xray 판독화면에서 비고를 수정하기 위해 호출되는 팝업이다.
    /// 이        력  : 2021-02-18 유태근 / 저장 클릭시 디비 업데이트가 아닌 화면상에서의 바인딩으로 변경
    /// </summary>
    public partial class CS_ModifiedCommentPopup : ParentsPop
    {
        #region 변수

        private DBManager _dbManager = new DBManager(); // DB 접속정보    
        public string _originalComment; // 원래 비고
        public string _currentComment; // 현재 비고
        private string _productCode; // 제품코드

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="procedure"></param>
        /// <param name="type"></param>
        /// <param name="parentCode"></param>
        public CS_ModifiedCommentPopup(string productCode, string comment)
        {
            InitializeComponent();
            InitializeControlSetting(productCode, comment);
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
            // 기존 비고와 변경사항이 없다면 알림
            if (_originalComment.Trim() == txtComment.Text.Trim())
            {
                MsgBoxHelper.Show("변경할 내용이 없습니다.");
                return;
            }
            else
            {
                if (MsgBoxHelper.Show("비고를 변경하시겠습니까?", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    _currentComment = txtComment.Text;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    
                    //try
                    //{
                    //    DBManager dbManager = new DBManager();

                    //    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    //    parameters.Add("@SITE", Properties.Settings.Default.Site);
                    //    parameters.Add("@PRODUCTCODE", _productCode);
                    //    parameters.Add("@CURRENTCOMMENT", txtComment.Text);

                    //    SqlParameter[] sqlPamaters = dbManager.GetSqlParameters(parameters);

                    //    int SaveResult = dbManager.CallNonSelectProcedure("USP_UPDATE_XRAYDECIPHER_COMMENT", sqlPamaters);

                    //    if (SaveResult > 0) Console.WriteLine("변경성공!");                      
                    //    else Console.WriteLine("변경실패!");

                    //    this.DialogResult = DialogResult.OK;
                    //    this.Close();
                    //}
                    //catch (Exception ex)
                    //{
                    //    MsgBoxHelper.Error(ex.Message);
                    //}
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
        private void InitializeControlSetting(string productCode, string comment)
        {
            // Footer 안보이게 처리
            Footer.Visible = false;

            // 팝업 최초 진입시 LOT NO 세팅
            txtComment.Text = comment;

            // 원래 LOT ID 세팅
            _originalComment = comment;

            // 도번 세팅
            _productCode = productCode;
        }

        #endregion
    }
}
