using AccountLib;
using AcountLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountStorage  storage = new AccountStorage("Bank.bin");
            AccountService service = new AccountService(storage);

            service.AddAccount(new Account("11111", "Name1", "Name11", 100, 50, AccType.Base));
            service.AddAccount(new Account("22222", "Name2", "Name22", 1000, 4, AccType.Platinum));
            service.AddAccount(new Account("33333", "Name3", "Name22", 10, 65, AccType.Gold));
            service.AddAccount(new Account("44444", "Name4", "Name22", 10m, 88, AccType.Base));

            Console.WriteLine("All account :");
            foreach (var item in service.GetAllAccount())
            {
                Console.WriteLine(item + "\n\r");
            }



            Console.WriteLine("Try add exist account:");
            try
            {
                service.AddAccount(new Account("33333", "Name3", "Name22", 100m, 5, AccType.Gold));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
               
            }

            Console.WriteLine("Try delete non-exist account:");
            try
            {
                service.DeleteAccount("8888");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

            Console.WriteLine(" Delete  account id=33333 :"+"\n\r");
            service.DeleteAccount("33333");
            foreach (var item in service.GetAllAccount())
            {
                Console.WriteLine(item + "\n\r");
            }

            Console.WriteLine(" Add 50 to  account id=22222 :" + "\n\r");
            service.AddMoney("22222", 50);
            foreach (var item in service.GetAllAccount())
            {
                Console.WriteLine(item + "\n\r");
            }

            Console.WriteLine("Save. And Load to other storage: \n\r");
            service.Save();
            storage = new AccountStorage("Bank.bin");
            service = new AccountService(storage);
            service.Load();
            foreach (var item in service.GetAllAccount())
            {
                Console.WriteLine(item + "\n\r");
            }
            Console.WriteLine(  );
            

        }
    }
}
