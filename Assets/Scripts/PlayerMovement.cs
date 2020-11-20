using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject text, moreText;
    public float speed;
    public float jumpSpeed = 8;
    float jumpTime = 1f;
    public float timeSinceAttack = 1.5f;

    bool moving;
    bool startAttackTime;
    public bool OnGround;
    bool jTimeStart;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        float hMove = Input.GetAxis("Horizontal");
        if (moving)
        {
            // Moves player left or right
            rb.velocity = new Vector2(hMove * speed, rb.velocity.y);
        }

        Jump();
        Attack();

    }

    void Jump()
    {
        //if user presses spacebar and only if player is grounded, player jumps
        if (Input.GetKeyDown(KeyCode.Space) && OnGround && jTimeStart == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            text.SetActive(false); // disables text
            jTimeStart = true; // start next jump time
        }

        if (jTimeStart && jumpTime > 0)
        {
            jumpTime -= Time.deltaTime;
        }

        if (jumpTime < 0)
        {
            jTimeStart = false;
            jumpTime = 1;
        }
    }
    
    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.J) && timeSinceAttack == 0)
        {
            Debug.Log("Attack1");
            timeSinceAttack = 1.5f;
            startAttackTime = true;

        }
        
        if (Input.GetKeyDown(KeyCode.K) && timeSinceAttack == 0)
        {
            Debug.Log("Attack2");
            timeSinceAttack = 1.5f;
            startAttackTime = true;
        }
        
        if (Input.GetKeyDown(KeyCode.L) && timeSinceAttack == 0 &&  OnGround)
        {
            //Stops player movement for 1.5f 
            moving = false;
            moreText.SetActive(false);
            Debug.Log("ULTIMATE HOWL!");
            timeSinceAttack = 1.5f;
            startAttackTime = true;
        }

        if(startAttackTime && timeSinceAttack > 0)
        {
            timeSinceAttack -= Time.deltaTime;
        }

        if(timeSinceAttack < 0)
        {
            startAttackTime = false;
            moving = true;
            timeSinceAttack = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = true;
        }

        /*
        if (other.gameObject.CompareTag("Enemy1"))
        {
            //Hurts player, takes away HP
        }
        
        if (other.gameObject.CompareTag("Enemy2"))
        {
            //Hurts player, takes away more HP
        }
        
        if (other.gameObject.CompareTag("Enemy3"))
        {
            //Hurts player, takes away HP
        }
        */

    }

    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }
    }
}
