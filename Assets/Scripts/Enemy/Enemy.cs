using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy: MonoBehaviour
{
    // Location of this Enemy's spawn point (used to determine patrol route)
    Vector2 spawn;

    // Public variables used to make different enemy types 
    public float patrol_radius, speed, atk_dmg, atk_range, follow_radius;
    
    // Start is called before the first frame update
    void Start()
    {
        spawn = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 getSpawn(){
        return this.spawn;
    }
}
