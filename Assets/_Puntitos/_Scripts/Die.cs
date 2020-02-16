﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    GameObject cam;

    public GameObject blood;
    public ParticleSystem explosion;

    void Update()
    {
        cam = Camera.main.gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Enemy")
        {
            FindObjectOfType<GameController>().deadCounter++;
            FindObjectOfType<GameController>().deadPositions.Add(other.transform.position);
            cam.GetComponent<CameraShake>().shakeDuration=0.01f;
            GameObject.Find("Player").GetComponent<PlayerController>()._points.Remove(gameObject);
            explosion.Play();
            Instantiate(blood,transform.position,Quaternion.Euler(Random.Range(0f,360f),Random.Range(0f,360f),0f));
            Destroy(gameObject);
        }
    }
}
