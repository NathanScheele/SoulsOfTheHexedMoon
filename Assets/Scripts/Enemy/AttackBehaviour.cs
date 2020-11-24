using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    GameHandler game_handler_script;
    Vector2 player_pos;
    Enemy enemy_script;

    Rigidbody2D m_rigidbody;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        game_handler_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();

        player_pos = game_handler_script.getPlayerPos();

        enemy_script = animator.gameObject.GetComponent<Enemy>();

        m_rigidbody = animator.gameObject.GetComponent<Rigidbody2D>();

        m_rigidbody.velocity = new Vector2(0,0);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player_pos = game_handler_script.getPlayerPos();
        float distance_to_player = Vector2.Distance(animator.transform.position, player_pos);

        // Check for state changes
        if(distance_to_player >= enemy_script.atk_range){ // Start following
            animator.SetBool("isAttacking", false);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
