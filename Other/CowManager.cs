using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowManager : MonoBehaviour
{
    public Cow cow;
    private bool triggered = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!triggered)
            {
                cow.setMove(true);
                triggered = true;
            }
        }
    }
}
