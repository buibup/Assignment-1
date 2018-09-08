using System;
using PSC.PT13.DAL.IData;

namespace PSC.PT13.DAL.SqlData
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
    public class CommandData : ICommandData 
    {
        #region Private members section
        private bool disposed = false;
        private System.Data.SqlClient.SqlCommand command;
        #endregion

        #region Private methods section
        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if (command.Connection.State == System.Data.ConnectionState.Open)
                    {
                        command.Connection.Close();
                        command.Connection.Dispose();
                    }                    
                }
            }
            disposed = true;
        }

        private string GetConnectionString()
        {            
            return System.Configuration.ConfigurationManager.AppSettings["SQLConnection"].ToString();
        }
        #endregion

        #region Constructure section
        public CommandData()
        {
            this.command = new System.Data.SqlClient.SqlCommand(); 
        }
        #endregion

        #region Destructor section
        ~CommandData()
        {
            Dispose(false);
        }

        #endregion

        #region Public methods section
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SetStoreProcedure(string storeProcedure)
        {
            this.command.Parameters.Clear();
            this.command.CommandText = storeProcedure;
            this.command.CommandType = System.Data.CommandType.StoredProcedure;
        }

        public void SetSQLCommand(string sqlCommand)
        {
            this.command.CommandText = sqlCommand;
            this.command.CommandType = System.Data.CommandType.Text;
        }

        public void SetParameter(string parameterName, System.Data.SqlDbType dbType)
        {
            SetParameter(parameterName, dbType, null);
        }

        public void SetParameter(string parameterName, System.Data.SqlDbType dbType, object vals)
        {
            System.Data.SqlClient.SqlParameter param = new System.Data.SqlClient.SqlParameter(parameterName, dbType);
            param.Value = vals;
            this.command.Parameters.Add(param);
        }

        public System.Data.DataSet ExecuteDataSet()
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            try
            {
                using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(GetConnectionString()))
                {
                    conn.Open();
                    this.command.Connection = conn;
                    System.Data.SqlClient.SqlDataAdapter dataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                    dataAdapter.SelectCommand = this.command;
                    dataAdapter.Fill(ds);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public bool ExecuteNonQuery()
        {
            int ret;
            try
            {
                using (this.command.Connection = new System.Data.SqlClient.SqlConnection(GetConnectionString()))
                {
                    this.command.Connection.Open();
                    ret = this.command.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
            return !(ret == 0);            
        }
        #endregion
    }
}
