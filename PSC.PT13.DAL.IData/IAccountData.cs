using System;
using System.Data;

namespace PSC.PT13.DAL.IData
{
    public interface IAccountData : IDisposable
    {
        DataSet GetAccount(string accountNo);
        DataSet ListAccount(string accountNo);
        bool AddAccount(string accountNo);
        bool UpdateAccount(string accountNo, decimal balance);
        bool DeleteAccount(string accountNo);
        bool CheckAccount(string accountNo);
    }
}