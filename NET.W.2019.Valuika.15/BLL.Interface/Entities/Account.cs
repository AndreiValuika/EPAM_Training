using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public abstract class Account
    {
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public int Points { get; set; }
        public int BonusValue { get; set; }

        protected Account(string accountNumber, string name, decimal amount, int points)
        {
          
                Amount = amount;
                Points = points;
            AccountNumber = accountNumber;
            Name = name;
        }
        
        public abstract int CalculatePointsForDeposit(int bonusValue);
        public abstract int CalculatePointsForWithdraw(int bonusValue);
        protected abstract bool IsValidBalance(decimal value);
       
        public void Deposit(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException(nameof(money));
            }

            Amount += money;
            Points += CalculatePointsForDeposit(BonusValue);
        }
      
        public void Withdraw(decimal money)
        {
            if (money <= 0)
            {
                throw new ArgumentException(nameof(money));
            }

            if (Amount <= money)
            {
                throw new ArgumentException(nameof(money));
            }

            Amount -= money;
            Points -= CalculatePointsForWithdraw(BonusValue);
        }
        public override string ToString()
        {
            return string.Format("Account №{0}\n Owner: {1} \n Amount: {2}$  points:{3} ",
                AccountNumber, Name, Amount, Points);
        }
    }

}
