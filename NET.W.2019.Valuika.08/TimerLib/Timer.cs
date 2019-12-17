using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerLib
{
    public class Timer
    {
        private int _seconds;
        private string _msg;
        public void SetTimer(int second, string msg) 
        {
            _seconds = second;
            _msg = msg;
        }

        public event EventHandler<TimerArgs> Time;

        public void OnFinish(object sender, TimerArgs e) 
        {
            Time?.Invoke(sender, e);
        }
        public void Start() 
        {
            Thread.Sleep(1000 * _seconds);
            OnFinish(this, new TimerArgs() {msg = _msg });

        }


    }
}
