using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    // Location of this Enemy's spawn point (used to determine patrol route)
    Vector2 spawn;

    Animator m_animator;

    Rigidbody2D m_rigidbody;

    GameObject line_of_sight_obj;

    SpriteRenderer m_renderer;

    // Public variables used to make different enemy types 
    public float patrol_radius, speed, atk_dmg, atk_range, atk_cooldown, los_w, los_h, health;
    
    // Start is called before the first frame update
    void Start()
    {
        spawn = gameObject.transform.position;

        m_animator = gameObject.GetComponent<Animator>();
        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();


        line_of_sight_obj = transform.GetChild(1).gameObject;

        m_renderer = line_of_sight_obj.GetComponent<SpriteRenderer>();

        line_of_sight_obj.transform.localScale = new Vector3(los_h, los_w, line_of_sight_obj.transform.localScale.z);

        m_renderer.color = new Color(m_renderer.color.r, m_renderer.color.g, m_renderer.color.b, 0);
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
