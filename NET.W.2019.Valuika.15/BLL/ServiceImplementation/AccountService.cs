using BLL.Interface.Entities;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService
    {
        private IRepository repository;
        public void CloseAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public void DepositAccount(Account account, int count)
        {
            throw new NotImplementedException();
        }

        public void DepositAccount(string accountNumber, int v)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            throw new NotImplementedException();
        }

        public void OpenAccount(string name, AccountType accountType, IAccountNumberCreateService createService)
        {
            switch (accountType)
            {
                case AccountType.Base:
                    repository.AddAccount( new BaseAccount(createService.GetId(), name));
                    
                case AccountType.Silver:
                    return new SilverAccount(createService.GetId(), name);
                    
                case AccountType.Platinum:
                    return new PlatinumAccount(createService.GetId(), name);
                   
                default:
                    throw new ArgumentException("Not supported type. ");
            }
        }

        //public void WithdrawAccount(Account account, int count)
        //{
        //    throw new NotImplementedException();
        //}

        public void WithdrawAccount(string accountNumber, int v)
        {
            throw new NotImplementedException();
        }
    }
}
