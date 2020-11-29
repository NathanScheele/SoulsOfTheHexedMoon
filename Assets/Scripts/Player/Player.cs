using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;

    float last_dmg;
    // Start is called before the first frame update
    void Start()
    {
        last_dmg = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDmg(float incoming_dmg){
        float elapsed_time = Time.time - last_dmg;

        if(elapsed_time > 1){
            health = Mathf.Max(0, health - incoming_dmg);
        }
    }
}
