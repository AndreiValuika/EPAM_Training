using QueueLib;
using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var que = new Queue<int>();
            for (int i = 0; i < 10; i++)
            {
                que.Add(i);
            }

            foreach (var item in que)
            {
                Console.WriteLine(item);
            }

            while (que.Count!=0)
            {
                Console.WriteLine(que.Get());
            }
            Console.ReadKey();
        }
    }
}
