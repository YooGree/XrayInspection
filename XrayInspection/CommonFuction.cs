using XrayInspection.DataModel;
using XrayInspection.UserControls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XrayInspection
{

    public class CommonFuction
    {
        public static Font RegularFont
        {
            get
            {
                return new System.Drawing.Font("맑은 고딕", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(129)));
            }
        }

        public static Font BoldFont
        {
            get
            {
                return new System.Drawing.Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(129)));
            }
        }
        public static object DB { get; private set; }
        static DBManager _dbManager;
        public static DBManager dbManager
        {
            get
            {
                if (_dbManager == null)
                    _dbManager = new DBManager();
                return _dbManager;
            }
        }

        /// <summary>
        /// object의 널이나 공백문자 여부를 체크하는 함수
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(object obj)
        {
            string str = null;
            if (obj != null) str = obj.ToString().Trim();
            if (str == null || str == "")
            {
                return true;

            }

            return false;
        }

        /// <summary>
        /// 작성자 : 윤보미
        /// 설명 : User ID 로 User Name 반환
        /// </summary>
        /// <param name="_userId"></param>
        /// <returns></returns>
        public static string GetUserName(string _userId)
        {
            if (string.IsNullOrWhiteSpace(_userId) == true)
                return "";

            List<SqlParameter> Params = new List<SqlParameter>();
            Params.Add(new SqlParameter("@USERID", _userId));

            var selUser = dbManager.CallSingleSelectProcedure(ProcedureName.SelecteUserName, Params);

            if (selUser == null)
                return "";

            return selUser[ColumnName.USERNAME] is String ? selUser[ColumnName.USERNAME].ToString() : "";
        }

        /// <summary>
        /// 필수항목 입력여부 체크하는 함수
        /// 이력 : 2019.05.09 윤보미 수정
        /// </summary>
        /// <param name="ctrl"> 현재 유저컨트롤들이 들어있는 Panel이나 GroupBox</param>
        /// <param name="ctrlname"> 비어있는 유저컨트롤의 Label Text가 들어갈 변수(call by reference)</param>
        /// <returns></returns>
        public static bool CheckMandatory(System.Windows.Forms.Control ctrl, ref string ctrlname)
        {
            //ctrlname = "";
            //foreach (var x in ctrl.Controls)
            //{
            //    if (x.GetType() == typeof(UserControls.MaskComboBox))
            //    {
            //        if ((x as UserControls.MaskComboBox).ucMandatory)
            //        {
            //            if (IsNullOrWhiteSpace((x as UserControls.MaskComboBox).ucValue))
            //            {
            //                ctrlname = (x as UserControls.MaskComboBox).ucLabelText;
            //                return false;
            //            }
            //        }
            //    }
            //    if (x.GetType() == typeof(UserControls.MaskDatePicker))
            //    {
            //        if ((x as UserControls.MaskDatePicker).ucMandatory)
            //        {
            //            if (IsNullOrWhiteSpace((x as UserControls.MaskDatePicker).ucValue))
            //            {
            //                ctrlname = (x as UserControls.MaskDatePicker).ucLabelText;
            //                return false;
            //            }
            //        }
            //    }
            //    if (x.GetType() == typeof(UserControls.MaskTextBox))
            //    {
            //        if ((x as UserControls.MaskTextBox).ucMandatory)
            //        {
            //            if (IsNullOrWhiteSpace((x as UserControls.MaskTextBox).ucValue))
            //            {
            //                ctrlname = (x as UserControls.MaskTextBox).ucLabelText;
            //                return false;
            //            }
            //        }
            //    }
            //}
            //return true;

            ctrlname = "";
            foreach (var x in ctrl.Controls)
            {
                if( (x is IMaskUserControl) &&
                    ((IMaskUserControl)x).ucMandatory == true &&
                     ((IMaskUserControl)x).ucMandatoryCheck == true )
                {
                    ctrlname = ((IMaskUserControl)x).ucLabelText;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Data Grid View의 컬럼을 생성하는 함수
        /// </summary>
        /// <param name="obj">대상 DataGridView</param>
        /// <param name="HText">헤더 Text</param>
        /// <param name="dataColumn">data Column명</param>
        /// <param name="name">Column명</param>
        /// <param name="vType">데이터 타입</param>
        /// <param name="ronly">읽기전용 (기본값 false)</param>
        /// <param name="visible">컬럼 visible 여부 (기본값 true)</param>
        public static void SetDataGridViewColumnStyle(DataGridView obj, string HText, string dataColumn, string name, Type vType, int width = -1, bool ronly = false, bool visible = true, DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleCenter, float weight = -1)
        {
            DataGridViewColumn Column = new DataGridViewColumn();
            DataGridViewCell Cell = new DataGridViewTextBoxCell();
            DataGridViewCellStyle Style = new DataGridViewCellStyle();
            Style.Alignment = align;

            Column.HeaderText = HText;
            Column.DataPropertyName = dataColumn;
            Column.Name = name;
            Column.ReadOnly = ronly;
            Column.ValueType = vType;
            Column.Visible = visible;
            Cell.Style = Style;
            if (weight > -1)
            {
                Column.FillWeight = weight;
            }
            Column.CellTemplate = Cell;
            if (width > -1)
            {
                Column.Width = width;
            }
            obj.Columns.Add(Column);

        }

        /// <summary>
        /// combo 공통 함수 
        /// </summary>
        /// <param name="CodeClassId">콤보 쿼리 수행되는 변수 조건값 ex) 사용콤보(USEYN), 검사결과 (RESULT), 적치대 (RACK) 등</param>
        /// <returns></returns>
        public static List<ComboCodeModel> GetComboCodeList(string CodeClassId)
        {
            List<ComboCodeModel> ComboData = new List<ComboCodeModel>();
            List<SqlParameter> Params = new List<SqlParameter>();
            Params.Add(new SqlParameter("@codeclassid", CodeClassId));

            try
            {
                var InputResultDic = dbManager.CallSelectProcedure("selectCode", Params);

                if (InputResultDic.Count > 0)
                {
                    ComboCodeModel codeModel = new ComboCodeModel();
                    for (int i = 0; i < InputResultDic.Count; i++)
                    {
                        codeModel = new ComboCodeModel();
                        codeModel.CODEID = InputResultDic[i]["CODEID"].ToString();
                        codeModel.CODENAME = InputResultDic[i]["CODENAME"].ToString();
                        ComboData.Add(codeModel);
                    }
                }
            }
            catch (Exception ee)
            {
                LogFactory.Log(ee);
            }

            return ComboData;
        }

        /// <summary>
        /// 작성자 : 윤보미
        /// 설명 : 세척결과 콤보 리스트 반환
        /// </summary>
        /// <returns></returns>
        public static List<ComboCodeModel> GetInputResultList()
        {
            return GetComboCodeList("RESULT");
        }

        /// <summary>
        /// 작성자 : 윤보미
        /// 설명 : SelecteDurableIDdesc 프로시저를 사용해 현재 Durable 테이블에서 가장 큰 ID + 1 반환
        /// </summary>
        /// <returns></returns>
        public static string DurableIdCreator()
        {
            var lastDurableId = dbManager.CallSelectProcedure(ProcedureName.SelecteDurableIDdesc).FirstOrDefault();
            int lastID = 0;

            if (lastDurableId == null)
                lastID = 1;
            else
            {
                int.TryParse(lastDurableId.Values.First().ToString(), out lastID);
                lastID = lastID + 1;
            }

            return lastID.ToString(Properties.Settings.Default.DgitNumber); //string.Format("{0:D4}",lastID);
        }

        /// <summary>
        /// 작성자 : 윤보미
        /// 설명 : 사용여부 콤보리스트 반환
        /// </summary>
        /// <returns></returns>
        static List<ComboCodeModel> GetUseYNList()
        {
            return GetComboCodeList("USEYN");
        }

        /// <summary>
        /// 작성자 : 윤보미
        /// 설명 : 설비유형 콤보리스트 반환
        /// </summary>
        /// <returns></returns>
        static List<ComboCodeModel> GetEqpTypeList()
        {
            List<ComboCodeModel> code = GetComboCodeList("EQUIPMENT");

            ComboCodeModel rack = code.Find(x => x.CODEID.Equals("EQUIPMENT_RACK"));

            if(!IsNullOrWhiteSpace(rack))
            {
                code.Remove(rack);
            }

            return code;


        }


        public static void SetInputResultList(ref MaskComboBox combo)
        {
            combo.ucComboBoxDataSource = GetInputResultList();
            combo.ucComboBoxDisplayMember = "CODENAME";
            combo.ucComboBoxValueMember = "CODEID";
        }

        public static void SetUseYNList(ref MaskComboBox combo)
        {
            combo.ucComboBoxDataSource = GetUseYNList();
            combo.ucComboBoxDisplayMember = "CODENAME";
            combo.ucComboBoxValueMember = "CODEID";
        }
        public static void SetEqpTypeList(ref MaskComboBox combo)
        {
            combo.ucComboBoxDataSource = GetEqpTypeList();
            combo.ucComboBoxDisplayMember = "CODENAME";
            combo.ucComboBoxValueMember = "CODEID";
        }

        /// <summary>
        /// 작성자 : 윤보미
        /// 설명 : InputResult Table의 CodeID를 입력해서 CodeName 반환
        /// </summary>
        /// <param name="codeID"></param>
        /// <returns></returns>
        public static string GetInputResultName(String codeID)
        {
            List<ComboCodeModel> List = GetInputResultList();
            try
            {
                var InputResult = List.SingleOrDefault(x => x.CODEID.Equals(codeID));
                return InputResult == null ? "" : InputResult.CODENAME;
            }
            catch (Exception e)
            {
                LogFactory.Log(e);
                return "";
            }
        }

        /// <summary>
        /// 작성자 : 윤보미
        /// 설명 : UseYN Table의 CodeID를 입력해서 CodeName 반환
        /// </summary>
        /// <param name="codeID"></param>
        /// <returns></returns>
        public static string GetUseYNName(String codeID)
        {
            List<ComboCodeModel> List = GetUseYNList();
            try
            {
                return List.SingleOrDefault(x => x.CODEID.Equals(codeID)).CODENAME;
            }
            catch (Exception e)
            {
                LogFactory.Log(e);
                return "";
            }
        }


        /// <summary>
        /// 작성자 : 윤보미
        /// 설명 : 빈 보관함 리스트를 반환하는 함수
        /// </summary>
        /// <returns>빈 보관함을 List<string> 형식으로 반환</returns>
        public static List<String> GetEmptyEquipList()
        {
            List<String> ComboData = new List<String>();
            var EmptyEquipList = dbManager.CallSelectProcedure(ProcedureName.JoinEquipAndDurable);

            for (int i = 0; i < EmptyEquipList.Count; i++)
            {
                if (EmptyEquipList[i][ColumnName.EQUIPMENTTYPE].ToString().Equals(ColumnName.EQUIPMENT_RACK) &&
                    string.IsNullOrWhiteSpace(EmptyEquipList[i][ColumnName.DURABLEID].ToString()))
                    ComboData.Add(EmptyEquipList[i][ColumnName.EQUIPMENTID].ToString());
            }
            return ComboData;
        }

       
        /// <summary>
        /// 작성자 : 황지희
        /// 설명 : 기준정보 모델코드 리스트로 변환하는 함수 
        /// </summary>
        /// <returns>기준정보 모델코드 리스트를 List<string> 형식으로 반환</returns>
        public static List<String> ModelCodeList()
        {
            List<String> ComboData2 = new List<String>();
            var ModelCodeList = dbManager.CallSelectProcedure(ProcedureName.SelectDURABLEPRODUCTCombo);

            for (int i = 0; i < ModelCodeList.Count; i++)
            {
               // if (string.IsNullOrWhiteSpace(ModelCodeList[i][ColumnName.DURABLEPRODUCTID].ToString()))
                    ComboData2.Add(ModelCodeList[i][ColumnName.DURABLEPRODUCTID].ToString());
            }
            return ComboData2;
        }


        /// <summary>
        /// 작성자 : 윤보미
        /// 설명 : durable product id 로 LIMITUSEQTY 반환
        /// </summary>
        /// <param name="_durableProductID"></param>
        /// <returns></returns>
        public static int GetLIMITUSEQTY(string _durableProductID)
        {
            //SelecteDurableProductLIMITUSEQTY
            //@DURABLEPRODUCTID
            Dictionary<string, object> Params = new Dictionary<string, object>();
            Params.Add("@DURABLEPRODUCTID", _durableProductID);

            int val = 0;
            var LIMITUSEQTY = dbManager.CallSelectProcedure(ProcedureName.SelecteDurableProductLIMITUSEQTY, dbManager.GetSqlParameters(Params));
            if (LIMITUSEQTY.Count > 0)
            {
                int.TryParse(LIMITUSEQTY[0]["LIMITUSEQTY"].ToString(), out val);
            }

            return val;
        }

        /// <summary>
        /// 정수형,실수형만 입력 가능 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="includePoint">정수형 실수형 조건값 ex)includePoint = true : 실수형,includePoint = false : 정수형 </param>
        public static void TypingOnlyNumber(object sender, KeyPressEventArgs e, bool includePoint)

        {
            if (includePoint == true)
            {
                if (Char.IsDigit(e.KeyChar) == false && e.KeyChar != '.' && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (Char.IsDigit(e.KeyChar) == false && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// 영문(대문자),숫자만 입력 가능 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="tb"></param>
        public static void TypingOnlyEngNum(object sender, KeyPressEventArgs e, UserControls.MaskTextBox tb)
        {
            tb.ImeMode = ImeMode.Disable;
            //tb.txtText.CharacterCasing = CharacterCasing.Upper;
            //2019-05-30 황지희 복사붙여넣기 부분 추가
            if (e.KeyChar == 22) return;
            if (Char.IsLetter(e.KeyChar) == false && Char.IsDigit(e.KeyChar) == false && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// App Setting에 저장된 설정 불러오는 함수
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// App Setting에 저장된 설정 수정하는 함수
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetAppSetting(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection cfgCollection = config.AppSettings.Settings;

            cfgCollection.Remove(key);
            cfgCollection.Add(key, value);

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

    }
    public static class ColumnName
    {
      public  static string EQUIPMENTTYPE = "EQUIPMENTTYPE";
        public static string DURABLEID = "DURABLEID";
        public static string EQUIPMENT_RACK = "EQUIPMENT_RACK";
        public static string EQUIPMENTID = "EQUIPMENTID";
        public static string USERNAME = "USERNAME";
        public static string DURABLEPRODUCTNAME = "DURABLEPRODUCTNAME";
        public static string DESCRIPTION = "DESCRIPTION";
        public static string VENDERID = "VENDERID";
        public static string VENDERNAME = "VENDERNAME";
        public static string DURABLEPRODUCTID = "DURABLEPRODUCTID";
    }
    public static class ProcedureName
    {
        public static string JoinEquipAndDurable = "JoinEquipAndDurable";
        public static string SelecteDurableProductLIMITUSEQTY = "SelecteDurableProductLIMITUSEQTY";
        public static string SelecteDurableIDdesc = "SelecteDurableIDdesc";
        public static string SelecteUserName = "SelecteUserName";
        public static string InsertDurable = "InsertDurable";
        public static string InsertDURABLE_HIST = "InsertDURABLE_HIST";
        public static string SelectDURABLEPRODUCTbyID = "SelectDURABLEPRODUCTbyID";
        public static string FindVenderName = "FindVenderName";
        public static string DurableBySelect = "DurableBySelect";
        public static string SelectDURABLEPRODUCTCombo = "SelectDURABLEPRODUCTCombo";
    }
}