using BLL.Interface.Entities;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class Mapper
    {
        public static Account ConvertToAccount(this AccountDTO dtoAccount)
        {
            return (Account)Activator.CreateInstance(
                GetAccountType(dtoAccount.AccountType),
                dtoAccount.AccountNumber,
                dtoAccount.Name,
                dtoAccount.Amount,
                dtoAccount.Points);
        }
        public static AccountDTO ConvertToDtoAccount(this Account account)
        {
            return new AccountDTO
            {
                AccountType = account.GetType().Name,
                Points = account.Points,
                Amount = account.Amount,
                AccountNumber = account.AccountNumber,
                Name = account.Name,
                BonusValue = account.BonusValue,
            };
        }
        private static Type GetAccountType(string type)
        {
            if (type.Contains("Silver"))
            {
                return typeof(SilverAccount);
            }

            if (type.Contains("Platinum"))
            {
                return typeof(PlatinumAccount);
            }

            return typeof(BaseAccount);
        }
    }
}
