using PSC.Frameworks.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.PT13.DAL.SqlData
{
    [Serializable]
    public class DALException : CustomException
    {
        public DALException(string sMessage, System.Exception oInnerException, bool bLog)
            : base(sMessage, oInnerException, bLog)
        {

        }
    }
}
