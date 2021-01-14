using Domains.Bootstrap.Code.Visual.Config;
using UnityEditor;
using UnityEngine.AddressableAssets;

namespace Domains.Bootstrap.Code.Visual.Helpers
{
    [System.Serializable]
    public class SceneAssetReference : AssetReferenceT<SceneAsset>
    {
        public SceneAssetReference(string guid) : base(guid){}
    }
    
    [System.Serializable]
    public class DomainConfigReference : AssetReferenceT<DomainConfig>
    {
        public DomainConfigReference(string guid) : base(guid){}
    }
    
    [System.Serializable]
    public class DomainsConfigReference : AssetReferenceT<DomainsConfig>
    {
        public DomainsConfigReference(string guid) : base(guid){}
    }
}