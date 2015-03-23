using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerLogicLayer;

namespace Handler2
{
    public class TimerHandler2
    {
        public void StopHandler(Object sender, NewTimerEventArgs eventArgs)
        {
            Console.WriteLine("Stop Timer after {0} sec", eventArgs.Seconds);
        }

        public void Register(Timer timer)
        {
            timer.StopTimer += StopHandler;
        }
        public void Unregister(Timer timer)
        {
            timer.StopTimer -= StopHandler;
        }
    }
}
