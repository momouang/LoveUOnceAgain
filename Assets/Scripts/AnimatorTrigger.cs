using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTrigger : MonoBehaviour
{
    public Animator[] anim;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            anim[0].SetTrigger("playAnim");
        }
    }
}
