using Domains.Bootstrap.SubDomains.Space.Code.Logic;
using Domains.Bootstrap.SubDomains.Space.Code.Logic.Listeners;
using UnityEngine;
using Zenject;

namespace Domains.Bootstrap.SubDomains.Space.Code.Visual.Behavior
{
    public class CubeController : MonoBehaviour, IDirectionListener
    {
        [SerializeField] private float _speed = 2f;

        [Inject] private GameListeners _listeners;
        
        private float _direction = 0;

        private void Start()
        {
            _listeners.DirectionListeners.Add(this);
        }

        private void Update()
        {
            //Pretend that you don't see this shit code - it's not relevant to the task ^___^
            var x = transform.position.x;
            var newX = Mathf.Lerp(x, x + (_direction * _speed), Time.deltaTime);
            var destination = new Vector3(newX, transform.position.y, transform.position.z);
            transform.position = destination;
        }

        private void OnDestroy()
        {
            _listeners?.DirectionListeners?.Remove(this);
        }

        public void OnDirectionChanged(float direction)
        {
            _direction = direction;
        }
    }
}