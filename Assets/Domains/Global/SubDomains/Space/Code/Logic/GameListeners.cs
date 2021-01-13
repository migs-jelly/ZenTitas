using System;
using System.Collections.Generic;
using Domains.Global.SubDomains.Space.Code.Logic.Listeners;

namespace Domains.Global.SubDomains.Space.Code.Logic
{
    public class GameListeners : IDisposable
    {
        public List<IGameStateListener> GameStateListeners { get; private set; } = new List<IGameStateListener>();
        public List<IDirectionListener> DirectionListeners { get; private set; } = new List<IDirectionListener>();

        public void Dispose()
        {
            GameStateListeners = null;
            DirectionListeners = null;
        }
    }
}