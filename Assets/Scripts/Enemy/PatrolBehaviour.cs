using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    GameHandler game_handler_script;
    Enemy enemy_script;
    Vector2 spawn, player_pos;
    float patrol_radius, speed;
    Vector2[] waypoints;
    int currWaypoint;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    
        game_handler_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();

        enemy_script = animator.gameObject.GetComponent<Enemy>();

        spawn = enemy_script.getSpawn();

        player_pos = game_handler_script.getPlayerPos();

        patrol_radius = enemy_script.patrol_radius;
        speed = enemy_script.speed;

        waypoints = new Vector2[] {new Vector2(spawn.x - patrol_radius, spawn.y), new Vector2(spawn.x + patrol_radius, spawn.y)};

        currWaypoint = Random.Range(0, waypoints.Length);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        player_pos = game_handler_script.getPlayerPos();
        float distance_to_player = Vector2.Distance(animator.transform.position, player_pos);

        if(distance_to_player <= enemy_script.follow_radius){ // Start following
            Debug.Log("Starting to Follow");
            animator.SetBool("isFollowing", true);
        }
        else{//Patrol
            if(Vector2.Distance(animator.transform.position, waypoints[currWaypoint]) >= 0.2f){ // Continue to waypoint
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, waypoints[currWaypoint], speed * Time.deltaTime);
            }
            else{//Acquire new waypoint
                currWaypoint = (currWaypoint + 1) % 2;
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
