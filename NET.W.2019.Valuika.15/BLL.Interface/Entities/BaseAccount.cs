using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BaseAccount : Account
    {
        public BaseAccount(string accountNumber, string name, decimal amaunt, int points) : base(accountNumber, name, amaunt,  points)
        {
            BonusValue = 1;
        }

        public override int CalculatePointsForDeposit(int bonusValue) => 10 * bonusValue;
        public override int CalculatePointsForWithdraw(int bonusValue) => 10 * bonusValue;

        protected override bool IsValidBalance(decimal value)
            => value >= 0;


        public override string ToString()
        {
            return "Type : Base, " + base.ToString();
        }

    }
}
