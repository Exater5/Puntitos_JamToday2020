using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float speed = 0.02f;
    private Vector3 _target;
    [SerializeField] private GameObject _pointReference;
    [SerializeField] private int _initialPoints;
    public ArrayList _points;

    void Start()
    {
        _points = new ArrayList();
        _target = transform.position;
        // Instantiate Points:
        for(int i=0; i<_initialPoints; ++i)
        {
            _points.Add(Instantiate(_pointReference, transform.position, Quaternion.identity));
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _target, speed);
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 click = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            click.z = 0f;
            _target = click;
            foreach(GameObject g in GameObject.FindGameObjectsWithTag("point"))
            {
                g.GetComponent<Point>().RandomizeFollowingLeader();
            }
        }
    }
}
