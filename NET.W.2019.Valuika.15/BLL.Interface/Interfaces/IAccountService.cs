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
        void OpenAccount(string name, AccountType accountType, IAccountNumberCreateService createService);
        IEnumerable<Account> GetAllAccounts();
        void CloseAccount(Account account);
        void DepositAccount(string accountNumber, decimal v);
        void WithdrawAccount(string accountNumber,decimal v);
    }
}
