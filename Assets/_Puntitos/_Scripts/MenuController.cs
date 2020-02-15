using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    Image fadeImage;
    [SerializeField]
    float duration;
    [SerializeField]
    Color c1, c2;

    private void Start()
    {
        StartCoroutine(Fade(true, 0, false));
    }

    public void LoadMenu()
    {
        StartCoroutine(Fade(false, 0, true));
    }
    public void Salir()
    {
        Application.Quit();
    }
    public void LoadMainScene()
    {
        StartCoroutine(Fade(false, 1, true));
    }

    IEnumerator Fade(bool entrada, int scene, bool cargaEscena)
    {
        if (entrada) { fadeImage.color = c2; }

        for(float i = 0; i<= duration; i+= Time.deltaTime)
        {
            if (entrada)
            {
                fadeImage.color = Color.Lerp(c2, c1, i / duration);
            }
            else
            {
                fadeImage.color = Color.Lerp(c1, c2, i / duration);
            }
            yield return null;
        }
        if (entrada) { fadeImage.color = c1; }
        else { fadeImage.color = c2; }

        yield return null;

        if (cargaEscena)
        {
            SceneManager.LoadScene(scene);
        }

    }
}
