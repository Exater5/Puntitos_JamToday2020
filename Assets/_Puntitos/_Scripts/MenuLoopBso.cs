using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoopBso : MonoBehaviour
{
    [SerializeField]
    AudioSource bso1, bso2;
    bool played = false;
    [SerializeField]
    float loopTime;
    // Update is called once per frame
    private void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (bso1.time >= loopTime && !played)
        {
            played = true;
            bso2.Play();
        }
    }
    IEnumerator FadeOut()
    {
        for(float i = 0; i<=1; i += Time.deltaTime)
        {
            bso1.volume = 1 - i;
            bso2.volume = 1 - i;
            yield return null;
        }
    }
    public void CrPlayer()
    {
        StartCoroutine(FadeOut());
    }
}
