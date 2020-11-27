using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedRabbit : Enemy
{   
    public Rigidbody2D carrot;

    public void RangedAttack(){
        Rigidbody2D carrot_clone = (Rigidbody2D) Instantiate(carrot, transform.position, transform.rotation);

        float angle = transform.eulerAngles.y - 90;

        carrot_clone.transform.rotation = Quaternion.Euler(0,0,angle);

        carrot_clone.velocity = -transform.right * 5f;
    }
}
