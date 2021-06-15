using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch
{
   public class Stopwatch
    {

        public TimeSpan CurrentTime { get; private set; }
        public bool IsRunning { get; private set; }
        public Dictionary<string, TimeSpan> Durations { get; private set; } = new Dictionary<string, TimeSpan>();
        public int CounterAttempt { get; private set; } = 0;
        public TimeSpan TimeIncrement { get; private set; } = new TimeSpan();



        public Dictionary<string, TimeSpan> ElapsedTime
        {

            get
            {
                for (int i = CounterAttempt - 1; i < Durations.Count; i++)
                {

                    var item = Durations.ElementAt(i);
                    TimeIncrement += item.Value;
                    Durations[item.Key] = TimeIncrement;

                }

                return Durations;
            }


        }


        public void Start()
        {

            if (IsRunning)
            {

                throw new InvalidOperationException("You cannot start the stopwatch twice");
            }
            CurrentTime = DateTime.Now.TimeOfDay;
            IsRunning = true;
            CounterAttempt++;

        }



        public void Stop()
        {
            if (!IsRunning)
            {
                throw new InvalidOperationException("You cannot stop the watch, you didn't even start it");

            }

            Durations.Add("Attempt " + CounterAttempt, (this.CurrentTime - DateTime.Now.TimeOfDay));
            IsRunning = false;

        }

        public void ShowElapsedTime()
        {

            var elapsed = ElapsedTime;
            for (int i = CounterAttempt - 1; i < elapsed.Count; i++)
            {

                var item = Durations.ElementAt(i);
                Console.WriteLine(item.Key + ":" + item.Value.ToString("h'h 'm'm 's's'"));

            }



        }


    }
}
