using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class MoveToPoints : MonoBehaviour
{
    public event Action<int, int> PointChanged;
    public event Action PointReached;
    public event Action FinishPointReached;
    private Transform[] _points;
    private EnemyGroup[] _enemyGroups;
    private NavMeshAgent _navMeshAgent;
    private int _currentPoint = 0;
    private bool _enemyGroupdDead = false;

    public void Construct(Transform[] points, EnemyGroup[] enemyGroups)
    {
        _points = points;
        _enemyGroups = enemyGroups;
        _navMeshAgent = GetComponent<NavMeshAgent>();
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
                (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
            {
                Move();
            }
        }
        else
        {
            if (_navMeshAgent.velocity == Vector3.zero &&
                _enemyGroupdDead)
            {
                Move();
                _enemyGroupdDead = false;
            }
        }
    }

    private void Move()
    {
        if (_currentPoint < _points.Length)
        {
            _navMeshAgent.SetDestination(_points[_currentPoint++].position);
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
        _enemyGroupdDead = true;
    }
}
