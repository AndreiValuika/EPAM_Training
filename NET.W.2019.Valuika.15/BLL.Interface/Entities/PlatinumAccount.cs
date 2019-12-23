using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class PlatinumAccount : Account
    {
        public PlatinumAccount(string accountNumber, string name, decimal amaunt, int points) : base(accountNumber, name, amaunt, points)
        {
        }

        public override int CalculatePointsForDeposit(int bonusValue) => 30 * bonusValue + 30;
        public override int CalculatePointsForWithdraw(int bonusValue) => 30 * bonusValue + 10;

        protected override bool IsValidBalance(decimal value)
            => value >= -10000;
    }
}
