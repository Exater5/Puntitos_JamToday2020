using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float duration = 2f;
    private Vector3 _target;
    [SerializeField] private GameObject _pointReference;
    [SerializeField] private int _initialPoints;
    public ArrayList _points;
    Coroutine move;
    MenuController menu;

    void Start()
    {
        menu = GameObject.Find("SceneManager").GetComponent<MenuController>();
        _points = new ArrayList();
        _target = transform.position;
        // Instantiate Points:
        for(int i=0; i<_initialPoints; ++i)
        {
            _points.Add(Instantiate(_pointReference, transform.position, Quaternion.identity));
        }
    }

    void Update()
    {
        bool paused = menu.pausa;
        if(Input.GetMouseButtonDown(0) && !paused)
        {
            Vector3 click = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            click.z = 0f;
            _target = click;
            if(move != null)
            {
                StopCoroutine(move);
            }
            move = StartCoroutine(Move(_target));
            foreach(GameObject g in GameObject.FindGameObjectsWithTag("point"))
            {
                g.GetComponent<Point>().RandomizeFollowingLeader();
            }
        }
    }

    IEnumerator Move(Vector3 target)
    {
        Vector3 source = transform.position;
        for(float i=0; i<duration; i+=Time.deltaTime)
        {
            transform.position = Vector3.Lerp(source, target, i/duration);
            yield return null;
        }
        transform.position = target;
    }
}
