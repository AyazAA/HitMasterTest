using System;
using Assets.CodeBase.Services.Input;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class MoveToPoints : MonoBehaviour
{
    public event Action<int, int> PointChanged;
    public event Action PointReached;
    public event Action FinishPointReached;
    
    [SerializeField] private NavMeshAgent _navMeshAgent;
    private StopPoint[] _points;
    private EnemyGroup[] _enemyGroups;
    private int _currentPoint = 0;
    private bool _enemyGroupDead = false;
    private IInputService _inputService;

    public void Construct(IInputService inputService, StopPoint[] points, EnemyGroup[] enemyGroups, HeroStaticData heroData)
    {
        _inputService = inputService;
        _points = points;
        _enemyGroups = enemyGroups;
        _navMeshAgent.speed = heroData.Speed;
        for (int i = 0; i < _enemyGroups.Length; i++)
        {
            _enemyGroups[i].EnemyGroupDead += OnEnemyGroupDead;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _enemyGroups.Length; i++)
        {
            _enemyGroups[i].EnemyGroupDead -= OnEnemyGroupDead;
        }
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    private void MoveToNextPoint()
    {
        if (_currentPoint == 0)
        {
            if (_navMeshAgent.velocity == Vector3.zero &&
                _inputService.IsTapToScreen())
            {
                Move();
            }
        }
        else
        {
            if (_navMeshAgent.velocity == Vector3.zero &&
                _enemyGroupDead)
            {
                Move();
                _enemyGroupDead = false;
            }
        }
    }

    private void Move()
    {
        if (_currentPoint < _points.Length)
        {
            _navMeshAgent.SetDestination(_points[_currentPoint++].transform.position);
            PointChanged?.Invoke(_currentPoint, _points.Length);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<StopPoint>(out var stopPoint))
        {
            PointReached?.Invoke();
            if (_currentPoint == _points.Length)
            {
                FinishPointReached?.Invoke();
            }
        }
    }

    private void OnEnemyGroupDead()
    {
        _enemyGroupDead = true;
    }
}
