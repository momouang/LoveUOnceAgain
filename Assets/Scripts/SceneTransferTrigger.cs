using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransferTrigger : MonoBehaviour
{
    public FadeScreen fadeScreen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            fadeScreen.StartFade();
        }
    }
}
