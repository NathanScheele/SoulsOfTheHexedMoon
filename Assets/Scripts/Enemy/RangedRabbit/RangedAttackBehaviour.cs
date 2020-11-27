using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackBehaviour : StateMachineBehaviour
{   
    GameHandler game_handler_script;
    RangedRabbit enemy_script;
    Vector3 player_pos;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        game_handler_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();

        enemy_script = animator.GetComponent<RangedRabbit>();

        player_pos = game_handler_script.getPlayerPos();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player_pos = game_handler_script.getPlayerPos();

        float distance_to_player = Vector2.Distance(player_pos, animator.transform.position);

        enemy_script.TurnTowards(player_pos);
        
        if(distance_to_player > enemy_script.pursuit_range){
            animator.SetBool("isAttacking", false);
        }
        
    }
    
}
