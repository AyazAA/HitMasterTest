using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour 
{
    private MoveToPoints _moveToPoints;
    private Slider _progressSlider;

    public void Construct(MoveToPoints moveToPoints)
    {
        _moveToPoints = moveToPoints;
        _moveToPoints.OnPointChanged += ProgressBarUpdate;
    }

    private void Start()
    {
        _progressSlider = GetComponent<Slider>();
    }

    private void OnDestroy()
    {
        _moveToPoints.OnPointChanged -= ProgressBarUpdate;
    }

    private void ProgressBarUpdate(int currentPoint, int amountPoints)
    {
        _progressSlider.value = (float)currentPoint / amountPoints;
    }
}