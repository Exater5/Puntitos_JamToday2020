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
    [SerializeField]
    Animator animMenuInGame;
    public AudioManager soundManager;
    [SerializeField]
    GameObject canvas;
    public bool pausa = false;
    private void Start()
    {
        soundManager = FindObjectOfType<AudioManager>();
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
        soundManager.PlaySound(0);
        StartCoroutine(Fade(false, 1, true));
    }
    public void Pausa()
    {
        soundManager.PlaySound(0);
        pausa = !pausa;
        if (pausa)
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            canvas.SetActive(false);
            Time.timeScale = 1;
        }
        animMenuInGame.SetBool("Pausa", pausa);
    }

    IEnumerator Fade(bool entrada, int scene, bool cargaEscena)
    {
        if (entrada) { fadeImage.color = c2; }

        for(float i = 0; i<= duration; i+= Time.unscaledDeltaTime)
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
