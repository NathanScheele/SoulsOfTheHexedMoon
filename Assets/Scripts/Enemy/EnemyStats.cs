using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    // Location of this Enemy's spawn point (used to determine patrol route)
    protected Vector2 spawn;
    protected Rigidbody2D m_rigidbody;
    protected Animator m_animator;

    public float atk_range, atk_dmg, atk_spd, health, dir;

    public Rigidbody2D heart;

    protected float last_dmg;

    // Start is called before the first frame update
    void Start()
    {
        spawn = transform.position;

        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        m_animator = gameObject.GetComponent<Animator>();

        dir = -1;

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
        Rigidbody2D rb = Instantiate(heart, transform.position, new Quaternion());

        rb.AddForce(new Vector2(Random.Range(-1,1), Random.Range(0.5f,1)).normalized * 750);
        Destroy(gameObject);
    }


    public Vector2 getSpawn(){
        return this.spawn;
    }
}
