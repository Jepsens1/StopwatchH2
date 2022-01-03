using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopwatchH2
{
    public class Timer
    {
        Stopwatch stopwatch = new Stopwatch();
        public bool IsFinished { get; set; } = false;
        public int Count { get; private set; } = 0;
        public void StartTimer()
        {
            stopwatch.Start();
        }
        public int GetRemaningTimeLeft(int number)
        {
            if (stopwatch.Elapsed.Minutes == number)
            {
                IsFinished = true;
                TimerFinished();
                return number * 60;
            }
            else
            {
                Count++;
                return Count;
            }
        }
        public void StopTimer()
        {
            stopwatch.Stop();
        }
        public int ShowElapsedTime()
        {
            return stopwatch.Elapsed.Seconds;
        }
        public void TimerFinished()
        {
            stopwatch.Stop();
        }
    }
}
