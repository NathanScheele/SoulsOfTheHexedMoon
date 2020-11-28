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
            meterFull = true;
            player.howlReady = true;
            if (Input.GetKeyDown(KeyCode.L))
            {
                IncreaseBlood(-100);
            }
        }
       else if(curBlood == 0)
        {
            meterFull = false;
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
                IncreaseBlood(50);
            }
           
        }
    }
}
