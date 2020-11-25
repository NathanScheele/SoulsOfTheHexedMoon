using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBunny: EnemyStats
{
    
    // Public variables used to make different enemy types 
    public float l_patrol_dist, r_patrol_dist, speed;
    public bool view_patrol_area;

    public void MoveTowards(Vector2 target){

        //Make sure you're facing the target
        if(target.x < transform.position.x && dir == 1){
            transform.Rotate(new Vector3(0,180,0));
            dir *= -1;
        }
        else if(target.x > transform.position.x && dir == -1){
            transform.Rotate(new Vector3(0,180,0));
            dir *= -1;
        }

        Vector2 direction = new Vector2(target.x - transform.position.x, 0).normalized;
        m_rigidbody.velocity = new Vector2(direction.x * speed, m_rigidbody.velocity.y);
    }

    void OnDrawGizmos(){
        if(view_patrol_area){
            Gizmos.color = Color.blue;

            Vector2 left = -transform.right * l_patrol_dist;
            Vector2 right = transform.right * r_patrol_dist;

            if(this.spawn == new Vector2()){
                Gizmos.DrawRay(transform.position, left);
                Gizmos.DrawRay(transform.position, right);
            }
            else{
                Gizmos.DrawRay(spawn, left);
                Gizmos.DrawRay(spawn, right);
            }        
        }
    }

}
