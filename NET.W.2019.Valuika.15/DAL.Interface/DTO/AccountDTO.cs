using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
   public class AccountDTO
    {
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int Points { get; set; }
        public int BonusValue { get; set; }
    }
}
