using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;
    bool hurt;
    public HealthBar healthBar;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(curHealth == 0)
        {
            //player dead, stops movement
            player.moving = false;
        }
    }

    public void DamagePlayer(int damage)
    {
        curHealth -= damage;

        healthBar.SetHealth(curHealth);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy1"))
        {
            //Hurts player, takes away HP
            DamagePlayer(20);

        }
        /*
        if (other.gameObject.CompareTag("Enemy2"))
        {
            //Hurts player, takes away more HP
            DamagePlayer(40);
        }

        if (other.gameObject.CompareTag("Enemy3"))
        {
            //Hurts player, takes away HP
            DamagePlayer(15);
        }
        */
    }
   
}
