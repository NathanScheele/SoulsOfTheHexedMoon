using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : StateMachineBehaviour
{
    GameHandler game_handler_script;
    BasicBunny enemy_script;
    Vector2 player_pos;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        game_handler_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();

        enemy_script = animator.GetComponent<BasicBunny>();

        player_pos = game_handler_script.getPlayerPos();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player_pos = game_handler_script.getPlayerPos();
        float distance_to_player =  Vector2.Distance(animator.transform.position, player_pos);

        // Check for state changes
        if(distance_to_player <= enemy_script.atk_range){ // Attack!
            animator.SetBool("isAttacking", true);
        }
        else if(distance_to_player > 6){
            animator.SetBool("isFollowing", false);
        }
        else{ // Continue following
                enemy_script.MoveTowards(player_pos);
        } 
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    
}
