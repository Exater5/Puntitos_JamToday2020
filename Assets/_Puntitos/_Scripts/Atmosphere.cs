using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Atmosphere : MonoBehaviour
{
    // Start is called before the first frame update
    private GameController controller;

    public bool boolean = true;
    void Start()
    {
        controller = FindObjectOfType<GameController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.night == boolean)
        {
            gameObject.GetComponent<Volume>().weight = 1f;
          
        }
        else
        {
             gameObject.GetComponent<Volume>().weight = 0f;
        }
    }
}
