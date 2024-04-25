using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel: MonoBehaviour
{
    public bool onXAxis;
    public bool onYAxis;

    public LineRenderer lineRenderer;

    float currentPosY;
    float currentPosX;

    private void FixedUpdate()
    {
        //UnusedMoveMethod();
    }


    private void UnusedMoveMethod()
    {
        currentPosY = lineRenderer.transform.position.y;
        currentPosX = lineRenderer.transform.position.x;

        if (onXAxis)
        {
            Debug.Log(lineRenderer.GetPosition(0).x);
            Debug.Log(transform.position.x);
            transform.position = new Vector2(transform.position.x, currentPosY);

            if (currentPosX >= lineRenderer.GetPosition(0).x)
            {
                currentPosX = lineRenderer.GetPosition(0).x;
            }

            if (currentPosX <= lineRenderer.GetPosition(2).x)
            {
                currentPosX = lineRenderer.GetPosition(2).x;
            }
        }
        else if (onYAxis)
        {
            transform.position = new Vector2(currentPosX, transform.position.y);

            if (currentPosY >= lineRenderer.GetPosition(0).y)
            {
                currentPosY = lineRenderer.GetPosition(0).y;
            }

            if (currentPosY <= lineRenderer.GetPosition(2).y)
            {
                currentPosY = lineRenderer.GetPosition(2).y;
            }
        }

    }


}
