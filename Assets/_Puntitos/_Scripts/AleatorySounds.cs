using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AleatorySounds : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource[] aSources;
    int currenSource;
    public float minDelay, maxDelay;

    private void Start()
    {
        StartCoroutine(PlayAleatory());
    }
    public void PlaySound(int clip)
    {
        aSources[currenSource].clip = clips[clip];
        aSources[currenSource].Play();
        currenSource++;
        currenSource = currenSource % aSources.Length;
    }
    IEnumerator PlayAleatory()
    {
        int sound = Random.Range(0, clips.Length);
        PlaySound(sound);
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));
        StartCoroutine(PlayAleatory());
    }
}
