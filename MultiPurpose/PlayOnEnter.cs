using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnEnter : MonoBehaviour
{
    public AudioSource track;
    public AudioSource Disabletrack;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if(!track.isPlaying)
            {
                track.Play();
                Disabletrack.Stop();
            }
        }
    }
}
