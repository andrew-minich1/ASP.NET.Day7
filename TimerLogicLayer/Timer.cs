using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TimerLogicLayer
{
    public sealed class NewTimerEventArgs : EventArgs
    {
        private readonly int seconds;
        public NewTimerEventArgs(int seconds)
        {
            this.seconds = seconds;
        }
        public long Seconds { get { return seconds; } }
    }
    public class Timer
    {
        public event EventHandler<NewTimerEventArgs> StopTimer = delegate { };

        protected virtual void OnStopTimer(NewTimerEventArgs e)
        {
            EventHandler<NewTimerEventArgs> timer = StopTimer;
            timer(this, e);
        }

        public void Start(int Seconds)
        {
            Thread.Sleep(Seconds * 1000);
            this.OnStopTimer(new NewTimerEventArgs(Seconds));
        }
    }
}
