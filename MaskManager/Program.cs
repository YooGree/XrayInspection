using MaskManager.PopUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaskManager
{
    static class Program
    {
        static string _currentUser = "";
        public static string CurrentUser
        {
            get { return _currentUser; }
            set
            {
                _currentUser = value;
                _currentUserName = CommonFuction.GetUserName(_currentUser);
            }
        }
        static string _currentUserName = "";

        public static string CurrentUserName { get { return _currentUserName; } }
        public static int MaxX = 0;
        public static int MaxY = 0;

        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         //   Application.Run(new MainFrm());
          Application.Run(new PopUp.CS_MainForm());
        }
    }
}
