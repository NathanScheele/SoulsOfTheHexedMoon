using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    public float increase;
    PlayerMovement playerScript;

    void Start()
    {
        increase = 1.5f;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject player = collision.gameObject;
            playerScript = player.GetComponent<PlayerMovement>();

            if (playerScript)
            {
                playerScript.jumpSpeed *= increase;
                SpriteRenderer sprender = gameObject.GetComponent<SpriteRenderer>();
                CircleCollider2D coll = gameObject.GetComponent<CircleCollider2D>();
                sprender.enabled = false;
                coll.enabled = false;
                StartCoroutine(PowerUpCountdownRoutine());
            }
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        Debug.Log("Powerupcountdown");
        yield return new WaitForSeconds(5);
        playerScript.jumpSpeed /= increase;
        Destroy(gameObject);
    }
}
