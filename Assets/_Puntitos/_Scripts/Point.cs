using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    // Reference to Player (movement leader)
    private GameObject leader;
    private Vector3 _offset;
    [SerializeField] private float _bolitaRadius;
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    private float _speed;

    public void RandomizeFollowingLeader()
    {
        Vector2 tmp = Random.insideUnitCircle;
        _speed = Random.Range(_minSpeed, _maxSpeed);
        _offset = new Vector3(tmp.x, tmp.y, 0f) * _bolitaRadius;
    }

    void Start()
    {
        RandomizeFollowingLeader();
        leader = GameObject.Find("Player");        
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, leader.transform.position + _offset, _speed);
    }
}
