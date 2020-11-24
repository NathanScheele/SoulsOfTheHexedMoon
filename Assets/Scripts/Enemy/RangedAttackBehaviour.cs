using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttackBehaviour : StateMachineBehaviour
{   
    GameHandler game_handler_script;
    Enemy enemy_script;
    Vector2 player_pos;

    float last_atk = 0;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        game_handler_script = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameHandler>();

        enemy_script = animator.GetComponent<Enemy>();

        player_pos = game_handler_script.getPlayerPos();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player_pos = game_handler_script.getPlayerPos();

        //Just turns around :)
        enemy_script.MoveTowards(player_pos); 

        float elapsed_time = Time.time - last_atk;

        if(elapsed_time > 1f){
            enemy_script.RangedAttack();
            last_atk = Time.time;
        }

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    
}
