using MaskManager.PopUp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskManager.UserControls
{
    /// <summary>
    /// 작   성   자  : 유태근
    /// 작   성   일  : 2020-12-18
    /// 설        명  : Xray 판독화면
    /// 이        력  : 
    /// </summary>
    public partial class CS_XrayDecipher : UserControl
    {
        #region 변수

        TCPServer _tcpServer = new TCPServer(Properties.Settings.Default.TargetIP, Properties.Settings.Default.TargetPort);
        Socket mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

        #endregion

        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public CS_XrayDecipher()
        {
            InitializeComponent();
            InitializeControlSetting();
            InitializeGrid();
            InitializeEvent();
        }

        #endregion

        #region 이벤트

        /// <summary>
        /// 이벤트 등록
        /// </summary>
        private void InitializeEvent()
        {
            grdAIDecipherStatus.RowPostPaint += GrdUser_RowPostPaint;

            btnJudgmentResult.Click += CommonPopup_Click;

            btnStart.Click += BtnStart_Click;
            btnEnd.Click += BtnEnd_Click;
        }

        /// <summary>
        /// 영상녹화종료
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            string sendData = "END " + txtLotNo.Text + "," + txtProductName.Text;
            OnSendData(sendData);       
        }

        /// <summary>
        /// 영상녹화시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            string sendData = "START " + txtLotNo.Text + "," + txtProductName.Text;
            OnSendData(sendData);
        }

        /// <summary>
        /// 공통팝업 호출
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommonPopup_Click(object sender, EventArgs e)
        {
            Button btnPop = (Button)sender;
            CS_CommonPopup commonPopup;

            switch (btnPop.Name)
            {
                // 판정결과
                case "btnJudgmentResult" :
                    commonPopup = new CS_CommonPopup("JUDGMENTRESULT");
                    commonPopup.WindowState = FormWindowState.Normal;
                    commonPopup.StartPosition = FormStartPosition.CenterScreen;
                    commonPopup.Show();
                    commonPopup.Activate();
                    break;
            }
        }

        /// <summary>
        /// 그리드 행번호 보여주기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrdUser_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rect = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y, grdAIDecipherStatus.RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), grdAIDecipherStatus.RowHeadersDefaultCellStyle.Font, rect, grdAIDecipherStatus.RowHeadersDefaultCellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// Excel 내보내기
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (grdAIDecipherStatus.Rows.Count == 0)
                {
                    DialogResult result = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "엑셀 데이터가 없습니다.");
                }
                else
                {
                    sfd.Filter = "csv(*.csv) | *.csv";

                    DialogResult result = CustomMessageBox.Show(MessageBoxButtons.OKCancel, "확인", "엑셀 저장 하시겠습니까?");

                    if (result == DialogResult.OK)
                    {
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            this.SaveCsv(sfd.FileName, grdAIDecipherStatus, true);
                        }
                    }

                }
            }
        }

        /// <summary>
        /// CSV파일 내보내기
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="dgv"></param>
        /// <param name="header"></param>
        private void SaveCsv(string fileName, DataGridView dgv, bool header)
        {
            string delimiter = ",";
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter csvExport = new StreamWriter(fs, Encoding.UTF8);

            if (dgv.Rows.Count == 0)
            {
                return;
            }

            if (header)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    // 숨겨진 컬럼은 엑셀 내보내기 안되도록 수정
                    if (dgv.Columns[i].HeaderText.Equals("ROWTYPE") || dgv.Columns[i].HeaderText.Equals("state"))
                    {
                        break;
                    }
                    else
                    {
                        csvExport.Write(dgv.Columns[i].HeaderText);
                    }

                    if (i != dgv.Columns.Count - 1)
                    {
                        csvExport.Write(delimiter);
                    }
                }
            }

            csvExport.Write(csvExport.NewLine);

            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {

                    // 숨겨진 컬럼은 row 엑셀에 내보내기 안되도록 수정
                    if (dgv.Columns[j].HeaderText.Equals("ROWTYPE") || dgv.Columns[j].HeaderText.Equals("state"))
                    {
                        break;
                    }
                    else
                    {
                        csvExport.Write(row.Cells[j].Value);
                    }

                    if (j != dgv.Columns.Count - 1)
                    {
                        csvExport.Write(delimiter);
                    }
                }

                csvExport.Write(csvExport.NewLine);
            }

            csvExport.Flush();
            csvExport.Close();
            fs.Close();

            DialogResult result = CustomMessageBox.Show(MessageBoxButtons.OK, "확인", "저장 되었습니다.");
        }

        #endregion

        #region 조회

        /// <summary>
        /// 조회버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// 조회
        /// </summary>
        public void Search()
        {
            try
            {
                DBManager dbManager = new DBManager();
                List<SqlParameter> parameters = new List<SqlParameter>();
                //parameters.Add(new SqlParameter("@USERTYPE", comboUserType.SelectedValue)); // 사용자 유형
                //parameters.Add(new SqlParameter("@USERNUMBER", txtUserNumber.Text)); // 사번
                //parameters.Add(new SqlParameter("@USERNAME", txtUserName.Text)); // 사용자명

                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_USERMANAGEMENT", parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    DataTable dt = ds.Tables[0];
                    grdAIDecipherStatus.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "닫기", ex.Message);
            }
        }

        /// <summary>
        /// 화면 최초 로드시 제품정보 조회
        /// </summary>
        public void ProductInfoSearch()
        {
            try
            {
                DBManager dbManager = new DBManager();
                List<SqlParameter> parameters = new List<SqlParameter>();
                parameters.Add(new SqlParameter("@SITE", Properties.Settings.Default.Site)); // Site

                DataSet ds = dbManager.CallSelectProcedure_ds("USP_SELECT_XRAYDECIPHER_PRODUCTINFO", parameters);

                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtCustomer.Text = ds.Tables[0].Rows[0]["CUSTOMER"].ToString();
                        txtUsedPlace.Text = ds.Tables[0].Rows[0]["USEDPLACE"].ToString();
                        txtProductName.Text = ds.Tables[0].Rows[0]["PRODUCTNAME"].ToString();
                        txtProductCode.Text = ds.Tables[0].Rows[0]["PRODUCTCODE"].ToString();
                        txtUser.Text = ds.Tables[0].Rows[0]["MAKERNAME"].ToString();
                        txtLotNo.Text = ds.Tables[0].Rows[0]["LOTID"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "닫기", ex.Message);
            }
        }

        #endregion

        #region 저장

        /// <summary>
        /// 저장
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 그리드뷰에 행이 한개도 없으면 Return
                if (grdAIDecipherStatus.Rows.Count == 0)
                {
                    CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장할 데이터가 없습니다.");
                    return;
                }
                else
                {
                    // 그리드에 신규, 수정, 삭제행이 없으면 Return
                    if ((grdAIDecipherStatus.DataSource as DataTable).AsEnumerable().Where(r => r["ROWTYPE"].Equals("CREATE")
                                                                                 || r["ROWTYPE"].Equals("MODIFIY")
                                                                                 || r["ROWTYPE"].Equals("DELETE")).Count() == 0)
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장할 데이터가 없습니다.");
                        return;
                    }
                }

                if (CustomMessageBox.Show(MessageBoxButtons.OKCancel, "저장", "저장 하시겠습니까?") == DialogResult.OK)
                {
                    DBManager dbManager = new DBManager();

                    Dictionary<string, object> parameters = new Dictionary<string, object>();
                    //parameters.Add("@USERTYPE", comboUserType.SelectedValue);
                    parameters.Add("@SAVEDATATABLE", grdAIDecipherStatus.DataSource as DataTable);

                    SqlParameter[] sqlPamaters = dbManager.GetSqlParameters(parameters);

                    int SaveResult = dbManager.CallNonSelectProcedure("USP_UPSERT_USERMANAGEMENT", sqlPamaters);

                    if (SaveResult > 0)
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장하였습니다.");
                        Search(); // 재조회
                    }
                    else
                    {
                        CustomMessageBox.Show(MessageBoxButtons.OK, "저장", "저장에 실패하였습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(MessageBoxButtons.OK, "저장", ex.Message);
            }
        }

        #endregion

        #region 사용자 정의 함수

        /// <summary>
        /// 기본 컨트롤 세팅
        /// </summary>
        private void InitializeControlSetting()
        {
            this.Dock = DockStyle.Fill;

            // 제품정보에 데이터 바인딩
            ProductInfoSearch();

            // TCP 서버시작
            //_tcpServer.BeginStartServer();

            // TCP 서버 - 클라이언트 연결
            OnConnectToServer();

            // 조회조건 콤보박스 세팅
            //BindingList<object> userTypeList = new BindingList<object>();
            //userTypeList.Add(new { Text = "검사자", Value = "INSPECTOR" });
            //userTypeList.Add(new { Text = "성형자", Value = "MOLDER" });

            //comboUserType.DataSource = userTypeList;
            //comboUserType.DisplayMember = "Text";
            //comboUserType.ValueMember = "Value";
            //comboUserType.SelectedValue = "INSPECTOR";
            //comboUserType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// 그리드 세팅
        /// </summary>
        private void InitializeGrid()
        {
            grdAIDecipherStatus.AutoGenerateColumns = false;
            grdAIDecipherStatus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            grdAIDecipherStatus.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            grdAIDecipherStatus.AllowUserToAddRows = false;

            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "Frame", "FRAME", "FRAME", typeof(int), 150, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "AI판정", "AIJUDGMENT", "AIJUDGMENT", typeof(string), 150, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "유형", "TYPE", "TYPE", typeof(string), 150, false, true, DataGridViewContentAlignment.MiddleCenter, 10);
            CommonFuction.SetDataGridViewColumnStyle(grdAIDecipherStatus, "행변경타입", "ROWTYPE", "ROWTYPE", typeof(string), 100, false, false, DataGridViewContentAlignment.MiddleLeft, 10);
        }

        #endregion

        #region TCP 클라이언트

        /// <summary>
        /// 열려있는 TCP 서버에 클라이언트를 연결
        /// </summary>
        private void OnConnectToServer()
        {
            if (mainSocket.Connected)
            {
                MsgBoxHelper.Error("이미 연결되어 있습니다!");
                return;
            }

            //int port;
            //if (!int.TryParse(txtPort.Text, out port))
            //{
            //    MsgBoxHelper.Error("포트 번호가 잘못 입력되었거나 입력되지 않았습니다.");
            //    txtPort.Focus();
            //    txtPort.SelectAll();
            //    return;
            //}

            try 
            { 
                mainSocket.Connect(Properties.Settings.Default.TargetIP, Convert.ToInt32(Properties.Settings.Default.TargetPort)); 
            }
            catch (Exception ex)
            {
                MsgBoxHelper.Error("연결에 실패했습니다!\n오류 내용: {0}", MessageBoxButtons.OK, ex.Message);
                return;
            }

            // 연결 완료되었다는 메세지를 띄워준다.
            Console.WriteLine("서버와 연결되었습니다.");

            // 연결 완료, 서버에서 데이터가 올 수 있으므로 수신 대기한다.
            AsyncObject obj = new AsyncObject(4096);
            obj.WorkingSocket = mainSocket;
            mainSocket.BeginReceive(obj.Buffer, 0, obj.BufferSize, 0, DataReceived, obj);
        }

        /// <summary>
        /// TCP 서버에서 넘어오는 데이터 받기
        /// </summary>
        /// <param name="ar"></param>
        private void DataReceived(IAsyncResult ar)
        {
            // BeginReceive에서 추가적으로 넘어온 데이터를 AsyncObject 형식으로 변환한다.
            AsyncObject obj = (AsyncObject)ar.AsyncState;

            // 데이터 수신을 끝낸다.
            int received = obj.WorkingSocket.EndReceive(ar);

            // 받은 데이터가 없으면(연결끊어짐) 끝낸다.
            if (received <= 0)
            {
                obj.WorkingSocket.Close();
                return;
            }

            // 텍스트로 변환한다.
            string text = Encoding.UTF8.GetString(obj.Buffer).TrimEnd('\0');

            // 0x01 기준으로 짜른다.
            // tokens[0] - 보낸 사람 IP
            // tokens[1] - 보낸 메세지
            string[] tokens = text.Split('\x01');
            string ip = tokens[0];
            string msg = tokens[1];

            // 텍스트박스에 추가해준다.
            // 비동기식으로 작업하기 때문에 폼의 UI 스레드에서 작업을 해줘야 한다.
            // 따라서 대리자를 통해 처리한다.
            Console.WriteLine(string.Format("[받음]{0}: {1}", ip, msg));

            // 클라이언트에선 데이터를 전달해줄 필요가 없으므로 바로 수신 대기한다.
            // 데이터를 받은 후엔 다시 버퍼를 비워주고 같은 방법으로 수신을 대기한다.
            obj.ClearBuffer();

            // 수신 대기
            obj.WorkingSocket.BeginReceive(obj.Buffer, 0, 4096, 0, DataReceived, obj);
        }

        /// <summary>
        /// 클라이언트 -> TCP 서버로 데이터 보내기
        /// </summary>
        /// <param name="stringData"></param>
        private void OnSendData(string stringData)
        {
            // 서버가 대기중인지 확인한다.
            if (!mainSocket.IsBound)
            {
                MsgBoxHelper.Warn("서버가 실행되고 있지 않습니다!");
                return;
            }

            // 서버 ip 주소와 메세지를 담도록 만든다.
            IPEndPoint ip = (IPEndPoint)mainSocket.LocalEndPoint;
            string addr = ip.Address.ToString();

            // 문자열을 utf8 형식의 바이트로 변환한다.
            byte[] bDts = Encoding.UTF8.GetBytes(addr + '\x01' + stringData);

            // 서버에 전송한다.
            mainSocket.Send(bDts);

            // 전송 완료 후 텍스트박스에 추가하고, 원래의 내용은 지운다.
            Console.WriteLine(string.Format("[보냄]{0}: {1}", addr, stringData));
        }

        #endregion
    }
}
