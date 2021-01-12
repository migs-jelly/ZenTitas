using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domains.Global.Code.Visual.Config;
using Domains.Global.Code.Visual.Helpers;
using Domains.Global.Code.Visual.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

namespace Domains.Global.Code.Visual.Behavior
{
    public class DomainService : IDomainService
    {
        private readonly ConcurrentStack<SceneInstance> _newDomainScenes = new ConcurrentStack<SceneInstance>();
        private readonly ConcurrentStack<SceneInstance> _loadedDomainScenes = new ConcurrentStack<SceneInstance>();
        

        private bool _isLoading;
        
        public async Task LoadDomain(DomainConfigReference domainConfigReference)
        {
            if (_isLoading)
            {
                throw new Exception("Domain loading is in progress, can't load more than one at a time");
            }

            _isLoading = true;
            
            var config = await domainConfigReference.LoadAssetAsync().Task;

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