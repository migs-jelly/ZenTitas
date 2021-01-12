using System.Collections.Generic;
using Domains.Global.SubDomains.Space.Code.Logic.Listeners;

namespace Domains.Global.SubDomains.Space.Code.Logic
{
    public class GameListeners
    {
        public List<IGameStateListener> GameStateListeners { get; } = new List<IGameStateListener>();
        public List<IDirectionListener> DirectionListeners { get; } = new List<IDirectionListener>();
    }
}