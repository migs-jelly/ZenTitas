using System.Collections.Generic;
using Domains.Global.SubDomains.Game.Code.Logic.Listeners;

namespace Domains.Global.SubDomains.Game.Code.Logic
{
    public class GameListeners
    {
        public List<IGameStateListener> GameStateListeners { get; } = new List<IGameStateListener>();
    }
}