using System;
using Domains.Global.SubDomains.Space.Code.Logic;
using Domains.Global.SubDomains.Space.Code.Logic.Listeners;
using UnityEngine;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Visual.Behavior
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
            var x = transform.position.x;
            var newX = Mathf.Lerp(x, x + (_direction * _speed), Time.deltaTime);
            var destination = new Vector3(newX, transform.position.y, transform.position.z);
            transform.position = destination;
        }

        private void OnDestroy()
        {
            _listeners.DirectionListeners.Remove(this);
        }

        public void OnDirectionChanged(float direction)
        {
            _direction = direction;
        }
    }
}