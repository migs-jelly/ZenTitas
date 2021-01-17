using System;
using System.Timers;
using Domains.Bootstrap.Code.Logic.Base.Systems;
using Zenject;

namespace Domains.Bootstrap.Code.Logic.Systems
{
    public class TimerSystem : IBootstrapResolvableInitializeSystem
    {
        public const int DEFAULT_INTERVAL_IN_SECONDS = 1;
        private const int MS_IN_SECOND = 1000;

        public double IntervalInSeconds
        {
            get => _timer.Interval / MS_IN_SECOND;
            set => _timer.Interval = value * MS_IN_SECOND;
        }
        
        public event Action Tick;
        
        private Timer _timer;

        public TimerSystem()
        {
            _timer = new Timer(DEFAULT_INTERVAL_IN_SECONDS * MS_IN_SECOND);
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
            Tick?.Invoke();
        }
    }
}