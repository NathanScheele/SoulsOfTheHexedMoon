using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaucusHealth : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;

    public DaucusHB health;
    public DaucusScript daucus;
    public PlayerMovement player;
    public GameObject soul;

    public bool gettingHurt;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.daucusHurt)
        {
            IncreaseBlood(100);
            Debug.Log(curHealth);
            player.daucusHurt = false;
        }

        if(curHealth <= 0)
        {
             Instantiate(soul, transform.position, new Quaternion());

            Destroy(gameObject); 
        }
    }

    public void IncreaseBlood(int life)
    {
        curHealth -= life;

        health.SetBlood(curHealth);
    }

  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DHitBox"))
        {
           // gettingHurt = true;
           // Debug.Log("Daucus Hurt");
        }
    } 
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //gettingHurt = true;
           // Debug.Log("Daucus not Hurt");
        }
    }
}
