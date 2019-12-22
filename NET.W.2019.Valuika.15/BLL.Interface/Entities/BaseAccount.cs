using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class BaseAccount : Account
    {
        public BaseAccount(string accountNumber, string name) : base(accountNumber, name)
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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Type : Base, " + base.ToString();
        }

        protected override bool IsValidBalance(decimal value)
        {
            throw new NotImplementedException();
        }
    }
}
