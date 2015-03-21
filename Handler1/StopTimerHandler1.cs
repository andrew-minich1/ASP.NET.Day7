using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerLogicLayer;

namespace Handler1
{
    public class TimerHandler1
    {
        public TimerHandler1(Timer timer)
        {
            if (timer == null) throw new ArgumentNullException();
            timer.StartTimer += StartHandler;
            timer.StopTimer += StopHendler;
        }
        public void StartHandler(Object sender, NewTimerEventArgs eventArgs)
        {
            Console.WriteLine("Start Timer : {0} sec", eventArgs.Seconds);
        }

        public void StopHendler(Object sender, EventArgs eventArgs)
        {
            Console.WriteLine("Stop Timer");
        }

        public void Unregister(Timer timer)
        {
            timer.StartTimer -= StartHandler;
            timer.StartTimer += StopHendler;
        }
    }
}
