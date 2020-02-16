using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSound : MonoBehaviour
{
    AudioManager aM;
    void Start()
    {
        aM = FindObjectOfType<AudioManager>();
    }
    public void PlaySound(int sonido)
    {
        aM.PlaySound(sonido);
    }

}
