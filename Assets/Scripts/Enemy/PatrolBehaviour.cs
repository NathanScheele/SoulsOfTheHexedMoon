using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    Enemy enemy_script;
    Vector2 spawn;
    float patrol_radius, speed;
    Vector2[] waypoints;
    int currWaypoint;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy_script = animator.gameObject.GetComponent<Enemy>();

        spawn = enemy_script.getSpawn();

        speed = enemy_script.speed;

        waypoints = new Vector2[] {new Vector2(spawn.x - enemy_script.l_patrol_dist, 1000f), new Vector2(spawn.x + enemy_script.l_patrol_dist, 1000f)};

        currWaypoint = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        //IMPORTANT: Transition to Follow State is updated by the Enemy's LineOfSight Component

        //Patrol
        if(Mathf.Abs(animator.transform.position.x - waypoints[currWaypoint].x) >= 0.2f){ // Continue to waypoint
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
