using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour 
{
    [SerializeField] private BaseEnemy _enemy;
    private Slider _barSlider;

    private void Start()
    {
        _barSlider = GetComponent<Slider>();
        _enemy.OnHealthChanged += HealthChangeUI;
    }

    private void OnDestroy()
    {
        _enemy.OnHealthChanged -= HealthChangeUI;
    }

    private void HealthChangeUI(float currentHealth, float maxHealth)
    {
        _barSlider.value = (currentHealth / maxHealth);
    }
}

