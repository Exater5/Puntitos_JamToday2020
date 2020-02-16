using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    private Transform puente;
    public float radius;

    void Start() 
    {
        puente = transform.GetChild(0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 pos = other.transform.position;
        if(other.transform.gameObject.tag == "point")
        {   
            if((pos - puente.position).magnitude > radius)
                other.transform.gameObject.GetComponent<Point>().multiplier = 0.1f;
        }       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.gameObject.tag == "point")
        {
            other.transform.gameObject.GetComponent<Point>().multiplier = 1f;
        }
    }
}
