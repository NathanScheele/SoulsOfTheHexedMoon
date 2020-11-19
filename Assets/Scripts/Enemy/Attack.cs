using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Enemy enemy_script;

    Animator animator;
    float last_attack;
    // Start is called before the first frame update
    void Start()
    {
        enemy_script = gameObject.GetComponentInParent<Enemy>();

        animator = gameObject.GetComponentInParent<Animator>();

        last_attack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){

        if(collider.gameObject.tag == "Player"){
            float now = Time.time;
            float elapsed_time = now - last_attack;

            if(elapsed_time >= enemy_script.atk_cooldown){
                last_attack = now;
                Debug.Log("Enemy attacked for " + enemy_script.atk_dmg + " damage.");
            }
        }
    }
}
