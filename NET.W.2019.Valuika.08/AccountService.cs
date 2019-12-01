using AccountLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcountLib
{
    public class AccountService
    {
        private AccountStorage _storage;

        public AccountService(AccountStorage storage) 
        {
            _storage = storage;
        }

        public void Save() 
        {
            _storage.SaveToFile();
        }

        public void Load() 
        {
            _storage.LoadFromFile();
        }
        public IList<Account> GetAllAccount() 
        {
            return _storage.Accounts;
        }
        public Account GetAccount(string id) 
        {
           return _storage.Accounts.FirstOrDefault<Account>(x => x.Id.Equals(id));
        }
        public void AddAccount(Account account) 
        {
            if (GetAccount(account.Id)!=null)
            {
                throw new ArgumentException("Already exists");
            }

            _storage.Accounts.Add(account);
        }

        public void DeleteAccount(string accountId) 
        {
            var account = GetAccount(accountId);
            if (account == null)
            {
                throw new ArgumentException("Account not found");
            }

            _storage.Accounts.Remove(account);
        }
        public void AddMoney(string accountId,decimal count)
        {
            var account = GetAccount(accountId);
            if (account != null)
            {
                account.Amount += count;

                switch (account.Type)
                {
                    case AccType.Base:
                        account.Points += 5;
                        break;
                    case AccType.Gold:
                        account.Points += 10;
                        break;
                    case AccType.Platinum:
                        account.Points += 15;
                        break;
                    default:
                        break;
                }

            }
            else 
            {
                throw new ArgumentException("Account not found");
            }
        }
        public void SubMoney(string accountId,decimal count)
        {
            var account = GetAccount(accountId);
            if (account != null)
            {
                if (account.Amount-count < 0)
                {
                    throw new Exception("Not enough money.");
                }
                account.Amount -= count;

                switch (account.Type)
                {
                    case AccType.Base:
                        account.Points -= 5;
                        break;
                    case AccType.Gold:
                        account.Points -= 10;
                        break;
                    case AccType.Platinum:
                        account.Points -= 15;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                throw new ArgumentException("Account not found.");
            }

        }
    }
}
