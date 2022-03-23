using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volume2D : MonoBehaviour
{
    public Transform listenerTransform;
    public AudioSource audioSource;
    public float minDist = 5;
    public float maxDist = 15;

    void Update()
    {
        float dist = Vector3.Distance(transform.position, listenerTransform.position);

        if (dist < minDist)
        {
            audioSource.volume = 2;
        }
        else if (dist > maxDist)
        {
            audioSource.volume = 0;
        }
        else
        {
            audioSource.volume = 2 - ((dist - minDist) / (maxDist - minDist));
        }
    }
}