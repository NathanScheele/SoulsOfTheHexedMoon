using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    GameObject parent;
    PlayerHealth player_script;
    PlayerMovement player_movement;
    Enemy enemy_script;
    bool isPlayer;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;

        if(parent.tag == "Player"){
            player_script = gameObject.GetComponentInParent<PlayerHealth>();
            player_movement = gameObject.GetComponentInParent<PlayerMovement>();
            isPlayer = true;
        }
        else{
            enemy_script = gameObject.GetComponentInParent<Enemy>();
            isPlayer = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other){

        if(isPlayer && other.gameObject.tag == "Enemy"){   //Other must be Enemy

            if(player_movement.howlActivated){
                other.gameObject.GetComponentInParent<Enemy>().takeDmg(9999);
            }
            else{
                other.gameObject.GetComponentInParent<Enemy>().takeDmg(10);
            } 
        }
        else if (!isPlayer && other.gameObject.tag == "Player"){   //Other must be player
            other.gameObject.GetComponentInParent<PlayerHealth>().takeDmg((int)enemy_script.atk_dmg);
        }

       
    }
}
