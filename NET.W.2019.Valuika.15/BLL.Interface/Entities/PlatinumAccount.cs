using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class PlatinumAccount : Account
    {
        public PlatinumAccount(string accountNumber, string name) : base(accountNumber, name)
        {
        }

      

        public override int CalculatePointsForDeposit(int bonusValue)
        {
            throw new NotImplementedException();
        }

        public override int CalculatePointsForWithdraw(int bonusValue)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValidBalance(decimal value)
        {
            throw new NotImplementedException();
        }
    }
}
