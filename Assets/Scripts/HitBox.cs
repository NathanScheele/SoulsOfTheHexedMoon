using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    GameObject parent;
    PlayerHealth player_script;
    EnemyStats enemy_script;
    bool isPlayer;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;

        if(parent.tag == "Player"){
            player_script = gameObject.GetComponentInParent<PlayerHealth>();
            isPlayer = true;
        }
        else{
            enemy_script = gameObject.GetComponentInParent<EnemyStats>();
            isPlayer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){

        if(isPlayer && other.gameObject.tag == "Enemy"){   //Other must be Enemy
            int outgoing_dmg = 10;

            Debug.Log("Here");
            other.gameObject.GetComponentInParent<EnemyStats>().takeDmg(outgoing_dmg);
        }
        else if (!isPlayer && other.gameObject.tag == "Player"){   //Other must be player
            other.gameObject.GetComponentInParent<PlayerHealth>().takeDmg((int)enemy_script.atk_dmg);
        }
    }
}
