using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceLight : MonoBehaviour
{
    // Start is called before the first frame update

    private float timer = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            timer = 0f;
        }
        timer+=Time.deltaTime;
        if(Input.GetMouseButtonUp(1))
        {
            Debug.Log(timer);
            GetComponent<Animator>().SetFloat("ButtonTimer",timer);
        }
        else
        {
            
            timer=0f;
            GetComponent<Animator>().SetFloat("ButtonTimer",timer);
        }
    }
}
