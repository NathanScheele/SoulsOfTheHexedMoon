﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float increase;
    PlayerMovement playerScript;

    void Start()
    {
        increase = 2f;
    }
    
    void Update()
    {
        // Spin the object around the target at 20 degrees/second.
        transform.RotateAround(gameObject.transform.position, Vector3.forward, 40 * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameObject player = collision.gameObject;
            playerScript = player.GetComponent<PlayerMovement>();

            if(playerScript)
            {
                playerScript.speed *= increase;
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
        yield return new WaitForSeconds(5);
        playerScript.speed /= increase;
        Destroy(gameObject);
    }
}
