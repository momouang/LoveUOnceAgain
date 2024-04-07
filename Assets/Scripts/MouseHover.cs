using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    public GameObject sprite;

    public bool isHover = false;

    private void Start()
    {
        sprite.SetActive(false);
    }

    private void OnMouseOver()
    {
        isHover = true;
        sprite.SetActive(true);
    }

    private void OnMouseExit()
    {
        isHover = false;
        sprite.SetActive(false);
    }
}
