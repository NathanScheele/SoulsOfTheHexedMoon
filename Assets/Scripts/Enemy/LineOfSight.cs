using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{

    public float depth, height;

    //Components
    Animator m_animator;
    Enemy enemy_script = null;

    // Start is called before the first frame update
    void Start()
    {

        enemy_script = gameObject.GetComponentInParent<Enemy>();

        transform.localScale = new Vector3(depth, height, transform.localScale.z);

        m_animator = gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            m_animator.SetBool("isFollowing", true);
        }
    }

    void OnTriggerExit2D(Collider2D collider){
        if(collider.gameObject.tag == "Player"){
            m_animator.SetBool("isFollowing", false);
        }
    }

    void OnDrawGizmos(){

        if(enemy_script == null){
            enemy_script = transform.GetComponentInParent<Enemy>();
        }

        if(enemy_script.view_LoS){
            Gizmos.color = Color.green;
            Vector2 top = new Vector2(transform.TransformDirection(enemy_script.dir * transform.right).x * depth, 0.5f * height);
            Vector2 bottom = new Vector2(transform.TransformDirection(enemy_script.dir * transform.right).x * depth, -0.5f * height);
            Gizmos.DrawRay(transform.position, top);
            Gizmos.DrawRay(transform.position, bottom);
        }
    }
}
