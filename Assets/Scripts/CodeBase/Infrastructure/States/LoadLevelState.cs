using Assets.CodeBase.Services.Input;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string EnemyGroupPointTag = "EnemyGroupPoint";
        private const string InitialPointTag = "InitialPoint";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly AllServices _services;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain,
            IGameFactory gameFactory, AllServices services)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _services = services;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
        }

        public void Exit() =>
            _curtain.Hide();

        private void OnLoaded()
        {
            InitWorld();

            _stateMachine.Enter<GameLoopState>();
        }

        private void InitWorld()
        {
            EnemyGroup[] enemyGroups = InitEnemyGroups();

            StopPoint[] stopPoints = InitStopPoints();

            MoveToPoints hero = InitHero(enemyGroups, stopPoints);

            _gameFactory.CreateHud(hero);

            InitSceneController(hero);
        }

        private EnemyGroup[] InitEnemyGroups()
        {
            GameObject[] enemyGroupPoints = GameObject.FindGameObjectsWithTag(EnemyGroupPointTag);
            return _gameFactory.CreateEnemyGroups(enemyGroupPoints);
        }

        private StopPoint[] InitStopPoints() => 
            _gameFactory.CreatePointsForPlayer();

        private MoveToPoints InitHero(EnemyGroup[] enemyGroups, StopPoint[] stopPoints)
        {
            ObjectPool bulletPool = _gameFactory.CreateBulletPool();

            MoveToPoints hero = _gameFactory.CreateHero(GameObject.FindWithTag(InitialPointTag),
                    _services.Single<IInputService>(),
                    stopPoints,
                    enemyGroups,
                    bulletPool)
                .GetComponent<MoveToPoints>();
            
            CameraFollowInit(hero.gameObject);
            
            return hero;
        }

        private void CameraFollowInit(GameObject target)
        {
            Camera.main.GetComponent<CameraController>().Construct(target.transform);
        }

        private void InitSceneController(MoveToPoints hero)
        {
            SceneController sceneController = _gameFactory.CreateSceneController();
            sceneController.Construct(_stateMachine, hero);
        }
    }
}