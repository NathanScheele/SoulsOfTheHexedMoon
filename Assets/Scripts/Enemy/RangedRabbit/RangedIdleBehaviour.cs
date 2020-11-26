using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedIdleBehaviour : StateMachineBehaviour
{

    GameHandler game_handler_script;

    RangedRabbit enemy_script;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       game_handler_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();

       enemy_script = animator.GetComponent<RangedRabbit>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       float distance_to_player = Vector2.Distance(animator.transform.position, game_handler_script.getPlayerPos());

       if(distance_to_player <= enemy_script.pursuit_range){
           animator.SetBool("isAttacking", true);
       }
    }
}
