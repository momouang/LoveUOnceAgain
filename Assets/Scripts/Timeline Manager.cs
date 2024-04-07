using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    private PlayableDirector director;
    public GameObject controlPanel;

    public PlayerMovement playerMovement;
    public AudioSource BGM;

    private void Awake()
    {
        director = GetComponent<PlayableDirector>();
        director.played += Director_Played;
        director.stopped += Director_Stopped;
    }

    private void Director_Stopped(PlayableDirector obj)
    {
        controlPanel.SetActive(true);
    }

    private void Director_Played(PlayableDirector obj)
    {
        controlPanel.SetActive(false);
    }

    public void StartTimeLine()
    {
        director.Play();
    }

    public void StartBGM()
    {
        BGM.Play();
    }

    public void StopMusic()
    {
        BGM.Stop();
    }

    public void SetPlayerState(MoveState state)
    {
        playerMovement.SetState(state);
    }
}
