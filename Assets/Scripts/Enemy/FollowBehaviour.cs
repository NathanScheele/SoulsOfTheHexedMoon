using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : StateMachineBehaviour
{
    GameHandler game_handler_script;
    Enemy enemy_script;
    Vector2 player_pos;

    Rigidbody2D rigidbody;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        game_handler_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();

        enemy_script = animator.GetComponent<Enemy>();

        player_pos = game_handler_script.getPlayerPos();

        rigidbody = animator.gameObject.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player_pos = game_handler_script.getPlayerPos();
        float distance_to_player =  Vector2.Distance(animator.transform.position, player_pos);

        // Check for state changes
        if(distance_to_player <= enemy_script.atk_range){ // Attack!
            animator.SetBool("isAttacking", true);
        }
        else{ // Continue following

            float y_angle = player_pos.x < animator.transform.position.x ? 0 : 180;

            animator.transform.eulerAngles = new Vector3(0, y_angle, 0);

            float direction = animator.transform.position.x > player_pos.x ? -1 : 1;

            rigidbody.velocity = new Vector2(direction * enemy_script.speed, rigidbody.velocity.y);
        } 
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
