using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class KeyTrigger : MonoBehaviour
{
    public PlayableDirector Timeline;

    public bool isPlayed;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isPlayed)
            {
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Timeline.Play();
                    isPlayed = true;
                }
            }
        }
    }
}
