using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float waitingTime = 3f;

    public GameObject[] meteor;
    public Transform parent;

    public bool isSpawning;
    public bool isSpawned;

    private void OnEnable()
    {
        MeteorEndScript.OnTrigger += StopSpawninig;
    }

    private void OnDisable()
    {
        MeteorEndScript.OnTrigger -= StopSpawninig;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if (!isSpawning && !isSpawned)
            {
                isSpawning = true;
                isSpawned = true;
                StartSpawn();
            }
        }
    }

    public void StartSpawn()
    {
        StartCoroutine(SpawnMeteor());
    }

    private void StopSpawninig()
    {
        if(isSpawning)
        {
            isSpawning = false;
        }
    }

    IEnumerator SpawnMeteor()
    {
        yield return new WaitForSeconds(1f);

        while(isSpawning)
        {
            yield return new WaitForSeconds(waitingTime);
            Instantiate(meteor[Random.Range(0,meteor.Length)], spawnPoints[Random.Range(0,spawnPoints.Length)],false);
        }
    }
}
