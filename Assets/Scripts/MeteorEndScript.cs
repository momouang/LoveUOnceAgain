using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MeteorEndScript : MonoBehaviour
{
    public static Action OnTrigger;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            EndSpawning();
        }
    }

    public void EndSpawning()
    {
        OnTrigger?.Invoke();
    }
}
