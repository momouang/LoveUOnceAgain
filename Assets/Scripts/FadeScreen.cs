using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScreen : MonoBehaviour
{
    private Animator anim;
    public float fadeDuration = 1.5f;
    public bool isLastScene;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartFade()
    {
        StartCoroutine(Fading());
    }

    IEnumerator Fading()
    {
        if (!isLastScene)
        {
            anim.SetTrigger("startFade");
            yield return new WaitForSeconds(fadeDuration);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            anim.SetTrigger("startFade");
            yield return new WaitForSeconds(fadeDuration);

            SceneManager.LoadScene("Title");
        }
    } 
}
