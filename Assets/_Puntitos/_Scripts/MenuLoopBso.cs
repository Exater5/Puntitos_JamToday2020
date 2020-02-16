using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoopBso : MonoBehaviour
{
    [SerializeField]
    AudioSource bso1, bso2;
    bool played = false;
    [SerializeField]
    float fadeOutTime;
    // Update is called once per frame
    void Update()
    {
        print(bso1.time);
        if (played) { print("AHORA"); }
        if (bso1.time >= 30 && !played)
        {
            played = true;
            bso2.Play();
        }
    }
    public IEnumerator Juega()
    {
        for(float i = 0; i<=fadeOutTime; i += Time.deltaTime)
        {
            bso1.volume = 1 - i;
            bso2.volume = 1 - i;
            yield return null;
        }
    }
}
