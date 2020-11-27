using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    BasicBunny enemy_script;
    Vector2 spawn;
    float speed;
    Vector2[] waypoints;
    int currWaypoint;

    GameObject player;

    Vector2 player_pos;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy_script = animator.gameObject.GetComponent<BasicBunny>();

        spawn = enemy_script.getSpawn();

        speed = enemy_script.speed;

        waypoints = new Vector2[] {new Vector2(spawn.x - enemy_script.l_patrol_dist, 1000f), new Vector2(spawn.x + enemy_script.l_patrol_dist, 1000f)};

        currWaypoint = 0;

        player = GameObject.FindGameObjectWithTag("Player");
        
        player_pos = player.transform.position;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        float distance_to_player = Vector2.Distance(animator.transform.position, player_pos);
        if(distance_to_player <= enemy_script.pursuit_range){
            animator.SetBool("isFollowing", true);
        }
        //Patrol
        else if(Mathf.Abs(animator.transform.position.x - waypoints[currWaypoint].x) >= 0.2f){ // Continue to waypoint
            enemy_script.MoveTowards(waypoints[currWaypoint]);
        }
        else{//Acquire new waypoint
            currWaypoint = (currWaypoint + 1) % 2;
        }
    
    }
    

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
