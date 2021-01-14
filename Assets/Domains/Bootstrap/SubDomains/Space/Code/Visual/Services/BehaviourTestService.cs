using System;
using System.Timers;
using Domains.Bootstrap.SubDomains.Space.Code.Core.Services;
using UnityEngine;
using Zenject;
using ILogger = Domains.Bootstrap.Code.Core.Behavior.ILogger;

namespace Domains.Bootstrap.SubDomains.Space.Code.Visual.Services
{
    public class BehaviourTestService : MonoBehaviour, IBehaviourTestService
    {
        [Inject] private ILogger _logger;
        
        private Timer _timer;

        private void Awake()
        {
            _timer = new Timer(500);
            _timer.Elapsed += TimerOnElapsed;
            _timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            _logger.Log("Timer tick");
        }

        public void DoSomeStuff()
        {
            
        }

        public void Dispose()
        {
            _timer.Stop();
            _timer.Elapsed -= TimerOnElapsed;
            _timer = null;
        }
    }
}