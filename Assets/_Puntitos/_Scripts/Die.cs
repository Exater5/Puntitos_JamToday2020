using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    GameObject cam;

    public GameObject blood;
    public GameObject explosion;

    void Update()
    {
        cam = Camera.main.gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Enemy")
        {
            transform.localScale = new Vector3(0.07f,0.07f,0.07f);
            FindObjectOfType<GameController>().deadCounter++;
            FindObjectOfType<GameController>().deadPositions.Add(other.transform.position);
            cam.GetComponent<CameraShake>().shakeDuration=0.01f;
            GameObject.Find("Player").GetComponent<PlayerController>()._points.Remove(gameObject);
            Instantiate(blood,transform.position,Quaternion.Euler(Random.Range(0f,360f),Random.Range(0f,360f),0f));
            GameObject exp = Instantiate(explosion,transform.position,other.transform.rotation);
            exp.transform.LookAt((-1)*(other.transform.position));
            Destroy(gameObject,0.05f);
        }
    }

    void Dead()
    {
        transform.localScale = new Vector3(0.07f,0.07f,0.07f);
        cam.GetComponent<CameraShake>().shakeDuration=0.01f;
        GameObject.Find("Player").GetComponent<PlayerController>()._points.Remove(gameObject);
        Instantiate(blood,transform.position,Quaternion.Euler(Random.Range(0f,360f),Random.Range(0f,360f),0f));
        GameObject exp = Instantiate(explosion,transform.position,transform.rotation);
        Destroy(gameObject,0.05f);
    }
}
