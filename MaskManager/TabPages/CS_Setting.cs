using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using MaskManager.PopUp;
using System.Drawing.Printing;

namespace MaskManager.TabPages
{
    /// <summary>
    /// 작   성   자  : 유태근
    /// 작   성   일  : 2020-12-07
    /// 설        명  : 환경세팅화면
    /// 이        력  : 
    /// </summary>
    public partial class CS_Setting : UserControl
    {
        #region 생성자

        /// <summary>
        /// 생성자
        /// </summary>
        public CS_Setting()
        {
            InitializeComponent();
            InitializeControlSetting();
        }

        #endregion

        #region 사용자 정의 함수

        /// <summary>
        /// 기본 컨트롤 세팅
        /// </summary>
        private void InitializeControlSetting()
        {
            this.Dock = DockStyle.Fill;
        }

        #endregion
    }
}
