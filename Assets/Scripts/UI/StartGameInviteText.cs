using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class StartGameInviteText : MonoBehaviour
{
    private MoveToPoints _moveToPoints;
    private TMP_Text _inviteText;

    public void Construct(MoveToPoints moveToPoints)
    {
        _inviteText = GetComponent<TMP_Text>();
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
