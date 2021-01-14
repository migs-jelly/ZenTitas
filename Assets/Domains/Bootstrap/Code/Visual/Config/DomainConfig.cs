using Domains.Bootstrap.Code.Visual.Helpers;
using UnityEngine;

namespace Domains.Bootstrap.Code.Visual.Config
{
    [CreateAssetMenu(fileName = "DomainConfig", menuName = "SkyRoads/Config/Domain Config")]
    public class DomainConfig : ScriptableObject
    {
        //TODO: Convert from string to auto-generated enum/const
        public string Name;
        public SceneAssetReference MainScene;
        public SceneAssetReference[] DependecyScenes;
    }

}