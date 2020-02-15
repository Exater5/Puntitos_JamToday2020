using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceLight : MonoBehaviour
{
    // Start is called before the first frame update

    public float timer = 0f;
    public bool stopAnim = false;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            timer = 0f;
        }
        timer+=Time.deltaTime;
        if(Input.GetMouseButtonUp(1))
        {
            Debug.Log(timer);
            animator.SetFloat("ButtonTimer",timer);
            
        }
        if(stopAnim)
        {
            timer = 0f;
            animator.SetFloat("ButtonTimer",timer);

        }
    }
}
