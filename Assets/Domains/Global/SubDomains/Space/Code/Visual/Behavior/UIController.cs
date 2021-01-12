using Domains.Global.SubDomains.Space.Code.Logic;
using Domains.Global.SubDomains.Space.Code.Logic.Helpers;
using Domains.Global.SubDomains.Space.Code.Logic.Listeners;
using EntitasData.Domains.Space;
using UnityEngine;
using Zenject;
using ILogger = Domains.Global.Code.Core.Behavior.ILogger;

namespace Domains.Global.SubDomains.Space.Code.Visual.Behavior
{
    public class UIController : MonoBehaviour, IGameStateListener
    {
        [SerializeField] private GameObject _startGameButton;

        [Inject] private DiContainer _container;
        
        private Contexts _contexts;
        private GameListeners _listeners;
        private ILogger _logger;
        
        private bool _isGameStarted;

        private void Start()
        {
            _contexts = _container.Resolve<Contexts>();
            _listeners = _container.Resolve<GameListeners>();
            _logger = _container.Resolve<ILogger>();
            
            _listeners.GameStateListeners.Add(this);
        }

        public void OnGameStartClick()
        {
            _contexts.game.StartGame();
        }

        private void OnDestroy()
        {
            _listeners.GameStateListeners.Remove(this);
        }

        public void OnGameStateChanged(GameState state)
        {
            if (state.IsRunning)
            {
                _isGameStarted = true;
                _startGameButton.SetActive(false);
            }
            else
            {
                if(_isGameStarted)
                {
                    //Show pause menu
                    _logger.Log("Pause Menu requested");
                }
                else
                {
                    _contexts.game.StartGame();
                }
            }
            
        }
    }
}