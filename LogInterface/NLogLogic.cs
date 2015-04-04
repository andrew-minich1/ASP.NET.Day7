using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace LogInterface
{
    public interface ILog
    {
        void Log(Exception ex);
    }
    public class NLogLogic : ILog
    {
        private static Logger logger;
        static NLogLogic()
        {
            logger = LogManager.GetCurrentClassLogger();
        }
        public void Log(Exception ex)
        {
            logger.Info(ex.Message);
            logger.Error(ex.StackTrace);
        }
    }
}
