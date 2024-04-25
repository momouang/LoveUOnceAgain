using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public enum LockedAxis { XAxis, YAxis };
    public LockedAxis MoveAxis;
    public LineRenderer lineRenderer;
    public Vector2 MoveLimit;

    Vector3 offset;
    float mouseZ, startValue, endValue;

    private void Start()
    {
        if (MoveLimit[1] < MoveLimit[0])
        {
            float tmp = MoveLimit[0];
            MoveLimit[0] = MoveLimit[1];
            MoveLimit[1] = tmp;
        }
    }

    private void OnMouseDown()
    {
        mouseZ = Camera.main.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        Vector3 desiredPos = GetMouseWorldPosition() + offset;
        if (MoveAxis == LockedAxis.XAxis)
        {
            desiredPos.x = Mathf.Clamp(desiredPos.x, MoveLimit[0], MoveLimit[1]);
            desiredPos.y = transform.position.y;
        }
        else
        {
            desiredPos.y = Mathf.Clamp(desiredPos.y, MoveLimit[0], MoveLimit[1]);
            desiredPos.x = transform.position.x;
        }

        transform.position = desiredPos;
    }

    void DefineLineBoundaries()
    {
        float a = (MoveAxis == LockedAxis.XAxis) ? lineRenderer.GetPosition(0).x : lineRenderer.GetPosition(0).y;
        float b = (MoveAxis == LockedAxis.XAxis) ?
            lineRenderer.GetPosition(lineRenderer.positionCount - 1).x :
            lineRenderer.GetPosition(lineRenderer.positionCount - 1).y;
        if (a > b)
        {
            startValue = b; endValue = a;
        }
        else
        {
            startValue = a; endValue = b;
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mouseZ;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
