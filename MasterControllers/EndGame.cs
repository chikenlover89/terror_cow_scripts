using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject endGame;
    public Timer timer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            endGame.SetActive(true);
            timer.stop();
        }
    }
}
