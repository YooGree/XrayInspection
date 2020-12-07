using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using MaskManager.UserControls;

namespace MaskManager.PopUp
{
    /// <summary>
    ///  * 파 일 명 : MMInspectPop.cs 					
    ///  * 작 성 자 : 황지희					
    ///  * 설     명 : Mask 세척 검사 후 보관 
    ///  * 이     력 : 2019-04-29 [황지희] : 신규추가	
    ///                2019-04-30 [황지희] : 기본팝업창 ParentsPop으로 상속 받도록 변경
    /// </summary>
    public partial class MMInspectPop : ParentsPop
    {
        DBManager DB = new DBManager();
        DataSet QueryListEqp;
        public MainForm resetRack;

        public MMInspectPop()
        {
            InitializeComponent();
            SetEvent();
            //2019-05-08 황지희 팝업 타이틀 추가
            Caption = "세척 검사";
        }

        private void MMInspectPop_Load(object sender, EventArgs e)
        {
            //db connect
            DB.Open();

            //SetComboBox();
            CommonFuction.SetInputResultList(ref cmb_InspResult); //세척 검사 결과
            this.cmb_InspResult.ucComboIndex = -1;

            //2019-05-15 황지희 설비 코드로 focus 되도록 변경
            ActiveControl = txt_EqpId;
        }
        /// <summary>
        /// * 함 수 명 : SetEvent					
        /// * 작 성 자 : 황지희		
        /// * 개 요 : 각 Event 정의 								
        /// </summary>
        private void SetEvent()
        {
           Load += MMInspectPop_Load;
           txt_MaskNum.txtText.KeyDown += Select_Mask_Info; //Mask 일련번호
           btn_Save.Click += SaveCleanResult; //저장
           btn_Add.Click += Btn_Add_Click; //신규추가
           btn_Close.Click += Btn_Close_Click;
            //2019-05-16 황지희 설비 ID 검색 추가 
            txt_EqpId.txtText.KeyDown += TxtText_KeyDown;
            txt_EqpId.txtText.KeyPress += TxtText_KeyPress;
            txt_MaskNum.txtText.KeyPress += TxtText_KeyPress;
            //2019-05-28 황지희 공통 함수에 있던 오류 부분 각 화면으로 다시 설정 
            this.txt_MaskNum.txtText.CharacterCasing = CharacterCasing.Upper;
            this.txt_EqpId.txtText.CharacterCasing = CharacterCasing.Upper;
            this.mcbmRack.cboCombo.SelectedIndexChanged += CboCombo_SelectedIndexChanged;
        }

        private void CboCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = mcbmRack.cboCombo.Text;
            mtxt_rack.ucValue = code;
        }

        /// <summary>
        /// 작성자 :황지희
        /// 설명 : 빈 보관함 리스트를 반환하는 함수 + 검색시 관련 일련번호 보관함 번호 추가 
        /// </summary>
        /// <returns>빈 보관함을 List<string> 형식으로 반환</returns>
        public List<String> GetEmptyEquipList_CleanInsp(String sMaskNum)
        {
            List<String> ComboData = new List<String>();
            var EmptyEquipList = DB.CallSelectProcedure(ProcedureName.JoinEquipAndDurable);

            for (int i = 0; i < EmptyEquipList.Count; i++)
            {
                if (EmptyEquipList[i][ColumnName.EQUIPMENTTYPE].ToString().Equals(ColumnName.EQUIPMENT_RACK) &&
                    string.IsNullOrWhiteSpace(EmptyEquipList[i][ColumnName.DURABLEID].ToString()))
                {
                    ComboData.Add(EmptyEquipList[i][ColumnName.EQUIPMENTID].ToString());
                }

                if (EmptyEquipList[i][ColumnName.DURABLEID].ToString().Equals(sMaskNum))
                {
                    ComboData.Add(EmptyEquipList[i][ColumnName.EQUIPMENTID].ToString());
                }
            }
            return ComboData;
        }
        /// <summary>
        /// * 함 수 명 : SetComboBox				
        /// * 작 성 자 : 황지희		
        /// * 개 요 : 적치대 변경 test
        /// </summary>
        ///
        List<String> RackList { get; set; }

        private void SetComboBox(string sMaskNum)
        {

            RackList = GetEmptyEquipList_CleanInsp(sMaskNum);

            if (RackList.Count > 0)
            {
                mcbmRack.ucComboBoxDataSource = RackList;
                mcbmRack.cboCombo.SelectedIndex = -1;
            }
            else
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "현재 비어있는 보관함이 없어 변경 할 수 없습니다.");
                return;
            }
        }
        /// <summary>
        /// * 함 수 명 : TxtText_KeyPress				
        /// * 작 성 자 : 황지희		
        /// * 개 요 : key 이벤트 영어(대문자), 숫자만 입력받도록 valid 체크 
        /// </summary>
        private void TxtText_KeyPress(object sender, KeyPressEventArgs e)
        {

            TextBox txt = (TextBox)sender;
            Control temp = txt.Parent;
            MaskTextBox mtb = null;

            while (temp.Parent != null)
            {
                if (temp is MaskTextBox)
                {
                    mtb = temp as MaskTextBox;
                    break;
                }
                temp = temp.Parent;
            }
            if (mtb == null) return;

            switch (mtb.Name)
            {
                case "txt_MaskNum":
                case "txt_EqpId":
                    CommonFuction.TypingOnlyEngNum(sender, e, mtb);
                    break;
            }
        }


        private void TxtText_KeyDown(object sender, KeyEventArgs e)
        {
            string sEqpId = (sender as TextBox).Text.ToString();

            if (e.KeyCode == Keys.Enter)
            {
            
                if (CommonFuction.IsNullOrWhiteSpace(txt_EqpId))
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", txt_EqpId.ucLabelText + "를 입력하세요.");
                    txt_EqpId.txtText.Focus();
                }
                else
                { 
                    List<SqlParameter> Params = new List<SqlParameter>();
                    Params.Add(new SqlParameter("@eqp_id", sEqpId));
                    Params.Add(new SqlParameter("@equipmenttype", "EQUIPMENT_INSP"));

                    QueryListEqp = null;
                    QueryListEqp = DB.CallSelectProcedure_ds("[SelectEqpId]", Params);

                    if (QueryListEqp.Tables[0].Rows.Count != 0)
                    {
                        DataRow row = QueryListEqp.Tables[0].Rows[0];
                        this.txt_EqpId.ucValue = row["EQUIPMENTID"].ToString();
                        this.txt_EqpName.ucValue = row["EQUIPMENTNAME"].ToString();

                        txt_MaskNum.Focus();
                    }
                    else
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", txt_EqpId.ucLabelText + "가 없습니다.");
                        txt_EqpId.txtText.SelectAll();
                        return;
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Keys key = keyData & ~(Keys.Shift | Keys.Control);

            switch (key)
            {
                case Keys.F2:
                    Btn_Add_Click();
                    return true;
                case Keys.F3:
                    SaveCleanResult();
                    break;
                case Keys.F4:
                    this.Close();
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// * 함 수 명 : InitReset				
        /// * 작 성 자 : 황지희		
        /// * 개 요 : 각 컴포넌트 초기화 함수	
        /// </summary>
        private void InitReset()
        {
            this.txt_MaskNum.txtText.ResetText(); //Mask 일련번호
            this.txt_MaskProd.txtText.ResetText(); //모델코드
            this.cmb_InspResult.ucComboIndex = -1; //세척검사결과
            this.txt_TotUse.txtText.ResetText();  //누적사용횟수
            this.txt_UseQty.txtText.ResetText(); //사용 횟수
            this.txt_Rack.txtText.ResetText();  //보관함 위치
            this.txt_MaskProdName.txtText.ResetText();  //모델명
            this.txt_Date.txtText.ResetText();  //사양 정보
            this.txt_Comment.txtText.ResetText();  //특이사항
            this.txt_MaskProdInfo.txtText.ResetText(); //Mask 사양정보
            this.txt_EqpId.txtText.ResetText(); //설비코드
            this.txt_EqpName.txtText.ResetText(); //설비명
            this.mcbmRack.cboCombo.SelectedIndex = -1; //적치대
            this.mtxt_rack.txtText.ResetText();
        }

        /// <summary>
        /// * 함 수 명 : ResetInit					
        /// * 작 성 자 : 황지희		
        /// * 개 요 : 초기화버튼 event								
        /// </summary>
        private void Btn_Add_Click(object sender, EventArgs e)
        {
            Btn_Add_Click();
        }
        private void Btn_Add_Click()
        {
            string ctrlname = "";
            if (CommonFuction.CheckMandatory(MaskCleanPanel, ref ctrlname))
            {
                if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "신규", "신규 생성 하시겠습니까?") == DialogResult.OK)
                {
                    InitReset();
                }
            }
            else
            {
                InitReset();
            }
        }
        /// <summary>
        /// * 함 수 명 : Select_Mask_Info				
        /// * 작 성 자 : 황지희		
        /// * 개 요 : 마스크 일련번호 바코드 스캐닝 후 정보 출력 								
        /// </summary>
        private void Select_Mask_Info(object sender, KeyEventArgs e)
        {
            string sMaskNum = (sender as TextBox).Text.ToString();
            if (e.KeyCode == Keys.Enter) {
                if (CommonFuction.IsNullOrWhiteSpace(sMaskNum)) {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "Mask 일련번호를 입력하세요.");
                    return;
                } else {

                    List<SqlParameter> Params = new List<SqlParameter>();
                    Params.Add(new SqlParameter("@durable_id", sMaskNum));

                    DataSet QueryList = DB.CallSelectProcedure_ds("selectMaskCleanInfo", Params);
                    int iTot_Use_Qty , iUse_Qty = 0;
                    if (QueryList.Tables[0].Rows.Count != 0) {
                        DataRow row = QueryList.Tables[0].Rows[0];

                        // 2019-05-08 황지희 WORKSTATE상태가 RUN일 경우만 조회가능 
                        if (row["STATE"].Equals("STATE_ACTIVE") && row["WORKSTATE"].Equals("WORKSTATE_USED"))
                        {
                            SetComboBox(sMaskNum);
                            this.txt_MaskNum.ucValue = row["DURABLEID"].ToString();
                            this.txt_MaskProd.ucValue = row["DURABLEPRODUCTID"].ToString();
                            this.txt_MaskProdName.ucValue = row["DURABLEPRODUCTNAME"].ToString();
                            int.TryParse(row["TOTUSEQTY"].ToString(), out iTot_Use_Qty);
                            int.TryParse(row["USEQTY"].ToString(), out iUse_Qty);
                            this.txt_TotUse.ucValue = iTot_Use_Qty.ToString(); //누적사용횟수
                            this.txt_UseQty.ucValue = iUse_Qty.ToString();     //사용횟수
                            if (row["RACKID"].ToString() != null) this.txt_Rack.txtText.Text = row["RACKID"].ToString();
                            this.txt_Comment.ucValue = row["COMMENT"].ToString();
                            this.txt_Date.ucValue = row["USEDATE"].ToString();
                            //2019-05-16 Mask 사양정보 추가 
                            this.txt_MaskProdInfo.ucValue = row["DESCRIPTION"].ToString();
                            //2019-08-23 적치대 추가
                            //this.mcbmRack.ucText = row["RACKID"].ToString();
                            this.mtxt_rack.ucValue = row["RACKID"].ToString();
                            this.cmb_InspResult.Focus();

                        }
                        else if (row["STATE"].ToString().Equals("STATE_SCRAPPED"))
                        {
                            CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "폐기상태입니다.");
                            txt_MaskNum.txtText.SelectAll();
                            return;
                        }
                        else if (row["STATE"].ToString().Equals("STATE_TERMINATED"))
                        {
                            CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "해당 일련번호는 종료상태입니다.");
                            txt_MaskNum.txtText.SelectAll();
                            return;
                        } else {
                            CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "생산정보 먼저 입력하세요.");
                            txt_MaskNum.txtText.SelectAll();
                            return;
                        }

                    } else {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", "해당 Mask 일련번호가 없습니다.");
                        InitReset();
                        txt_MaskNum.Focus();
                        return;
                    }
                } 
            }//end if (key code) 
        }

        /// <summary>
        /// * 함 수 명 : SaveCleanResult				
        /// * 작 성 자 : 황지희		
        /// * 개 요 : 세척검사 결과 저장
        /// </summary>
        private void SaveCleanResult(object sender, EventArgs e)
        {
            SaveCleanResult();
        }

        private void SaveCleanResult()
        {
            //2019-04-30 필수 입력값 확인
            string ctrlname = "";
            if (CommonFuction.CheckMandatory(grbox_1, ref ctrlname) == false)
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "ERROR", $"{ctrlname} 항목을 확인해주세요.");
                return;
            }

            if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "확인", "저장하시겠습니까?") == DialogResult.OK)
            {

                Dictionary<string, object> Params = new Dictionary<string, object>();
                Params.Add("@durableid", this.txt_MaskNum.ucValue);  //Mask 일련번호
                Params.Add("@durableproductid", this.txt_MaskProd.ucValue); //모델명
                Params.Add("@cleanresult", this.cmb_InspResult.ucValue);
                //Params.Add("@cleandate", DateTime.Now);           //최근사용일자
                Params.Add("@comment", this.txt_MaskProdName.ucValue);     //사양 정보
                Params.Add("@modifier", Program.CurrentUser);              //수정자
                Params.Add("@workstate", "WORKSTATE_WAIT");                //작업 상태
                //2019-08-23 적치대 콤보 추가
                Params.Add("@Rackid", this.mtxt_rack.ucValue);
                var PamasArr = DB.GetSqlParameters(Params);

                int SaveResult = DB.CallNonSelectProcedure("SaveCleanInsp", PamasArr);

                if (SaveResult > 0)
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "SAVE", "저장하였습니다.");
                    InitReset();
                    //2019-05-08 저장후 Mask 일련번호로 포커싱 추가
                    txt_MaskNum.Focus();
                    resetRack.ResetRackStatus(true);
                }
            }
        }
    }
}

