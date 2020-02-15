using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public AudioClip[] clips;
    public AudioSource[] aSources;
    int currenSource;

    public void PlaySound(int clip)
    {
        aSources[currenSource].clip = clips[clip];
        aSources[currenSource].Play();
        currenSource++;
        if(currenSource >= aSources.Length - 1)
        {
            currenSource = 0;
        }
    }
}
