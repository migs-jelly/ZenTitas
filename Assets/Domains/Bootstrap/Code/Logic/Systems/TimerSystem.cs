using System;
using System.Timers;
using Domains.Bootstrap.Code.Logic.Base.Systems;
using Zenject;

namespace Domains.Bootstrap.Code.Logic.Systems
{
    public class TimerSystem : IResolvableInitializeSystem
    {
        private const int MS_IN_SECOND = 1000;
        private const int SECONDS_IN_MINUTE = 60;
        private const int SECONDS_IN_HOUR = 60 * 60;
        
        public int TotalSecondsPassed { get; private set; }
        
        public event Action SecondPassed;
        public event Action MinutePassed;
        public event Action HourPassed;
        
        private Timer _timer;

        public TimerSystem()
        {
            _timer = new Timer(MS_IN_SECOND);
            _timer.Elapsed += TimerOnElapsed;
        }

        public void TearDown()
        {
            _timer.Stop();
            _timer.Elapsed -= TimerOnElapsed;
            _timer = null;
        }

        public void Disable()
        {
            _timer.Stop();
        }

        public void Enable()
        {
            _timer.Start();
        }

        public void ResolveDependencies(DiContainer container)
        {
        }

        public void Initialize()
        {
            _timer.Start();
        }
        

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            TotalSecondsPassed++;
            
            SecondPassed?.Invoke();

            if (TotalSecondsPassed != 0 && TotalSecondsPassed % SECONDS_IN_MINUTE == 0)
            {
                MinutePassed?.Invoke();
            }

            if (TotalSecondsPassed != 0 && TotalSecondsPassed % SECONDS_IN_HOUR == 0)
            {
                HourPassed?.Invoke();
            }
        }
    }
}