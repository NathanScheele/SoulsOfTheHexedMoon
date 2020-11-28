using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    GameObject player;
    Vector2 player_pos;
    BasicBunny enemy_script;
    Rigidbody2D m_rigidbody;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player = GameObject.FindGameObjectWithTag("Player");

        player_pos = player.transform.position;

        enemy_script = animator.gameObject.GetComponent<BasicBunny>();

        m_rigidbody = animator.gameObject.GetComponent<Rigidbody2D>();

        m_rigidbody.velocity = new Vector2(0, 0);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player_pos = player.transform.position;
        float distance_to_player = Vector2.Distance(animator.transform.position, player_pos);

        enemy_script.TurnTowards(player_pos);

        // Check for state changes
        if (distance_to_player >= enemy_script.atk_range)
        { // Start following
            animator.SetBool("isAttacking", false);
        }
    }


}
