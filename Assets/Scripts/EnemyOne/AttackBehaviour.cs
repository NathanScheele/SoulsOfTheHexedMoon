using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    EnemyOne enemy;
    GameObject player;
    Player playerScript;
    Vector2 playerPos;

    float lastAttack;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       enemy = animator.gameObject.GetComponent<EnemyOne>();
       player = GameObject.FindGameObjectWithTag("Player");
       playerScript = player.GetComponent<Player>();
       playerPos = player.transform.position;
       lastAttack = 0f;

       animator.SetFloat("distanceToPlayer", Vector2.Distance(animator.transform.position, playerPos));
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       float elapsedTime = Time.time - lastAttack;

       if(elapsedTime >= enemy.atkCoolDown){
           playerScript.takeDamage(enemy.atkDamage);
           Debug.Log("EnemyOne attacked Player for " + enemy.atkDamage + " damage.");
           lastAttack = Time.time;
       }
        
        animator.SetFloat("distanceToPlayer", Vector2.Distance(animator.transform.position, player.gameObject.transform.position));
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
