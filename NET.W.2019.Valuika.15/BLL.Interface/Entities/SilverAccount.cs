using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class SilverAccount : Account
    {
        public SilverAccount(string accountNumber, string name, decimal amaunt, int points) : base(accountNumber, name, amaunt, points)
        {
        }



        public override int CalculatePointsForDeposit(int bonusValue) => 20 * bonusValue + 15;
        public override int CalculatePointsForWithdraw(int bonusValue) => 20 * bonusValue + 5;

        protected override bool IsValidBalance(decimal value)
            => value >= -1000;
    }
}
