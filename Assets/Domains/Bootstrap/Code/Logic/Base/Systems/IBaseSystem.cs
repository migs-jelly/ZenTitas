using Entitas;

namespace Domains.Bootstrap.Code.Logic.Base.Systems
{
    public interface IBaseSystem : ITearDownSystem
    {
        /// <summary>
        /// Disabling the system
        /// </summary>
        void Disable();
        /// <summary>
        /// Enabling the system
        /// </summary>
        void Enable();
    }
}