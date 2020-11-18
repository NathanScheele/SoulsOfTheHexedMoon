using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : StateMachineBehaviour
{
    GameHandler game_handler_script;
    Enemy enemy_script;
    Vector2 player_pos;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        game_handler_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();

        enemy_script = animator.GetComponent<Enemy>();

        player_pos = game_handler_script.getPlayerPos();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player_pos = game_handler_script.getPlayerPos();
        float distance_to_player =  Vector2.Distance(animator.transform.position, player_pos);
        Debug.Log(player_pos);
        // Check for state changes
        if(distance_to_player > enemy_script.follow_radius){ // Player too far away; resume patrol
            Debug.Log("Starting to Patrol");
            animator.SetBool("isFollowing",false);
        }
        else if(distance_to_player <= enemy_script.atk_range){ // Attack!
            Debug.Log("Starting to Attack");
            animator.SetBool("isAttacking", true);
        }
        else{ // Continue following
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, player_pos, enemy_script.speed * Time.deltaTime);
        } 
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
