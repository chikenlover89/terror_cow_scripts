using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCoordinates : MonoBehaviour
{
    public Transform endPosCoords;
    public Transform objectCoord;

    public AudioSource sound;

    void Update()
    {
        if (objectCoord.position == endPosCoords.position)
        {
            sound.Play();
        }
    }
}
