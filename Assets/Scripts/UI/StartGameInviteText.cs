using TMPro;
using UnityEngine;

public class StartGameInviteText : MonoBehaviour
{
    private MoveToPoints _moveToPoints;
    private TMP_Text _inviteText;

    public void Construct(MoveToPoints moveToPoints)
    {
        _inviteText = GetComponent<TMP_Text>();
        _moveToPoints = moveToPoints;
        _moveToPoints.OnPointChanged += TextHide;
    }

    private void OnDestroy()
    {
        _moveToPoints.OnPointChanged -= TextHide;
    }

    private void TextHide(int currentPoint, int amountPoints)
    {
        if(currentPoint == 1)
        {
            _inviteText.gameObject.SetActive(false);
        }
    }
}
