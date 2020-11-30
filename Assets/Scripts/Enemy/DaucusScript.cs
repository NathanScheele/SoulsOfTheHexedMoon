using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaucusScript : MonoBehaviour
{
    // Location of this Enemy's spawn point (used to determine patrol route)
    protected Rigidbody2D m_rigidbody;
    protected Animator anim;

    public Transform Character;

    public Rigidbody2D heart;

    public GameObject soul;
    private Vector3 directionOfCharacter;

    public float speed;
    public float tTime = 1;
    int numPicked;
    public bool startTime;
    public float timeForTel = 3;
    public bool telTime;
    public bool moving;
    public bool facingRight;
    public bool pickNum;
    public Transform position1, pos2, pos3, pos4, pos5;
    Vector3 localScale;

    // Start is called before the first frame update
    void Start()
    {

        m_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        localScale = transform.localScale;
        moving = true;
        telTime = true;
        pickNum = true;
    }

    void Update()
    {
             
        if (moving)
        {
            //or teleports when player gets close but can only teleport three times before charging up
            Teleport();
            directionOfCharacter = Character.transform.position - transform.position;
            directionOfCharacter = directionOfCharacter.normalized;    // Get Direction to Move Towards
            transform.Translate(directionOfCharacter * speed * Time.deltaTime, Space.World);
            anim.SetBool("Moving", true);
        }
       
        //anim.SetTrigger("Attack");
        if (Character.transform.position.x > transform.position.x)
        {
            facingRight = false;
        }
        else
        {
            facingRight = true;
        }

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;

    }

    void RandomPick()
    {
        if (pickNum)
        {
            int randomNumber = Random.Range(1, 5);
            if(randomNumber == 1)
            {
                numPicked = 1;
            } if(randomNumber == 2)
            {
                numPicked = 2;
            } if(randomNumber == 3)
            {
                numPicked = 3;
            } if(randomNumber == 4)
            {
                numPicked = 4;
            } if(randomNumber == 5)
            {
                numPicked = 5;
            } 
            Debug.Log(randomNumber);
            pickNum = false;
            
        }
       
        
    }

    void Teleport()
    {
        if(telTime &&  timeForTel > 0)
        {
            timeForTel -= Time.deltaTime;
        }
        if(timeForTel < 0)
        {
            startTime = true;
            anim.SetTrigger("Teleport");
            timeForTel = 3;
            RandomPick();
            pickNum = true;
        }

        if(startTime && tTime > 0)
        {
            tTime -= Time.deltaTime;
        }

        if(tTime < 0)
        {
            if(numPicked == 1)
            {
                transform.position = position1.position;
            }
            if (numPicked == 2)
            {
                transform.position = pos2.position;
            }
            if (numPicked == 3)
            {
                transform.position = pos3.position;
            }
            if (numPicked == 4)
            {
                transform.position = pos4.position;
            }
            if (numPicked == 5)
            {
                transform.position = pos5.position;
            }
            startTime = false;
            tTime = 1f;
        }
    }
    public void die()
    {
        Rigidbody2D rb = Instantiate(heart, transform.position, new Quaternion());

        Instantiate(soul,transform.position, new Quaternion());
        rb.AddForce(new Vector2(Random.Range(-1, 1), Random.Range(0.5f, 1)).normalized * 750);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Attack", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Attack", false);
        }
    }

}
