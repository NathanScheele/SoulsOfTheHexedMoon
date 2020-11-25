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
    GameHandler game_handler_script;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy_script = animator.gameObject.GetComponent<BasicBunny>();

        spawn = enemy_script.getSpawn();

        speed = enemy_script.speed;

        waypoints = new Vector2[] {new Vector2(spawn.x - enemy_script.l_patrol_dist, 1000f), new Vector2(spawn.x + enemy_script.l_patrol_dist, 1000f)};

        currWaypoint = 0;

        game_handler_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        float distance_to_player = Vector2.Distance(animator.transform.position, game_handler_script.getPlayerPos());
        if(distance_to_player <= 6){
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
