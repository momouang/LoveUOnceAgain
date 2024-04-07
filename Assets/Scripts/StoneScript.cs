using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScript : MonoBehaviour
{
    Animator anim;
    public Animator memoryAnim;
    public float waitingTime = 1.5f;

    public bool isTriggered;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            anim.SetTrigger("Used");
            if(!isTriggered)
            {
                StartCoroutine(PlayMemory());
            }


        }
    }

    IEnumerator PlayMemory()
    {
        yield return new WaitForSeconds(waitingTime);

        memoryAnim.SetTrigger("awakeMemory");
        isTriggered = true;
    }
}
