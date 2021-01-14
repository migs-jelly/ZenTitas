using UnityEngine;
using Zenject;

namespace Domains.Bootstrap.SubDomains.Space.Code.Visual
{
    public class SpaceController : MonoBehaviour
    {
        [Inject] private SpaceModule _module;

        private void Start()
        {
            _module.Init();
        }

        private void Update()
        {
            _module.Execute();
        }

        private void OnDestroy()
        {
            _module.Destroy();
        }
    }
}