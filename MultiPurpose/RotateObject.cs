using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float degreesPerSecond = 50;

    void Update()
    {
        transform.Rotate(0f, 0f, 1f * degreesPerSecond * Time.deltaTime);
    }
}
