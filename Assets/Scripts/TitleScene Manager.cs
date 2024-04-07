using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TitleSceneManager : MonoBehaviour
{
    public PlayableDirector director;

    public bool isPlayed = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(!isPlayed)
            {
                director.Play();
                isPlayed = true;
            }

        }
    }
}
