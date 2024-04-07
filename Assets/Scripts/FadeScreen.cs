using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScreen : MonoBehaviour
{
    private Animator anim;
    public float fadeDuration = 1.5f;

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
        anim.SetTrigger("startFade");
        yield return new WaitForSeconds(fadeDuration);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 
}
