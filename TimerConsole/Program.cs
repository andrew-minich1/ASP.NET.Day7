using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerLogicLayer;
using Handler1;
using Handler2;

namespace TimerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();
            TimerHandler1 handler1 = new TimerHandler1(timer);
            TimerHandler2 handler2 = new TimerHandler2(timer);
            timer.Start(10);
        }
    }
}
