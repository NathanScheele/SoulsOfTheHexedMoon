using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : StateMachineBehaviour
{
    Rigidbody2D rigidbody;
    GameHandler game_handler_script;
    Enemy enemy_script;
    Vector2 spawn, player_pos;
    float patrol_radius, speed;
    Vector2[] waypoints;
    int currWaypoint;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigidbody = animator.gameObject.GetComponent<Rigidbody2D>();

        game_handler_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();

        enemy_script = animator.gameObject.GetComponent<Enemy>();

        spawn = enemy_script.getSpawn();

        player_pos = game_handler_script.getPlayerPos();

        patrol_radius = enemy_script.patrol_radius;
        speed = enemy_script.speed;

        waypoints = new Vector2[] {new Vector2(spawn.x - patrol_radius, 1000f), new Vector2(spawn.x + patrol_radius, 1000f)};

        currWaypoint = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        player_pos = game_handler_script.getPlayerPos();
        float distance_to_player = Vector2.Distance(animator.transform.position, player_pos);

        if(distance_to_player <= enemy_script.follow_radius){ // Start following
            animator.SetBool("isFollowing", true);
        }
        else{//Patrol
            if(Mathf.Abs(animator.transform.position.x - waypoints[currWaypoint].x) >= 0.2f){ // Continue to waypoint
                float direction = animator.transform.position.x > waypoints[currWaypoint].x ? -1 : 1;

                rigidbody.velocity = new Vector2(direction * speed, rigidbody.velocity.y);
            }
            else{//Acquire new waypoint
                currWaypoint = (currWaypoint + 1) % 2;

                float y_angle = animator.transform.rotation.y == 0 ? 180 : 0;

                animator.transform.eulerAngles = new Vector3(0, y_angle, 0);
            }
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
