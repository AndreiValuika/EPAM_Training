using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerLib;

namespace TimerTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new Timer();
            timer.SetTimer(1, "Time over.");
            timer.Time += delegate(object o, TimerArgs timerArgs) { Console.WriteLine($"First object receive message {timerArgs.msg}"); };
            timer.Time += delegate(object o, TimerArgs timerArgs) { Console.WriteLine($"Second object receive message {timerArgs.msg}"); };
            var listener = new Listener();
            timer.Time += listener.ShowMessage;
            timer.Start();
            Console.ReadKey();
        }
    }
}
