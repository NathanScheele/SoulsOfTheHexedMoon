using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Enemy enemy_script;
    const float cooldown = 0.5f;

    float last_attack;
    // Start is called before the first frame update
    void Start()
    {
        enemy_script = gameObject.GetComponentInParent<Enemy>();
        last_attack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){

        if(collider.CompareTag("player")){
            float now = Time.time;
            float elapsed_time = now - last_attack;

            if(elapsed_time >= 0.75){
                last_attack = now;
                Debug.Log("Enemy attacked for " + enemy_script.atk_dmg + " damage.");
            }
        }
    }
}
