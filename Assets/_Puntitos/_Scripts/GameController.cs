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
    int bolitasRestantes;
    [SerializeField]
    int currentBolitas;
    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    float minX, maxX, minY, maxY, spawnTime;

    void Start()
    {
        bolitasRestantes = currentBolitas;
        time = 0;
        night = false;
        StartCoroutine(SpawnEnemy());
    }

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
                if (bolitasRestantes <= 0)
                {
                    bolitasRestantes = currentBolitas;
                }
                else
                {
                    print("Pierdes");
                }
            }
        }   
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPoint(), Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnEnemy());
    }
    public Vector2 SpawnPoint()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        Vector2 sPoint = new Vector2(x, y);
        return sPoint;
    }
}
