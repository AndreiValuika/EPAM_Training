using BLL.Interface.Entities;
using DAL.Interface.Interfaces;
using DAL.Interface.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Fake.Repositories
{
    public class FakeRepository:IRepository
    {
        private List<Account> accounts;

        public void AddAccount(AccountDTO account)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountDTO> GetAccounts()
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(AccountDTO account)
        {
            throw new NotImplementedException();
        }

        public void UpdateAccount(AccountDTO account)
        {
            throw new NotImplementedException();
        }
    }
}
