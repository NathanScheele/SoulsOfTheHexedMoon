using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    GameObject parent;
    PlayerHealth player_script;
    Enemy enemy_script;
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
            enemy_script = gameObject.GetComponentInParent<Enemy>();
            isPlayer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(isPlayer){   //Other must be Enemy
            int outgoing_dmg = 10;
            other.gameObject.GetComponentInParent<Enemy>().takeDmg(outgoing_dmg);
        }
        else{   //Other must be player
            int outgoing_dmg = enemy_script.atk_dmg;
            other.gameObject.GetComponentInParent<PlayerHealth>().takeDmg(outgoing_dmg);
        }
    }
}
