using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOne : MonoBehaviour
{
    Vector2 spawn;

    public float patrolRadius, speed, health, atkDamage, atkCoolDown;
    
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

    public void takeDamage(float incomingDmg){
        this.health = Mathf.Max(0, this.health - incomingDmg);
    }
}
