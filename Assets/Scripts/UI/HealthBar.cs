using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider healthBarSlider;

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        healthBarSlider.value = currentValue / maxValue;
    }
}
