using Domains.Global.SubDomains.Space.Code.Core.Components;
using UnityEngine;

namespace Domains.Global.SubDomains.Space.Code.Visual.Components
{
    public class PlayerInput : IPlayerInput
    {
        public float HorizontalAxis => Input.GetAxisRaw("Horizontal");
        public bool IsAccelerating => Input.GetKey(KeyCode.Space);
        public bool IsPausePressed => Input.GetKeyDown(KeyCode.Escape);
    }
}