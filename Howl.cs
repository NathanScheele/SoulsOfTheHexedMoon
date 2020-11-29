using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Howl : MonoBehaviour
{
    public int curBlood = 0;
    public int maxBlood = 100;

    public HowlMeter howlMeter;
    public PlayerMovement player;
    bool meterFull;
    public bool addBlood;

    // Start is called before the first frame update
    void Start()
    {
        curBlood = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
       if(curBlood == 100)
        {
            Debug.Log("Meter Full");
            meterFull = true;
            player.howlReady = true;
            if (Input.GetKeyDown(KeyCode.L) && player.OnGround)
            {
                IncreaseBlood(-100);
            }
        }
       else if(curBlood == 0)
        {
            meterFull = false;
        }
        if (addBlood)
        {
            IncreaseBlood(50);
            Debug.Log(curBlood);
            addBlood = false;
        }
    }

    public void IncreaseBlood(int blood)
    {
        curBlood += blood;

        howlMeter.SetBlood(curBlood);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Heart"))
        {
            if (!meterFull)
            {
                other.gameObject.SetActive(false);
                addBlood = true;
            }
           
        }

       // if(other.gameObject.CompareTag())
    }
}
