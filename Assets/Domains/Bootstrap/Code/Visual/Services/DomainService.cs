using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domains.Bootstrap.Code.Visual.Config;
using Domains.Bootstrap.Code.Visual.Helpers;
using Domains.Bootstrap.Code.Visual.Interfaces;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using Zenject;

namespace Domains.Bootstrap.Code.Visual.Services
{
    public class DomainService : IDomainService
    {
        [Inject] private DiContainer _container;
        
        private readonly ConcurrentStack<SceneInstance> _newDomainScenes = new ConcurrentStack<SceneInstance>();
        private readonly ConcurrentStack<SceneInstance> _loadedDomainScenes = new ConcurrentStack<SceneInstance>();

        private bool _isLoading;

        public async Task LoadDomain(string domainName)
        {
            var config = _container.ResolveId<DomainConfig>(domainName);
            await LoadDomain(config);
        }

        public async Task LoadDomain(DomainConfig config)
        {
            if (_isLoading)
            {
                throw new Exception("Domain loading is in progress, can't load more than one at a time");
            }

            _isLoading = true;

            var loadTasks = new List<Task>
            {
                LoadScene(config.MainScene)
            };

            if(config.DependecyScenes != null && config.DependecyScenes.Length > 0)
            {
                foreach (var scene in config.DependecyScenes)
                {
                    loadTasks.Add(LoadScene(scene));
                }
            }

            await Task.WhenAll(loadTasks);

            var activationTasks = new List<Task>();

            foreach (var scene in _loadedDomainScenes)
            {
                activationTasks.Add(Addressables.UnloadSceneAsync(scene).Task);
            }
            
            foreach (var scene in _newDomainScenes)
            {
                activationTasks.Add(scene.ActivateAsync().ConfigureAwait());
            }

            await Task.WhenAll(activationTasks);
            
            _loadedDomainScenes.Clear();
            _loadedDomainScenes.PushRange(_newDomainScenes.ToArray());
            _newDomainScenes.Clear();

            _isLoading = false;
        }

        private async Task LoadScene(AssetReference sceneReference)
        {
            var scene = await sceneReference.LoadSceneAsync(LoadSceneMode.Additive, false).Task;
            _newDomainScenes.Push(scene);
        }
    }
}