using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{

    float originalScale;

    GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        cam = Camera.main.gameObject;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Enemy")
        {
            originalScale = Time.timeScale;
            cam.GetComponent<CameraShake>().shakeDuration=0.01f;
            //Time.timeScale = 0.05f;
            Destroy(gameObject);
            //Time.timeScale = originalScale;
        }
    }

    IEnumerator Wait()
    {
        for(float i=0; i<=0.01f; i+=Time.unscaledDeltaTime)
        {
            yield return null;
            

        }
        Time.timeScale = originalScale;
    }
}
