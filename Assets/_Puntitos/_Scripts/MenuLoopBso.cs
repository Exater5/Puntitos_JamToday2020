using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoopBso : MonoBehaviour
{
    [SerializeField]
    AudioSource bso1, bso2;
    bool played = false;
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
}
