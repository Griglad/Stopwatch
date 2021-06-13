using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stopwatch
{
    class Stopwatch
    {

        public TimeSpan CurrentTime { get; private set; }
        private bool _isRunning;
        private Dictionary<string, TimeSpan> _durations = new Dictionary<string, TimeSpan>();
        private int _counterAttempt = 0;
        private TimeSpan _timeIncrement = new TimeSpan();


    
        public Dictionary<string, TimeSpan> ElapsedTime
        {

            get
            {
                for (int i = _counterAttempt - 1; i < _durations.Count; i++)
                {

                    var item = _durations.ElementAt(i);
                    _timeIncrement += item.Value;
                    _durations[item.Key] = _timeIncrement;

                }

                return _durations;
            }


        }


        public void Start()
        {

            if (_isRunning)
            {

                throw new InvalidOperationException("You cannot start the stopwatch twice");
            }
            CurrentTime = DateTime.Now.TimeOfDay;
            _isRunning = true;
            _counterAttempt++;

        }



        public void Stop()
        {
            if (!_isRunning)
            {
                throw new InvalidOperationException("You cannot stop the watch, you haven't even start it");

            }

            _durations.Add("Attempt " + _counterAttempt, (this.CurrentTime - DateTime.Now.TimeOfDay));
            _isRunning = false;

        }

        public void ShowElapsedTime()
        {

            var elapsed = ElapsedTime;
            for (int i = _counterAttempt - 1; i < elapsed.Count; i++)
            {

                var item = _durations.ElementAt(i);
                Console.WriteLine(item.Key + ":" + item.Value.ToString("h'h 'm'm 's's'"));

            }



        }


    }
}
