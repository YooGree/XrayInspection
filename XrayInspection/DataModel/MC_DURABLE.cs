using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrayInspection.DataModel
{
    public class MC_DURABLE
    {
        DBManager dbManager = new DBManager();

        public string DURABLEID { get; set; }

        string _durableProductID = "";
        public string DURABLEPRODUCTID
        {
            get { return _durableProductID; }
            set
            {
                _durableProductID = value;
                _description = dbManager.FindProductInfo(_durableProductID, ColumnName.DESCRIPTION);
                _durableProductName = dbManager.FindProductInfo(_durableProductID, ColumnName.DURABLEPRODUCTNAME);
            }
        }

        string _durableProductName = "";
        public string DURABLEPRODUCTName
        {
            get { return _durableProductName; }
        }
        string _venderID = "";
        public string VENDERID
        {
            get { return _venderID; }
            set
            {
                _venderID = value;
                _venderName = dbManager.FindVenderName(_venderID);
            }
        }

        string _venderName = "";
        public string VENDERName { get { return _venderName; } }

        string _inputResultName = "";
        string _inputResult = "";
        public string INPUTRESULT
        {
            get { return _inputResult; }
            set
            {
                _inputResult = value;
                _inputResultName = CommonFuction.GetInputResultName(_inputResult);
            }
        }
        public string INPUTRESULTName { get { return _inputResultName; } }


        public string RACKID { get; set; }
        public DateTime CREATEDATE { get; set; }
        public DateTime INPUTDATE { get; set; }

        public string INPUTDATESTRING
        {
            get { return INPUTDATE.ToString("yyyy-MM-dd HH:mm:ss"); }
            set {
                INPUTDATESTRING = value;
                INPUTDATE = DateTime.Parse(value);
            }
        }

        string _creator = "";
        public string CREATOR
        {
            get { return _creator; }
            set
            {
                _creator = value;
                _creatorName = CommonFuction.GetUserName(_creator);
            }
        }

        string _creatorName = "";
        public string CREATORName{ get { return _creatorName; } }
        string _description = "";
        public string DESCRIPTION { get { return _description; } }

        //Mask 정보등록화면
        //DURABLEPID	: 일련번호
        //DURABLEPRODUCTID : 모델명
        //VENDERID : 업체코드
        //INPUTRESULT : 수입검사결과
        //RACKID : 적치대번호
        //CREATEDATE : 입고일자
        //CREATOR : 담당자
        //DESCRIPTION : 주석

    }
}
