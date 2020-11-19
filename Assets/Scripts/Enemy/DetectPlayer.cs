using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        m_animator = gameObject.GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider){
        m_animator.SetBool("isFollowing", true);
    }

    void OnTriggerExit2D(Collider2D collider){
        m_animator.SetBool("isFollowing", false);
    }
}
