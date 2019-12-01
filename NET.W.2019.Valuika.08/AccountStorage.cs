using AccountLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcountLib
{
    public class AccountStorage
    {
        private string _path;
        private IList<Account> accounts;

        public IList<Account> Accounts { get ; set; }

        public AccountStorage(string path)
        {
            _path = path;
            Accounts = new List<Account>();
        }

        public bool SaveToFile()
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(_path, FileMode.OpenOrCreate)))
            {
                foreach (Account account in Accounts)
                {
                    writer.Write(account.Id);
                    writer.Write(account.OwnerFirstName);
                    writer.Write(account.OwnerLastName);
                    writer.Write(account.Amount);
                    writer.Write(account.Points);
                    writer.Write(account.Type.ToString());
                }
            }

            return true;
        }
        public bool LoadFromFile()
        {
            Accounts.Clear();
            using (BinaryReader reader = new BinaryReader(File.Open(_path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    var id = reader.ReadString();
                    var ownerFirstName = reader.ReadString();
                    var ownerLastName = reader.ReadString();
                    var amount = reader.ReadDecimal();
                    var points = reader.ReadInt32();
                    var type = reader.ReadString();

                    AccType accType = AccType.Base;
                    switch (type)
                    {
                        case "Gold": accType = AccType.Gold;
                            break;
                        case "Platinum":
                            accType = AccType.Platinum;
                            break;

                    }

                    Accounts.Add(new Account(id, ownerFirstName, ownerLastName, amount, points, accType ));                }
            }
            return true;
        }
    }
}
