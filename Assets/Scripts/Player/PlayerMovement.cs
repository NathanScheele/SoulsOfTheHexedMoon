using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public GameObject text, moreText;
    public float speed;
    public float jumpSpeed = 8;
    public float jumpTime = 1f;
    public float timeSinceAttack = .5f;

    public bool playing;
    public bool moving;
    public bool howlReady;
    public bool daucusHurt;
    bool facingRight = true;
    bool startAttackTime;
    public bool OnGround;
    bool jTimeStart;
    bool enemyClose;
    public CircleCollider2D cCollider;
    Rigidbody2D rb;
    Animator anim;
    Vector3 localScale;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playing = true;
        moving = true;
        enemyClose = false;
        localScale = transform.localScale;
        OnGround = true;

    }

    // Update is called once per frame
    void Update()
    {
        float hMove = Input.GetAxis("Horizontal");
       
        if (playing)
        {
            if (moving)
            {
                // Moves player left or right
                rb.velocity = new Vector2(hMove * speed, rb.velocity.y);
                rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
                rb.constraints &= ~RigidbodyConstraints2D.FreezePositionX;

                if (hMove > 0)
                {
                    anim.SetBool("Run", true);
                    facingRight = true;
                }
                else if (hMove < 0)
                {
                    anim.SetBool("Run", true);
                    facingRight = false;
                }
                else if (hMove == 0)
                {
                    anim.SetBool("Run", false);
                }
                if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
                {
                    localScale.x *= -1;
                }
                transform.localScale = localScale;
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            Jump();
            Attack();
        }

        if(OnGround == false)
        {
            anim.SetBool("OnGround", OnGround);
        }
        if(OnGround)
        {
            anim.SetBool("OnGround", OnGround);
        }
        

    }

    void Jump()
    {
        //if user presses spacebar and only if player is grounded, player jumps
        if (Input.GetKeyDown(KeyCode.Space) &&  OnGround && jTimeStart == false)
        {
            anim.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            //text.SetActive(false); // disables text
            jTimeStart = true; // start next jump time
            OnGround = false;
            Debug.Log("Jumping");
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
            anim.SetTrigger("Bite");
            timeSinceAttack = .5f;
            startAttackTime = true;

        }

        //hurts enemy when in range and attacks
        if(Input.GetKeyDown(KeyCode.J) && enemyClose)
        {
            daucusHurt = true;
        }
        
        if (Input.GetKeyDown(KeyCode.K) && timeSinceAttack == 0)
        {
            anim.SetTrigger("Scratch");
            Debug.Log("Attack2");
            timeSinceAttack = .5f;
            startAttackTime = true;
        }
        if(Input.GetKeyDown(KeyCode.K) && enemyClose)
        {
            daucusHurt = true;
        }
        if (howlReady)
        {
            cCollider.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.L) && timeSinceAttack == 0 &&  OnGround && howlReady )
        {
            //Stops player movement for 1.5f 
            anim.SetTrigger("Howl");
            moving = false;
            //moreText.SetActive(false);
            Debug.Log("ULTIMATE HOWL!");
            timeSinceAttack = 1.5f;
            startAttackTime = true;
            howlReady = false;
            if (enemyClose)
            {
                daucusHurt = true;
                Debug.Log("Daucus hurt");
            }
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

        if (other.gameObject.CompareTag("DHurtBox"))
        {
            enemyClose = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Ground"))
        {
            OnGround = false;
        }

        if (other.gameObject.CompareTag("DHurtBox"))
        {
            enemyClose = false;
        }
    }
}
