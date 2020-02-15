﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 posObjetivo;
    float x, y;
    [SerializeField]
    float minX, maxX, minY, maxY, rango, retraso;
    [SerializeField]
    float duration;
    [SerializeField]
    AnimationCurve aC, attackAnimationCurve;

    Transform player;

    Coroutine moveRoutine;

    private bool attacking;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveRoutine = StartCoroutine(Traslada(RandomObjetive()));

    }

    IEnumerator Traslada(Vector2 pObjetivo)
    {
        for (float i = 0; i<= duration; i+=Time.deltaTime)
        {
            transform.position = Vector2.Lerp(transform.position, pObjetivo, aC.Evaluate(i/duration));
            yield return null;
        }
        yield return new WaitForSeconds(retraso);
        moveRoutine = StartCoroutine(Traslada(RandomObjetive()));
    }

    public Vector2 RandomObjetive()
    {
        x = Random.Range(transform.position.x - rango, transform.position.x + rango);
        y = Random.Range(transform.position.y - rango, transform.position.y + rango);
        x = Mathf.Clamp(x, minX, maxX);
        y = Mathf.Clamp(y, minY, maxY);
        posObjetivo = new Vector2(x, y);
        return posObjetivo;
    }

    public void Attack()
    {
        if(!attacking)
        {
            StartCoroutine(Launch(player.position));
            attacking = true;

        }
    }

    
    IEnumerator Launch(Vector2 pObjetivo)
    {
        if(moveRoutine!=null)
        {
            StopCoroutine(moveRoutine);
        }
        yield return new WaitForSeconds(0.5f);

        for (float i = 0; i<= duration; i+=Time.deltaTime)
        {
            transform.position = Vector2.Lerp(transform.position, pObjetivo, attackAnimationCurve.Evaluate(i/duration));
            yield return null;
        }
        attacking=false;
        moveRoutine = StartCoroutine(Traslada(RandomObjetive()));
    }

}
