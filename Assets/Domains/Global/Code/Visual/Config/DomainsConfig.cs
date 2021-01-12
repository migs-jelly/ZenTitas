using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domains.Global.Code.Visual.Helpers;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Domains.Global.Code.Visual.Config
{
    [CreateAssetMenu(fileName = "DomainsConfig", menuName = "SkyRoads/Config/Domains Config")]
    public class DomainsConfig : ScriptableObject
    {
        public DomainData[] Domains;

        public DomainData GetDomainData(string domainName)
        {
            return Domains.FirstOrDefault(d => d.Name == domainName);
        }

        public async Task<DomainConfig> LoadDomainConfig(string domainName)
        {
            var data = GetDomainData(domainName);
            return await data.ConfigReference.LoadAssetAsync().Task;
        }
        
        [System.Serializable]
        public class DomainData
        {
            public string Name;
            public DomainConfigReference ConfigReference;
        }
    }
}