using Domains.Bootstrap.SubDomains.Space.Code.Core.Services;
using UnityEngine;

namespace Domains.Bootstrap.SubDomains.Space.Code.Visual.Components
{
    public class PlayerInputService : IPlayerInputService
    {
        public float HorizontalAxis => Input.GetAxisRaw("Horizontal");
        public bool IsAccelerating => Input.GetKey(KeyCode.Space);
        public bool IsPausePressed => Input.GetKeyDown(KeyCode.Escape);
        
        public void Dispose()
        {
            
        }
    }
}