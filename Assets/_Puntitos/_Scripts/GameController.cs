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
    public int bolitasRestantes;
    [SerializeField]
    int currentBolitas;
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject resourcePrefab;

    [SerializeField]
    float minX, maxX, minY, maxY, spawnTime;
    [SerializeField]
    int enemigos, maxEnemigos;

    void Start()
    {
        bolitasRestantes = currentBolitas;
        time = 0;
        night = false;
        StartCoroutine(SpawnEnemy());
        GenerateBolitas();
    }


    void GenerateBolitas(){
        for (int i=0; i<bolitasRestantes; ++i)
        {
            Instantiate(resourcePrefab, SpawnPoint(), Quaternion.identity);
        }
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
                // Cambio de día:

                if (bolitasRestantes <= 0)
                {
                    bolitasRestantes = currentBolitas;
                    maxEnemigos += 1;
                    StartCoroutine(SpawnEnemy());
                }
                else
                {
                    // Pass nigth without recollect all resources
                    print("Pierdes");
                }
            }
        }   
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemyPrefab, SpawnPoint(), Quaternion.identity);
        enemigos++;
        yield return new WaitForSeconds(spawnTime);
        if(enemigos <= maxEnemigos)
        {
            StartCoroutine(SpawnEnemy());
        }
    }
    public Vector2 SpawnPoint()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        Vector2 sPoint = new Vector2(x, y);
        return sPoint;
    }
}
