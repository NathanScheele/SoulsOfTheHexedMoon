using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehaviour : StateMachineBehaviour
{
    EnemyOne enemy;
    Vector2 playerPos;
    float speed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

       enemy = animator.GetComponent<EnemyOne>();

       speed = enemy.speed;

       animator.SetFloat("distanceToPlayer", Vector2.Distance(animator.transform.position, playerPos));
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        
       animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos, speed * Time.deltaTime);

       animator.SetFloat("distanceToPlayer", Vector2.Distance(animator.transform.position, playerPos));
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
