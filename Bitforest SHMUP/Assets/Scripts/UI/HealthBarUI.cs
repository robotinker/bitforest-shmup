using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : AppResourceMonoBehaviour
{
    SuperSlider Slider;

    void Start()
    {
        Slider = GetComponentInChildren<SuperSlider>();
        if (PlayerHealth != null)
        {
            PlayerHealth.OnChange += HandleHealthChange;
        }
    }

    void HandleHealthChange(float newHealth)
    {
        if (Slider == null)
            return;

        Slider.Value = newHealth;
    }
}
