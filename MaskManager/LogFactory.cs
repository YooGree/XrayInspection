using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
[assembly:log4net.Config.XmlConfigurator(Watch =true)]

namespace MaskManager
{
    public static class LogFactory
    {
        static ILog logger;
        static bool Isinit = false;
        static void init()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("LogConfig.xml"));
            logger = LogManager.GetLogger(typeof(MainFrm));
            Isinit = true;
        }

        public static void Log(Exception e)
        {

            if (Isinit == false)
                init();
            
            logger.Error(e);

        }
        public static void Log(String Message)
        {
            if (Isinit == false)
                init();
            logger.Error(Message);
        }
    }
}
