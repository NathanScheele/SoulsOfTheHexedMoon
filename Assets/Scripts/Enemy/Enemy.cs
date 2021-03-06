﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Location of this Enemy's spawn point (used to determine patrol route)
    protected Vector2 spawn;
    protected Rigidbody2D m_rigidbody;
    protected Animator m_animator;

    public float atk_range, pursuit_range, atk_dmg, atk_spd,  health;

    //Blood particle effect
    public GameObject effect;
    //Heart drop
    public GameObject heart;

    protected float last_dmg;

    Vector3 forward = new Vector3(-1,0,0);

    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.position;

        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        m_animator = gameObject.GetComponent<Animator>();
        
        last_dmg = 0;
    }

        public void takeDmg(float incoming_dmg){
        float elapsed_time = Time.time - last_dmg;

        if(elapsed_time > 1){
            health = Mathf.Max(0, health - incoming_dmg);
        }

        if(health == 0){
            m_animator.SetBool("isDead",true);
        }
    }
    public void die(){
        //Spawns particles and heart on bunny death
        Instantiate(heart, transform.position, Quaternion.identity);
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }


    public Vector2 getSpawn(){
        return this.spawn;
    }

    public void TurnTowards(Vector3 target){
        if(transform.position.x < target.x){
            if(transform.rotation.y != 180){
                transform.rotation = Quaternion.Euler(0,180,0);
            }
        }
        else{
            if(transform.rotation.y != 0){
                transform.rotation = Quaternion.Euler(0,0,0);
            }
        }
    }
}
