using CodeBase.Infrastructure.States;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private MoveToPoints _moveToPoints;
    private GameStateMachine _stateMachine;
    private bool IsFinished;

    public void Construct(GameStateMachine stateMachine, MoveToPoints moveToPoints)
    {
        _moveToPoints = moveToPoints;
        _stateMachine = stateMachine;
        _moveToPoints.FinishPointReached += OnFinishPointReached;
    }

    private void OnDisable()
    {
        _moveToPoints.FinishPointReached -= OnFinishPointReached;
    }

    private void OnFinishPointReached()
    {
        if(IsFinished)
            return;
        
        _stateMachine.Enter<BootstrapState>();
        IsFinished = true;
    }
}