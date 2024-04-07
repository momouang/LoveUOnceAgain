using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{
    public float translateSpeed_Right = 3f;
    public float translateSpeed_Down = 8f;

    private void Start()
    {
        StartCoroutine(DestroyMeteor());
    }

    public void Update()
    {
        transform.Translate(new Vector3(-1 * translateSpeed_Right, -1 * translateSpeed_Down, 0)  * Time.deltaTime);
    }

    IEnumerator DestroyMeteor()
    {
        yield return new WaitForSeconds(8f);
        Destroy(gameObject);
    }
}
