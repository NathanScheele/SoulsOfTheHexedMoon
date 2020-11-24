﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    // Location of this Enemy's spawn point (used to determine patrol route)
    Vector2 spawn;
    
    Rigidbody2D m_rigidbody;
    Animator m_animator;


    // Public variables used to make different enemy types 
    public float l_patrol_dist, r_patrol_dist, speed, atk_range, health;
    public int atk_dmg;
    public bool view_LoS, view_patrol_area;
    public float dir;
    public Rigidbody2D carrot, heart;

    float last_dmg;
    
    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.position;

        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        m_animator = gameObject.GetComponent<Animator>();

        dir = -1;

        last_dmg = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RangedAttack(){
        Rigidbody2D carrot_clone = (Rigidbody2D) Instantiate(carrot, transform.position, transform.rotation);
         
        carrot_clone.velocity = dir * transform.right * 5f;
    }

    public Vector2 getSpawn(){
        return this.spawn;
    }

    public void MoveTowards(Vector2 target){

        //Make sure you're facing the target
        if(target.x < transform.position.x && dir == 1){
            transform.Rotate(new Vector3(0,180,0));
            dir *= -1;
        }
        else if(target.x > transform.position.x && dir == -1){
            transform.Rotate(new Vector3(0,180,0));
            dir *= -1;
        }

        Vector2 direction = new Vector2(target.x - transform.position.x, 0).normalized;
        m_rigidbody.velocity = new Vector2(direction.x * speed, m_rigidbody.velocity.y);

    }

    void OnDrawGizmos(){
        if(view_patrol_area){
            Gizmos.color = Color.blue;

            Vector2 left = -transform.right * l_patrol_dist;
            Vector2 right = transform.right * r_patrol_dist;

            if(spawn == new Vector2()){
                Gizmos.DrawRay(transform.position, left);
                Gizmos.DrawRay(transform.position, right);
            }
            else{
                Gizmos.DrawRay(spawn, left);
                Gizmos.DrawRay(spawn, right);
            }        
        }
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
        //TODO
        //Actually spawn item
        Debug.Log("Bloody Heart dropped");

        Instantiate(heart);

        Destroy(gameObject);
    }
}
