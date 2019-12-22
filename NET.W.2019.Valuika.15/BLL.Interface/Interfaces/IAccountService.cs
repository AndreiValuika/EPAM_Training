using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IAccountService
    {
        Account OpenAccount(string name, AccountType accountType, IAccountNumberCreateService createService);
        IEnumerable<Account> GetAllAccounts();
        //void DepositAccount(Account account, int v);
        //void WithdrawAccount(Account account, int v);
        void CloseAccount(Account account);
        void DepositAccount(string accountNumber, int v);
        void WithdrawAccount(string accountNumber, int v);
    }
}
