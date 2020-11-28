using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackBehaviour : StateMachineBehaviour
{
    GameObject player;
    RangedRabbit enemy_script;
    Vector3 player_pos;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");

        player_pos = player.transform.position;

        enemy_script = animator.GetComponent<RangedRabbit>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player_pos = player.transform.position;

        float distance_to_player = Vector2.Distance(player_pos, animator.transform.position);

        enemy_script.TurnTowards(player_pos);

        if (distance_to_player > enemy_script.pursuit_range)
        {
            animator.SetBool("isAttacking", false);
        }

    }

}
