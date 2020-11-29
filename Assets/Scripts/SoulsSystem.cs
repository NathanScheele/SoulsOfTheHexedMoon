using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulsSystem : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public Color s1;
    public Color s2;
    public Color s3;
    public Color s4;

    public void IgniteSoul(Color scolor)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (isFull[i] == false)
            {
                //soul is added to UI
                isFull[i] = true;
                slots[i].GetComponent<Image>().color = scolor;
                break;
                
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Purpose"))
        {
            IgniteSoul(s1);
            Destroy(other.gameObject);
        }

        if (other.transform.CompareTag("Existance"))
        {
            IgniteSoul(s2);
            Destroy(other.gameObject);
        }

        if (other.transform.CompareTag("Life"))
        {
            IgniteSoul(s3);
            Destroy(other.gameObject);
        }

        if (other.transform.CompareTag("Moon"))
        {
            IgniteSoul(s4);
            Destroy(other.gameObject);
        }
    }
}

