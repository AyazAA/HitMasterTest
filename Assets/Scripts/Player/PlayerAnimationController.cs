using UnityEngine;

public class PlayerAnimationController
{
    private Animator _animator;
    private MoveToPoints _moveToPoints;
    private const string RunAnimationName = "isRunning";


    public PlayerAnimationController(MoveToPoints moveToPoints)
    {
        _animator = moveToPoints.GetComponent<Animator>();
        _moveToPoints = moveToPoints;
        _moveToPoints.PointChanged += OnPointChanged;
        _moveToPoints.PointReached += OnPointReached;
        _animator.SetBool(RunAnimationName, false);
    }

    ~PlayerAnimationController()
    {
        _moveToPoints.PointChanged -= OnPointChanged;
        _moveToPoints.PointReached -= OnPointReached;
    }

    private void OnPointChanged(int a, int b)
    {
        _animator.SetBool(RunAnimationName, true);
    }

    private void OnPointReached()
    {
        _animator.SetBool(RunAnimationName, false);
    }
}
