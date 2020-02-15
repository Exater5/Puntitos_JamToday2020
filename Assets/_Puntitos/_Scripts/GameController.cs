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
    [SerializeField]
    int currentBolitas;
    void Start()
    {
        bolitasRestantes = currentBolitas;
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
                if (bolitasRestantes <= 0)
                {
                    bolitasRestantes = currentBolitas;
                }
                else
                {
                    print("Pierdes");
                }
            }
        }   
    }
}
