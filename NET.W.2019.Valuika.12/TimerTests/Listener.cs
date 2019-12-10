using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerLib;

namespace TimerTests
{
    public class Listener
    {
        public void ShowMessage(object sender, TimerArgs e)
        {
            Console.WriteLine($"Lister get message {e.msg} from {sender.ToString()}");
        }
    }
}
