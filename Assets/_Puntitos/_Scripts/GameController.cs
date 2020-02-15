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

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        night = false;
    }

    // Update is called once per frame
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
            }
        }

    }
}
