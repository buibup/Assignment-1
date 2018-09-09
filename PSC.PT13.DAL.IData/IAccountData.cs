using System;
using System.Data;

namespace PSC.PT13.DAL.IData
{
    public interface IAccountData : IDisposable
    {
        DataSet GetAccount(string accountNo);
        DataSet ListAccount(string search);
        DataSet ListAccount(string accountNo, string balance);
        bool AddAccount(string accountNo, decimal balance);
        bool UpdateAccount(string accountNo, decimal balance);
        bool DeleteAccount(string accountNo);
        bool CheckAccount(string accountNo);
    }
}
