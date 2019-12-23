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

        public AccountService(IRepository repository)
        {
            this.repository = repository;
        }

        public void CloseAccount(Account account)
        {
            throw new NotImplementedException();
        }

        private Account GetAccount(string id) 
        {
            return Mappers.Mapper.ConvertToAccount(repository.GetAccounts().First(n => n.AccountNumber.Equals(id)));
        }

        public void DepositAccount(string accountNumber, decimal v)
        {
            GetAccount(accountNumber).Deposit(v);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            foreach (var item in repository.GetAccounts())
            {
                accounts.Add(Mappers.Mapper.ConvertToAccount(item));
            }
            return accounts;
        }
        public void OpenAccount(string name, AccountType accountType, IAccountNumberCreateService createService) 
        {
            var tempAccount = CreateAccount(name, accountType, createService);
            repository.AddAccount(Mappers.Mapper.ConvertToDtoAccount(tempAccount));

        }
        private Account CreateAccount(string name, AccountType accountType, IAccountNumberCreateService createService)
        {
            switch (accountType)
            {
                case AccountType.Base:
                    return new BaseAccount(createService.GetId(), name,0,0);
                    
                case AccountType.Silver:
                    return new SilverAccount(createService.GetId(), name,0,0);
                    
                case AccountType.Platinum:
                    return new PlatinumAccount(createService.GetId(), name,0,0);
                   
                default:
                    throw new ArgumentException("Not supported type. ");
            }
        }

        

        public void WithdrawAccount(string accountNumber, decimal v)
        {
            GetAccount(accountNumber).Withdraw(v);
        }

       
    }
}
