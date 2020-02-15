using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour
{
    public float pickRadio;    
    PlayerController playerController;
    GameObject player; 
    public int points2Spawn;
    public GameObject _pointReference;

    void Start()
    {
        player = GameObject.Find("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if((player.transform.position - transform.position).magnitude < pickRadio)
        {
            Picked();
        }
    }

    void Picked()
    {
        for(int i=0; i<points2Spawn; ++i)
        {
            playerController._points.Add(Instantiate(_pointReference, player.transform.position, Quaternion.identity));
        }
        Destroy(gameObject);
    }
}
