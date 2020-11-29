using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DaucusHB : MonoBehaviour
{
    public Slider dHealthBar;
    public DaucusHealth dHealth;

    private void Start()
    {
        dHealth = GameObject.FindGameObjectWithTag("Daucus").GetComponent<DaucusHealth>();
        dHealthBar = GetComponent<Slider>();
        dHealthBar.maxValue = dHealth.maxHealth;
        dHealthBar.value = dHealth.curHealth ;
    }

    public void SetBlood(int hp)
    {
        dHealthBar.value = hp;
    }
}
