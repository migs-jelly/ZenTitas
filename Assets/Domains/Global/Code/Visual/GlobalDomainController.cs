using System;
using System.Collections.Generic;
using Domains.Global.Code.Core.Behavior;
using Domains.Global.Code.Visual.Behavior;
using Domains.Global.Code.Visual.Config;
using Domains.Global.Code.Visual.Helpers;
using Domains.Global.Code.Visual.Interfaces;
using UnityEngine;
using Zenject;
using ILogger = Domains.Global.Code.Core.Behavior.ILogger;

namespace Domains.Global.Code.Visual
{
    public class GlobalDomainController : MonoBehaviour
    {
        [SerializeField] private DomainsConfigReference _domainsConfigReference;

        [Inject] private IDomainService _domainService;
        
        private readonly List<IGameModule> _modules = new List<IGameModule>();

        #region Lifecycle methods

        private async void Start()
        {
            var configs = await _domainsConfigReference.LoadAssetAsync().Task;
            var configReference = configs.GetDomainData("MainMenu").ConfigReference;

            await _domainService.LoadDomain(configReference);
        }

        private void Update()
        {
            _modules.ForEach(m => m.Update());
        }
        
        private void FixedUpdate()
        {
            _modules.ForEach(m => m.FixedUpdate());
        }

        private void LateUpdate()
        {
            _modules.ForEach(m => m.LateUpdate());
        }

        private void OnDestroy()
        {
            _modules.ForEach(m => m.Destroy());
        }

        #endregion
        
        public void AddModule(IGameModule module)
        {
            _modules.Add(module);
            module.InstallBindings();
            module.Start();
        }
    }
}