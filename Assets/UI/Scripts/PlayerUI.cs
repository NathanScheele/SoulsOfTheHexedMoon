using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public int maxHealth = 100;
    public int minHowl = 0;
    public int currentHealth;
    public int currentHowl;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentHowl = minHowl;
        healthBar.SetMinHowl(minHowl);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            GainHowl(1);
        }

    }

    void TakeDamage (int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void GainHowl(int gain)
    {
        currentHowl += gain;
        healthBar.SetHowl(currentHowl);
    }
}
