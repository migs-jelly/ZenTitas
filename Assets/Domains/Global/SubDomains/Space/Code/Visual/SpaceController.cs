using System;
using Domains.Global.Code.Visual;
using UnityEngine;
using Zenject;

namespace Domains.Global.SubDomains.Space.Code.Visual
{
    public class SpaceController : MonoBehaviour
    {
        [Inject] private DiContainer _container;
        [Inject] private SpaceModule _module;

        private void Start()
        {
            _module.Start();
        }

        private void Update()
        {
            _module.Update();
        }

        private void OnDestroy()
        {
            _module.Destroy();
        }
    }
}