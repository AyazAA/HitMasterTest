using CodeBase.Infrastructure.States;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public LoadingCurtain Curtain;
        private Game _game;
        private static GameBootstrapper Instance;

        private void Awake()
        {
            if (GameBootstrapper.Instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this;
            
            _game = new Game(this, Curtain);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}