using PSC.Frameworks.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UILException
/// </summary>
public class UILException : CustomException
{
    public UILException(string sMessage, System.Exception oInnerException, bool bLog)
            : base(sMessage, oInnerException, bLog)
    {
        //
        // TODO: Add constructor logic here
        //
    }
}