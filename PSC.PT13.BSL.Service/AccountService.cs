using System;
using System.Transactions;
using PSC.PT13.DAL.IData;
using PSC.PT13.DAL.DataFactory;
using PSC.PT13.BSL.Entities;
using PSC.PT13.BSL.IService;

namespace PSC.PT13.BSL.Service
{
    public class AccountService : Base, IAccountService 
    {
        #region Private methods section
        private AccountEntity ConvertDataRowToEntity(System.Data.DataRow dr)
        {
            AccountEntity accountEntity = new AccountEntity();
            accountEntity.AccountNo = (dr["AccountNo"] == DBNull.Value) ? "" : dr["AccountNo"].ToString();
            accountEntity.Money = ((dr["Balance"] == DBNull.Value) ? 0 : Convert.ToDecimal(dr["Balance"]));
            return accountEntity;
        }

        private AccountEntity[] ConvertDataTableToEntities(System.Data.DataTable dt)
        {
            if (dt.Rows.Count == 0) return null;
            AccountEntity[] accountEntity = new AccountEntity[dt.Rows.Count];
            for (int i = 0; i < accountEntity.Length; i++)
            {
                accountEntity[i] = ConvertDataRowToEntity(dt.Rows[i]);
            }
            return accountEntity;
        }
        #endregion

        #region Constructure section
        public AccountService()
        {
        }
        #endregion

        #region Destructor section
        ~AccountService()
        {
            this.Dispose(false);
        }
        #endregion

        #region Public methods section
        public AccountEntity[] SearchAccount(string accountNo)
        {
            try
            {
                using (IAccountData objAccountData = Builder.AccountData())
                {
                    //objAccountData.AddAccount(accountNo);
                    //objAccountData.ListAccount(accountNo);
                    //objAccountData = Builder.AccountData();
                    Entities.AccountEntity ac = new AccountEntity();
                    ac.Equals("");
                    return this.ConvertDataTableToEntities(objAccountData.ListAccount(accountNo).Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw new BSLException("SearchAccount event occurs an error.[" + ex.Message + "]", ex, true);
            }
            finally
            {
                //if (objAccountData != null) objAccountData.Dispose();
            }
        }
        public AccountEntity LoadAccount(string accountNo)
        {
            IAccountData objAccountData = null;
            try
            {
                objAccountData = Builder.AccountData();
                return this.ConvertDataRowToEntity(objAccountData.GetAccount(accountNo).Tables[0].Rows[0]);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (objAccountData != null)  objAccountData.Dispose();
            }
        }
        public void OpenNewAccount(string accountNo)
        {
            IAccountData objAccountData = null;
            try
            {
                objAccountData = Builder.AccountData();

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
                {              

                    if (objAccountData.CheckAccount(accountNo)) throw new Exception("Already account.");
                    if (!objAccountData.AddAccount(accountNo, 0)) throw new Exception("Error: Can not add data");
                    scope.Complete();                    
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if(objAccountData != null) objAccountData.Dispose();
            }
        }
        public void CloseAccount(string accountNo)
        {
            IAccountData objAccountData = null;
            try
            {
                objAccountData = Builder.AccountData();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (!objAccountData.CheckAccount(accountNo)) throw new Exception("Account not found.");
                    if (!objAccountData.DeleteAccount(accountNo)) throw new Exception("Error: Can not delete data.");
                    scope.Complete();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (objAccountData != null) objAccountData.Dispose();
            }
        }
        public void Deposit(string accountNo, decimal money)
        {
            IAccountData objAccountData = null;
            try
            {
                objAccountData = Builder.AccountData();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    System.Data.DataSet ds = objAccountData.GetAccount(accountNo);
                    if (ds.Tables[0].Rows.Count == 0) throw new Exception("Account not found.");
                    money = (ds.Tables[0].Rows[0]["Balance"] == DBNull.Value) ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[0]["Balance"]) + money;
                    if (!objAccountData.UpdateAccount(accountNo, money)) throw new Exception("Error: Can not update data.");
                    scope.Complete();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (objAccountData != null) objAccountData.Dispose();
            }
        }
        public void Withdraw(string accountNo, decimal money)
        {
            IAccountData objAccountData = null;
            try
            {
                objAccountData = Builder.AccountData();
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    System.Data.DataSet ds = objAccountData.GetAccount(accountNo);
                    if (ds.Tables[0].Rows.Count == 0) throw new Exception("Account not found.");
                    decimal oldMoney = (ds.Tables[0].Rows[0]["Balance"] == DBNull.Value) ? 0 : Convert.ToDecimal(ds.Tables[0].Rows[0]["Balance"]);                    
                    if (oldMoney < money) throw new Exception("Money...");
                    money = oldMoney - money;
                    if (!objAccountData.UpdateAccount(accountNo, money)) throw new Exception("Error: Can not update data.");
                    scope.Complete();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (objAccountData != null) objAccountData.Dispose();
            }
        }
        public void Transfer(string fromAccountNo, string toAccountNo, decimal money)
        {
            try
            {                
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    this.Withdraw(fromAccountNo, money);
                    this.Deposit(toAccountNo, money);
                    scope.Complete();
                }
            }
            catch
            {
                throw;
            }            
        }

        public AccountEntity[] Search(string search)
        {
            try
            {
                using(IAccountData accountData = Builder.AccountData())
                {
                    Entities.AccountEntity ac = new AccountEntity();
                    ac.Equals("");
                    return this.ConvertDataTableToEntities(accountData.ListAccount(search).Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw new BSLException("Search event occurs an error.[" + ex.Message + "]", ex, true);
            }
        }

        public bool UpdateAccount(string accountNo, decimal balance)
        {
            try
            {
                using(IAccountData accountData = Builder.AccountData())
                {
                    return accountData.UpdateAccount(accountNo, balance);
                }
            }
            catch (Exception ex)
            {
                throw new BSLException("UpdateAccount event occurs an error.[" + ex.Message + "]", ex, true);
            }
        }

        public bool AddAccount(string accountNo, decimal balance)
        {
            try
            {
                if (CheckAccount(accountNo)) { return false; }

                using(IAccountData accountData = Builder.AccountData())
                {
                    return accountData.AddAccount(accountNo, balance);
                }
            }
            catch (Exception ex)
            {
                throw new BSLException("AddAccount event occurs an error.[" + ex.Message + "]", ex, true);
            }
        }

        public bool DeleteAccount(string accountNo)
        {
            try
            {
                using(IAccountData accountData = Builder.AccountData())
                {
                    return accountData.DeleteAccount(accountNo);
                }
            }
            catch (Exception ex)
            {
                throw new BSLException("DeleteAccount event occurs an error.[" + ex.Message + "]", ex, true);
            }
        }

        public bool CheckAccount(string accountNo)
        {
            try
            {
                using(IAccountData accountData = Builder.AccountData())
                {
                    return accountData.CheckAccount(accountNo);
                }
            }
            catch (Exception ex)
            {
                throw new BSLException("DeleteAccount event occurs an error.[" + ex.Message + "]", ex, true);
            }
        }

        public AccountEntity[] SearchAccountAndBalance(string accountNo, string balance)
        {
            try
            {
                using(IAccountData accountData = Builder.AccountData())
                {
                    return this.ConvertDataTableToEntities(accountData.ListAccount(accountNo, balance).Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw new BSLException("SearchAccountAndBalance event occurs an error.[" + ex.Message + "]", ex, true);
            }
        }
        #endregion
    }
}
