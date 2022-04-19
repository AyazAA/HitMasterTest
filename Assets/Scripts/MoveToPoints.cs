using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MoveToPoints: MonoBehaviour 
{
    public event Action<int, int> OnPointChanged;
    private Transform[] _points;
    private EnemyGroup[] _enemyGroups;
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;
    private int _currentPoint = 0;
    private bool _enemyGroupdDead = false;
    private string _runAnimationName = "isRunning";
    private string _pointTag = "StopPoint";

    public void Construct(Transform[] points, EnemyGroup[] enemyGroups)
    {
        _points = points;
        _enemyGroups = enemyGroups;
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator.SetBool(_runAnimationName, false);
        for (int i = 0; i < _enemyGroups.Length; i++)
        {
            _enemyGroups[i].OnEnemyGroupDead += GroupDead;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _enemyGroups.Length; i++)
        {
            _enemyGroups[i].OnEnemyGroupDead -= GroupDead;
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
                Input.GetMouseButtonDown(0))
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
            _animator.SetBool(_runAnimationName, true);
            _navMeshAgent.SetDestination(_points[_currentPoint++].position);
            OnPointChanged?.Invoke(_currentPoint, _points.Length);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(_pointTag))
        {
            _animator.SetBool(_runAnimationName, false);
            if(_currentPoint == _points.Length)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    private void GroupDead()
    {
        _enemyGroupdDead = true;
    }
}
