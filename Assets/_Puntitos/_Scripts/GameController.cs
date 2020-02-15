using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    float time;
    bool night;
    int daysCounter;
    [SerializeField]
    float totalDuration;
    int bolitasRestantes;
    int bolitasIniciales;
    void Start()
    {
        bolitasRestantes = bolitasIniciales;
        time = 0;
        night = false;
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= totalDuration/2)
        {
            night = true;
            if (time >= totalDuration)
            {
                night = false;
                time = 0;
                daysCounter++;
                bolitasIniciales *= 2;
                bolitasRestantes = bolitasIniciales;
            }
        }
    }
}
