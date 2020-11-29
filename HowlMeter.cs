using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowlMeter : MonoBehaviour
{
    public Slider howlBar;
    public Howl playerBlood;

    private void Start()
    {
        playerBlood = GameObject.FindGameObjectWithTag("Player").GetComponent<Howl>();
        howlBar = GetComponent<Slider>();
        howlBar.maxValue = playerBlood.maxBlood;
        howlBar.value = playerBlood.curBlood;
    }

    public void SetBlood(int hp)
    {
        howlBar.value = hp;
    }
}
