using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Gradient gradient;
    public PlayerHealth health;
    public Image fill; 

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = health.maxHealth;
        healthBar.value = health.maxHealth;
    }
    public void SetMaxHealth(int hp)
    {
        healthBar.maxValue = hp;
        healthBar.value = hp;
        fill.color = gradient.Evaluate(1f);
    }
    // Update is called once per frame
    public void SetHealth(int hp)
    {
        healthBar.value = hp;
        fill.color = gradient.Evaluate(healthBar.normalizedValue);
    }
}
