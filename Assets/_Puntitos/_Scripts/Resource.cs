using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{

    [SerializeField] private float _pickRadius;
    private GameObject _player;
    private GameController gameController;

    void Start()
    {
        _player = GameObject.Find("Player");
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }


    void Pick()
    {
        gameController.bolitasRestantes -= 1;
        FindObjectOfType<RecogeRecursos>().RecogeRecurso();
        Destroy(gameObject);
    }


    void Update()
    {
        if((transform.position - _player.transform.position).magnitude <= _pickRadius)
        {
            Pick();
        }
    }
}
