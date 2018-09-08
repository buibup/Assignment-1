using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.Web;

using PSC.Frameworks.Exception;

namespace PSC.PT13.BSL.Service
{
    [Serializable]
    public class BSLException : CustomException
    {
        public BSLException(object oSource, string sCode, string sMessage, System.Exception oInnerException, bool bLog, bool bThrowSoap)
            : base(oSource, sCode, sMessage, oInnerException, bLog, bThrowSoap)
        {
        }

        public BSLException(object oSource, string sCode, string sMessage, System.Exception oInnerException, bool bLog)
            : base(oSource, sCode, sMessage, oInnerException, bLog)
        {
        }

        //public BSLException(object oSource, string sCode, string sMessage, System.Exception oInnerException, bool bLog)
        //    : base(oSource, sCode, sMessage, oInnerException, bLog)
        //{
        //    //FileName = fileName;
        //}

        public BSLException(object oSource, string sCode, string sMessage, bool bLog, string fileName)
            : base(oSource, sCode, sMessage, bLog)
        {
        }
        

        //public BSLException(object oSource, string sCode, string sMessage, bool bLog)
        //    : base(sMessage, bLog)
        //{
        //    //FileName = fileName;
        //}

        public BSLException(string sMessage, System.Exception oInnerException, bool bLog)
            : base(sMessage, oInnerException, bLog)
        {
        }

        public BSLException(string sMessage, bool bLog)
            : base(sMessage, bLog)
        {
        }

        public BSLException()
        {
            // TODO: Complete member initialization
        }

        private static object _objectReq = new object();

        protected override void Dump(string sMessage)
        {
            if (_objectReq == null)
                    _objectReq = new object();
            lock (_objectReq)
            {
                try
                {
                    base.Dump(sMessage);
                }
                catch { }
            }
        }
        public override string Format(object oSource, string sCode, string sMessage, System.Exception oInnerException)
        {
            StringBuilder sNewMessage = new StringBuilder();
            string sErrorStack = null;

            // if sPNR is not null or not empty, insert PNR into sMessage
            if (MessageExt != null && this.MessageExt != string.Empty)
                sMessage = MessageExt.ToUpper() + " - " + sMessage;

            // get the error stack, if InnerException is null, sErrorStack will be "exception was not chained" and should never be null
            sErrorStack = BuildErrorStack(oInnerException);

            // we want immediate gradification 
            Trace.AutoFlush = true;

            sNewMessage.Append("Exception Summary \r\n")
                .Append("---------------------------------------------------------------------------------------\r\n")
                .Append(DateTime.Now.ToShortDateString())
                .Append(":")
                .Append(DateTime.Now.ToShortTimeString())
                .Append(" - ")
                .Append(sMessage)
                .Append("\r\n\r\n")
                .Append(sErrorStack);

            return sNewMessage.ToString();
        }

        public override void SetLogFileName()
        {
            try
            {
                fileName = (string)ConfigurationManager.AppSettings["BSL_LOG_FILE"] ?? @"~/Logs/BSLErrorLog.txt";
            }
            catch
            {
                fileName = @"~/Logs/BSLErrorLog.txt";

            }

            //fileName = @"D:\Data\AYCAP\BSLErrorLog.txt";
            try
            {
                fileName = HttpContext.Current.Server.MapPath(fileName);
            }
            catch
            {
                fileName = (string)ConfigurationManager.AppSettings["BSL_ASYN_LOG_FILE"] ?? @" D:\Data\BAY.KMA.MobileGateway.Service\AsyLogs\BSLErrorLog.txt";
                //fileName = (string)ConfigurationManager.AppSettings["BSL_ASYN_LOG_FILE"] ?? @"\Logs\BSLErrorLog.txt";
                //fileName = AppDomain.CurrentDomain.BaseDirectory + fileName;
            }
        }
    }
}