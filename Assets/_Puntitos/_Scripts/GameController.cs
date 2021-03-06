﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    float time;
    public bool night;
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
    private PlayerController player;

    AudioSource aS;
    // Resucitar:
    public int deadCounter = 0;
    public ArrayList deadPositions;
    public GameObject cristalPrefab;
    public Text textLabel;

    void Awake()
    {
        aS = GetComponent<AudioSource>();
        deadPositions = new ArrayList();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        bolitasRestantes = currentBolitas;
        time = 0;
        night = false;
        StartCoroutine(SpawnEnemy());
        GenerateBolitas();
    }


    void GameOver()
    {

        GameObject.Find("SceneManager").GetComponent<MenuController>().pausa = true;
        StartCoroutine(ToMenu());
    }

    IEnumerator ToMenu()
    {
        yield return new WaitForSeconds(6f);
        MenuController menuController = GameObject.Find("SceneManager").GetComponent<MenuController>();
        StartCoroutine(menuController.Fade(false, 0, true));
    }


    void GenerateBolitas(){
        for (int i=0; i<bolitasRestantes; ++i)
        {
            Instantiate(resourcePrefab, SpawnPoint(), Quaternion.identity);
        }
    }


    void Update()
    {

        if(player._points.Count == 0)
        {
            aS.Play();
            GameOver();
        }

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
                textLabel.text = "DAY " + (daysCounter + 1).ToString();
                SpawnCristals();
                currentBolitas = player._points.Count / 2 - 1;
                if (bolitasRestantes > 0)
                {
                    // Pass nigth without recollect all resources
                    GameObject[] resources = GameObject.FindGameObjectsWithTag("Resource");
                    foreach(GameObject g in resources)
                    {
                        Destroy(g);
                    }
                    // Destroy people:
                    int toDestroy = Mathf.Clamp(player._points.Count-bolitasRestantes, 0, 1000);
                    for(int i=0; i<toDestroy; ++i)
                    {
                        GameObject tmp = (GameObject) player._points[0];
                        player._points.Remove(tmp);
                        tmp.GetComponent<Die>().Dead();
                    }
                }
                bolitasRestantes = currentBolitas;
                FindObjectOfType<RecogeRecursos>().Recalcula();
                maxEnemigos += 1;
                GenerateBolitas();
                StartCoroutine(SpawnEnemy());
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

    void SpawnCristals()
    {
        for(int i=0; i<deadCounter / 5; ++i)
        {
            Instantiate(cristalPrefab, (Vector3) deadPositions[Random.Range(0, deadPositions.Count-1)], Quaternion.identity);
        }

        deadCounter = 0;
        deadPositions.Clear();
    }
}
