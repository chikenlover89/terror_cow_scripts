using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    public TerrorCow terrorCow;
    void Update()
    {
        faceMouse();
    }

    private void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
            );
        if (terrorCow.isFacingRight())
        {
            transform.right = direction;
        }
        else
        {
            transform.right = direction * -1;
        }
    }
}
