using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour 
{
    [SerializeField] private Slider _progressSlider;
    private MoveToPoints _moveToPoints;

    public void Construct(MoveToPoints moveToPoints)
    {
        _moveToPoints = moveToPoints;
        _moveToPoints.PointChanged += ProgressBarUpdate;
    }

    private void OnDestroy()
    {
        _moveToPoints.PointChanged -= ProgressBarUpdate;
    }

    private void ProgressBarUpdate(int currentPoint, int amountPoints)
    {
        _progressSlider.value = (float)currentPoint / amountPoints;
    }
}