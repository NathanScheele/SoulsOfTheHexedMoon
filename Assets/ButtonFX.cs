using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    public AudioSource Fx;
    public AudioClip hoverFx;
    public AudioClip playClickFx;
    public AudioClip clickFx;

    public void HoverSound()
    {
        Fx.PlayOneShot(hoverFx);
    }
    public void PlayClickSound()
    {
        Fx.PlayOneShot(playClickFx);
    }

    public void ClickSound()
    {
        Fx.PlayOneShot(clickFx);
    }
}
