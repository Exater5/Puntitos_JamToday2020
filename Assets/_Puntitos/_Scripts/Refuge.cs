using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refuge : MonoBehaviour
{

    public float _radius = 5f;

    void Update()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject e in objs)
        {
            if((e.transform.position - transform.position).magnitude <= _radius)
            {
                e.GetComponent<Enemy>().Flee();
            }
        }
    }
}
