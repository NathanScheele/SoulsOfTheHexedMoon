using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Slider howlSlider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth( int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetMinHowl(int howl)
    {
        howlSlider.minValue = howl;
        howlSlider.value = howl;
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }


    public void SetHowl(int howl)
    {
        howlSlider.value = howl;
    }
}
