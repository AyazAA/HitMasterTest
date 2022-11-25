using TMPro;
using UnityEngine;

public class StartGameInviteText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _inviteText;
    private MoveToPoints _moveToPoints;

    public void Construct(MoveToPoints moveToPoints)
    {
        _moveToPoints = moveToPoints;
        _moveToPoints.PointChanged += TextHide;
    }

    private void OnDestroy()
    {
        _moveToPoints.PointChanged -= TextHide;
    }

    private void TextHide(int currentPoint, int amountPoints)
    {
        if(currentPoint != 0)
        {
            _inviteText.gameObject.SetActive(false);
        }
    }
}
