using System;
using System.Collections.Generic;
using System.Text;

namespace PSC.PT13.DAL.IData
{
    public interface ICommandData : IDisposable 
    {
        /// <summary>
        /// Created By  : Mr.Prakasit Kitrakham
        /// Created Date: 04-July-2007
        /// Description : Common database command class for connection SQL Server database.
        /// 
        /// Version History	
        /// ---------------------------------------------------------------------
        /// | Version | Description              |  Modify Date  |  Updated By  |
        /// ---------------------------------------------------------------------
        /// |  1.0.0  | Initial version.         |  04-July-2007 |  Prakasit K. |
        /// ---------------------------------------------------------------------        
        /// </summary>               
        void SetStoreProcedure(string storeProcedure);
        void SetSQLCommand(string sqlCommand);
        void SetParameter(string parameterName, System.Data.SqlDbType dbType);
        void SetParameter(string parameterName, System.Data.SqlDbType dbType, object vals);
        System.Data.DataSet ExecuteDataSet();        
        bool ExecuteNonQuery();                
    }
}
