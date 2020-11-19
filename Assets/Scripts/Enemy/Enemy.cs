using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    // Location of this Enemy's spawn point (used to determine patrol route)
    Vector2 spawn;

    Animator m_animator;

    Rigidbody2D m_rigidbody;

    // Public variables used to make different enemy types 
    public float patrol_radius, speed, atk_dmg, atk_range, atk_cooldown, follow_radius, health;
    
    // Start is called before the first frame update
    void Start()
    {
        spawn = gameObject.transform.position;

        m_animator = gameObject.GetComponent<Animator>();
        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 getSpawn(){
        return this.spawn;
    }

    public void takeDmg(float incoming_dmg){

        health = health - incoming_dmg < 0 ? 0 : health - incoming_dmg;

        if(health == 0){
            m_animator.SetBool("isDead", true);
        }
    }
}
