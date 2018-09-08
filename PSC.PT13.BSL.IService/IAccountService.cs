using System;
using PSC.PT13.BSL.Entities;

namespace PSC.PT13.BSL.IService
{
    public interface IAccountService : IDisposable 
    {
        AccountEntity[] SearchAccount(string accountNo);
        AccountEntity LoadAccount(string accountNo);
        void OpenNewAccount(string accountNo);
        void CloseAccount(string accountNo);
        void Deposit(string accountNo, decimal money);
        void Withdraw(string accountNo, decimal money);
        void Transfer(string fromAccountNo, string toAccountNo, decimal money);
    }
}