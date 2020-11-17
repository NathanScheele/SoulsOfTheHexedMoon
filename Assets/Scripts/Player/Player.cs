using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.health == 0){
            Destroy(this.gameObject);
            Debug.Log("Player defeated");
        }
    }

    public void takeDamage(float incomingDmg){
        this.health = Mathf.Max(0, this.health - incomingDmg);
    }
}
