using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class EnemyHealthUI : MonoBehaviour 
{
    [SerializeField] private BaseEnemy _enemy;
    private Slider _barSlider;

    private void Start()
    {
        _barSlider = GetComponent<Slider>();
        _enemy.HealthChanged += HealthChangeUI;
    }

    private void OnDestroy()
    {
        _enemy.HealthChanged -= HealthChangeUI;
    }

    private void HealthChangeUI(float currentHealthPercent)
    {
        _barSlider.value = currentHealthPercent;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

