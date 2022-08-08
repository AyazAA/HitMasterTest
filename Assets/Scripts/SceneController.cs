using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private MoveToPoints _moveToPoints;
    private const string SceneName = "Demo";

    public void Construct(MoveToPoints moveToPoints)
    {
        _moveToPoints = moveToPoints;
        _moveToPoints.FinishPointReached += OnFinishPointReached;
    }

    private void OnDisable()
    {
        _moveToPoints.FinishPointReached -= OnFinishPointReached;
    }

    private void OnFinishPointReached()
    {
        SceneManager.LoadScene(SceneName);
    }
}