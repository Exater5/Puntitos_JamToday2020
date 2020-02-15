using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceLight : MonoBehaviour
{
    // Start is called before the first frame update

    public float timer = 0f;
    public bool stopAnim = false;

    public float radius;

    private Animator animator;

    private GameObject[] enemies;
    void Start()
    {
        animator = GetComponent<Animator>();

        radius = (transform.position-transform.GetChild(0).transform.position).magnitude;
        
    }

    // Update is called once per frame
    void Update()
    {

        radius = (transform.position-transform.GetChild(0).transform.position).magnitude;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            if( (transform.position-enemy.transform.position).magnitude <=radius)
            {
                enemy.GetComponent<Enemy>().Attack();
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            timer = 0f;
        }
        timer+=Time.deltaTime;
        if(Input.GetMouseButtonUp(1))
        {
            animator.SetFloat("ButtonTimer",timer);
            
        }
        if(stopAnim)
        {
            timer = 0f;
            animator.SetFloat("ButtonTimer",timer);
        }

    }
}
