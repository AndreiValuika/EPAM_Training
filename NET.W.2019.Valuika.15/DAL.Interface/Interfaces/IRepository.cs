using DAL.Interface.DTO;
using System.Collections.Generic;

namespace DAL.Interface.Interfaces
{

    public interface IRepository
    {
        void AddAccount(AccountDTO account);
        void RemoveAccount(AccountDTO account);
        IEnumerable<AccountDTO> GetAccounts();
        void UpdateAccount(AccountDTO account);
    }

}
