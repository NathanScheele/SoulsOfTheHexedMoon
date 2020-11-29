using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaucusHealth : MonoBehaviour
{
    public int curHealth = 0;
    public int maxHealth = 100;

    public DaucusHB health;
    public DaucusScript daucus;
   

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void IncreaseBlood(int life)
    {
        curHealth -= life;

        health.SetBlood(curHealth);
    }

  
}
