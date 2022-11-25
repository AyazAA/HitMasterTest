using Assets.CodeBase.Services.Input;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        public GameObject CreateHero(GameObject at, IInputService inputService, StopPoint[] points,
            EnemyGroup[] enemyGroups, ObjectPool bulletPool);
        public GameObject CreateHud(MoveToPoints hero);
        public EnemyGroup[] CreateEnemyGroups(GameObject[] ats);
        public StopPoint[] CreatePointsForPlayer();
        public ObjectPool CreateBulletPool();
        public SceneController CreateSceneController();
    }
}
