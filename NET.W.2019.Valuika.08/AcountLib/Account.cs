using AcountLib;
using System;

namespace AccountLib
{
    public class Account
    {
        public string  Id { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public decimal Amount { get; set; }
        public int Points { get; set; }
        public AccType Type { get; set; }


        public Account(string id, string ownerFirstName, string ownerLastName, decimal amount, int points, AccType type)
        {
            Id = id;
            OwnerFirstName = ownerFirstName;
            OwnerLastName = ownerLastName;
            Amount = amount;
            Points = points;
            Type = type;
        }

        public Account()
        {
        }

       
        public override string ToString()
        {
            return String.Format("Account №{0} Owner: {1} {2}  Amount: {3}$  points:{4}   Type: {5}",
                Id, OwnerFirstName,
                OwnerLastName, Amount, Points, Type);
        }

        public override bool Equals(object obj)
        {
            return obj is Account account &&
                   Id == account.Id;
        }
    }
}