namespace Domains.Global.Code.Core.Behavior
{
    public interface IGameModule
    {
        
        
        void InstallBindings();
        void Start();
        void Update();
        void FixedUpdate();
        void LateUpdate();
        void Destroy();
    }
}