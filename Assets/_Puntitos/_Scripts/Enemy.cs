using System.Collections;
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

    float speed = 10f;

    Transform player;

    Coroutine moveRoutine, launchRoutine;

    private bool attacking;

    public GameController controller;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        controller = FindObjectOfType<GameController>();
        moveRoutine = StartCoroutine(Traslada(RandomObjetive()));
        Debug.Log(controller.name);
    }

    IEnumerator Traslada(Vector2 pObjetivo)
    {
        Vector3 pos = transform.position;
        for (float i = 0; i<= duration; i+=Time.deltaTime)
        {
            transform.position = Vector2.Lerp(pos, pObjetivo, aC.Evaluate(i/duration));
            yield return null;
        }
        yield return new WaitForSeconds(retraso);
        moveRoutine = StartCoroutine(Traslada(RandomObjetive()));
    }

    public Vector2 RandomObjetive()
    {
        if(controller.night)
        {
            x = Random.Range(0.1f,0.9f);
            y = Random.Range(0.1f,0.9f);
            posObjetivo = new Vector2((player.position.x-transform.position.x)*x,(player.position.y-transform.position.y)*y);
            return posObjetivo;
        }
        else
        {
            x = Random.Range(transform.position.x - rango, transform.position.x + rango);
            y = Random.Range(transform.position.y - rango, transform.position.y + rango);
            x = Mathf.Clamp(x, minX, maxX);
            y = Mathf.Clamp(y, minY, maxY);
            posObjetivo = new Vector2(x, y);
            return posObjetivo;
        }
    }

    public void Attack()
    {
        if(!attacking)
        {
            launchRoutine = StartCoroutine(Launch(player.position));
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

        Vector3 position = transform.position;
        for (float i = 0; i<= duration; i+=Time.deltaTime*speed)
        {
            transform.position = Vector2.Lerp(position, pObjetivo, aC.Evaluate(i/duration));
            yield return null;
        }
        attacking=false;
        moveRoutine = StartCoroutine(Traslada(RandomObjetive()));
    }

    public void Flee()
    {
        if(moveRoutine!=null)
        {
            StopCoroutine(moveRoutine);
        }

        if(launchRoutine != null)
        {
            StopCoroutine(launchRoutine);
        }

        Vector3 objetive = (transform.position - player.position) * 1.5f;
        StartCoroutine(ReverseLaunch(objetive));
    }

    IEnumerator ReverseLaunch(Vector2 pObjetivo)
    {
        yield return new WaitForSeconds(0.5f);

        Vector3 position = transform.position;
        for (float i = 0; i<= duration; i+=Time.deltaTime)
        {
            transform.position = Vector2.Lerp(position, pObjetivo, aC.Evaluate(i/duration));
            yield return null;
        }
        attacking=false;
        moveRoutine = StartCoroutine(Traslada(RandomObjetive()));
    }

}
