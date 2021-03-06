using System;
using System.Data;
using PSC.PT13.DAL.IData;

namespace PSC.PT13.DAL.SqlData
{
    public class AccountData : Base, IAccountData
    {
        #region Private members section
        private const string GET_ACCOUNT = "PT_13_GetAccount";
        private const string LIST_ACCOUNT = "PT_13_ListAccount";
        private const string ADD_ACCOUNT = "PT_13_AddAccount";
        private const string UPDATE_ACCOUNT = "PT_13_UpdateAccount";
        private const string DELETE_ACCOUNT = "PT_13_DeleteAccount";
        private const string COUNT_ACCOUNT = "PT_13_CountAccount";
        private const string SEARCH_ACCOUNT_AND_BALANCE = "PT_13_SearchAccountAndBalance";
        #endregion

        #region Constructure section
        public AccountData()
        {
        }
        #endregion

        #region Public methods section
        public System.Data.DataSet GetAccount(string accountNo)
        {
            try
            {
                using (CommandData command = new CommandData())
                {
                    command.SetStoreProcedure(GET_ACCOUNT);
                    command.SetParameter("@AccountNo", System.Data.SqlDbType.NVarChar, accountNo);
                    return command.ExecuteDataSet();
                }
            }
            catch(Exception ex)
            {
                throw new DALException("GetAccount event occurs an error.[" + ex.Message + "]", ex, false);
            }
        }
        public System.Data.DataSet ListAccount(string search)
        {
            try
            {
                using (CommandData command = new CommandData())
                {
                    command.SetStoreProcedure(LIST_ACCOUNT);
                    command.SetParameter("@Search", System.Data.SqlDbType.NVarChar, search);
                    return command.ExecuteDataSet();
                }
            }
            catch (Exception ex)
            {
                throw new DALException("ListAccount event occurs an error.[" + ex.Message + "]", ex, false);
            }
        }
        public bool AddAccount(string accountNo, decimal balance)
        {
            try
            {
                using (CommandData command = new CommandData())
                {
                    command.SetStoreProcedure(ADD_ACCOUNT);
                    command.SetParameter("@AccountNo", System.Data.SqlDbType.NVarChar, accountNo);
                    command.SetParameter("@Balance", System.Data.SqlDbType.Decimal, balance);
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new DALException("AddAccount event occurs an error.[" + ex.Message + "]", ex, false);
            }
        }
        public bool UpdateAccount(string accountNo, decimal balance)
        {
            try
            {
                using (CommandData command = new CommandData())
                {
                    command.SetStoreProcedure(UPDATE_ACCOUNT);
                    command.SetParameter("@AccountNo", System.Data.SqlDbType.NVarChar, accountNo);
                    command.SetParameter("@Balance", System.Data.SqlDbType.Decimal, balance);
                    return command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw new DALException("UpdateAccount event occurs an error.[" + ex.Message + "]", ex, false);
            }
        }
        public bool DeleteAccount(string accountNo)
        {
            try
            {
                using (CommandData command = new CommandData())
                {
                    command.SetStoreProcedure(DELETE_ACCOUNT);
                    command.SetParameter("@AccountNo", System.Data.SqlDbType.NVarChar, accountNo);                    
                    return command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                throw new DALException("DeleteAccount event occurs an error.[" + ex.Message + "]", ex, false);
            }
        }
        public bool CheckAccount(string accountNo)
        {
            try
            {
                using (CommandData command = new CommandData())
                {
                    command.SetStoreProcedure(COUNT_ACCOUNT);
                    command.SetParameter("@AccountNo", System.Data.SqlDbType.NVarChar, accountNo);
                    System.Data.DataSet ds = command.ExecuteDataSet();

                    return !ds.Tables[0].Rows[0][0].Equals(0); 
                }
            }
            catch(Exception ex)
            {
                throw new DALException("CheckAccount event occurs an error.[" + ex.Message + "]", ex, false);
            }
        }
        public DataSet ListAccount(string accountNo, string balance)
        {
            try
            {
                using(var command = new CommandData())
                {
                    command.SetStoreProcedure(SEARCH_ACCOUNT_AND_BALANCE);
                    command.SetParameter("@AccountNo", System.Data.SqlDbType.NVarChar, accountNo);
                    command.SetParameter("@Balance", System.Data.SqlDbType.NVarChar, balance);
                    return command.ExecuteDataSet();
                }
            }
            catch (Exception ex)
            {
                throw new DALException("ListAccount event occurs an error.[" + ex.Message + "]", ex, false);
            }
        }
        #endregion
    }
}
