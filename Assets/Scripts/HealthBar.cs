using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider healthBarSlider;

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        healthBarSlider.value = currentValue / maxValue;
    }
}
