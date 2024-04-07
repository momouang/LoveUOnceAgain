using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDrag : MonoBehaviour
{
    private Transform dragging = null;
    private Vector3 offset;
    private Vector3 initPosition;

    private bool isVertical = false;
    public RaycastHit hit;

    [SerializeField] private LayerMask movableObjects;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {


            if (Physics.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),transform.TransformDirection(Vector3.forward) ,out hit,Mathf.Infinity, movableObjects))
            {
                dragging = hit.transform;
                if (hit.transform.gameObject.GetComponent<Panel>().onXAxis)
                {
                    isVertical = false;
                }
                else
                {
                    isVertical = true;
                }

                offset = dragging.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

                initPosition = Camera.main.WorldToScreenPoint(hit.transform.position);
            }

        }

        else if(Input.GetMouseButtonUp(0))
        {
            dragging = null;
        }

        if(dragging != null)
        {
            if(isVertical)
            {
                dragging.position = Camera.main.ScreenToWorldPoint(new Vector3(initPosition.x, Input.mousePosition.y, Input.mousePosition.z) + offset);
            }
            else
            {
                dragging.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, initPosition.y, Input.mousePosition.z) + offset);
            }
        }
        
    }
}
