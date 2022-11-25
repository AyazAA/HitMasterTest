using Assets.CodeBase.Services.Input;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAsset _asset;
        private readonly IStaticDataService _dataService;

        public GameFactory(IAsset asset, IStaticDataService dataService)
        {
            _asset = asset;
            _dataService = dataService;
        }

        public GameObject CreateHero(GameObject at, IInputService inputService, StopPoint[] points,
            EnemyGroup[] enemyGroups, ObjectPool bulletPool)        
        {
            var heroData = _dataService.ForHero();
            
            MoveToPoints hero = _asset.Instantiate(AssetPath.HeroPath, at: at.transform.position).GetComponent<MoveToPoints>();
            hero.Construct(inputService, points, enemyGroups, heroData);
            hero.gameObject.GetComponentInChildren<Weapon>().Construct(inputService, bulletPool, heroData);
            var playerAnimationController = new PlayerAnimationController(hero);
            return hero.gameObject;
        }

        public GameObject CreateHud(MoveToPoints hero)
        {
            GameObject hud = _asset.Instantiate(AssetPath.HudPath);

            ProgressBar progressBar = hud.GetComponentInChildren<ProgressBar>();
            progressBar.Construct(hero);
            StartGameInviteText inviteText = hud.GetComponentInChildren<StartGameInviteText>();
            inviteText.Construct(hero);
            return hud;
        }

        public EnemyGroup[] CreateEnemyGroups(GameObject[] ats)
        {
            EnemyGroup[] enemyGroups = new EnemyGroup[ats.Length];
            for (int i = 0; i < ats.Length; i++)
            {
                EnemyGroup enemyGroup = _asset.Instantiate(AssetPath.EnemyGroup, at: ats[i].transform.position)
                    .GetComponent<EnemyGroup>();
                enemyGroups[i] = enemyGroup;
            }
            return enemyGroups;
        }

        public StopPoint[] CreatePointsForPlayer() => 
            _asset.Instantiate(AssetPath.Points).GetComponentsInChildren<StopPoint>();

        public ObjectPool CreateBulletPool() => 
            _asset.Instantiate(AssetPath.BulletPool).GetComponent<ObjectPool>();

        public SceneController CreateSceneController() => 
            _asset.Instantiate(AssetPath.SceneController).GetComponent<SceneController>();
    }
}