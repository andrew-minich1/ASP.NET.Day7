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
        public event EventHandler StopTimer = delegate { };
        public event EventHandler<NewTimerEventArgs> StartTimer = delegate { };

        protected virtual void StartOn(NewTimerEventArgs e)
        {
            EventHandler<NewTimerEventArgs> timer = StartTimer;
            timer(this, e);
        }
        protected virtual void StopOn()
        {
            EventHandler timer = StopTimer;
            timer(this, EventArgs.Empty);
        }

        public void Start(int seconds)
        {
            StartOn(new NewTimerEventArgs(seconds));
            Thread.Sleep(seconds * 1000);
            this.StopOn();
        }
    }
}
