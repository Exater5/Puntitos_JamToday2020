using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLoopBso : MonoBehaviour
{
    [SerializeField]
    AudioSource bso1, bso2;
    bool played, played2 = false;
    [SerializeField]
    float loopTime;
    [SerializeField]
    bool mainScene;
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
            played2 = false;
            bso2.time = 0;
            bso2.Play();
        }
        if (mainScene && bso2.time>= loopTime && !played2)
        {
            played2 = true;
            played = false;
            bso1.time = 0;
            bso1.Play();
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
