using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;

    float last_dmg;
    bool hurt;
    public HealthBar healthBar;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;

        last_dmg = 0;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        if (curHealth == 0)
        {
            //player dead, stops movement
            player.playing = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
    public void takeDmg(int incoming_dmg)
    {
        float elapsed_time = Time.time - last_dmg;

        if (elapsed_time > 1)
        {
            curHealth = Mathf.Max(0, curHealth - incoming_dmg);
            healthBar.SetHealth(curHealth);
        }
    }
}
