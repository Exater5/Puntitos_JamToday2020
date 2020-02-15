using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Malrollete : MonoBehaviour
{
    // Reference to Player (movement leader)
    private Vector3 _offset;
    [SerializeField] private float _bolitaRadius;
    public float time2move = 0.6f;
    public void RandomizeFollowingLeader()
    {
        Vector2 tmp = Random.insideUnitCircle;
        _offset = new Vector3(tmp.x, tmp.y, 0f) * _bolitaRadius;
    }

    void Start()
    {
        RandomizeFollowingLeader();
        StartCoroutine(move());
    }


    IEnumerator move()
    {
        Vector3 origPoint = transform.localPosition;
        for(float i=0; i<time2move; i+=Time.deltaTime){
          yield return null;
            transform.localPosition = Vector3.Lerp(origPoint, _offset, i/time2move);
        }
        RandomizeFollowingLeader();
        StartCoroutine(move());
    }
}
