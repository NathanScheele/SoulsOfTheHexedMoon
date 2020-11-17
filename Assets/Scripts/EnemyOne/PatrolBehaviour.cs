using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    EnemyOne enemy;
    Vector2 spawn, playerPos;
    Vector2[] waypoints;
    int currWaypoint;
    float patrolRadius, speed;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
       enemy = animator.gameObject.GetComponent<EnemyOne>();

       spawn = enemy.getSpawn();

       playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

       patrolRadius = enemy.patrolRadius;
       speed = enemy.speed;

       waypoints = new Vector2[] {new Vector2(spawn.x - patrolRadius, spawn.y), new Vector2(spawn.x + patrolRadius, spawn.y)};

       currWaypoint = Random.Range(0, waypoints.Length);

       animator.SetFloat("distanceToPlayer", Vector2.Distance(animator.transform.position, playerPos));
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        //Patrol
        if(Vector2.Distance(animator.transform.position, waypoints[currWaypoint]) >= 0.2f){
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, waypoints[currWaypoint], speed * Time.deltaTime);
        }
        //Acquire new waypoint
        else{
            currWaypoint = (currWaypoint + 1) % 2;
        }

        animator.SetFloat("distanceToPlayer", Vector2.Distance(animator.transform.position, playerPos));
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
