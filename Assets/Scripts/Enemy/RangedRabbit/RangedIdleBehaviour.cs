using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedIdleBehaviour : StateMachineBehaviour
{

    GameObject player;
    Vector2 player_pos;

    RangedRabbit enemy_script;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player");
        
        player_pos = player.transform.position;

       enemy_script = animator.GetComponent<RangedRabbit>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       float distance_to_player = Vector2.Distance(animator.transform.position, player_pos);

       if(distance_to_player <= enemy_script.pursuit_range){
           animator.SetBool("isAttacking", true);
       }
    }
}
