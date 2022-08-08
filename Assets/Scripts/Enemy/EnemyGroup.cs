using System;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    public event Action EnemyGroupDead;
    [SerializeField] private BaseEnemy[] _enemies;
    private int _enemyCount;

    private void OnEnable()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].Died += EnemyDied;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].Died -= EnemyDied;
        }
    }

    private void Start()
    {
        _enemyCount = _enemies.Length;
    }

    private void EnemyDied()
    {
        _enemyCount--;
        if (_enemyCount <= 0)
        {
            EnemyGroupDead?.Invoke();
        }
    }
}
