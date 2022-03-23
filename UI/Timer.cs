using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;
    public Text displayTime;

    int time = 0;
    float delay = 1f;

    public bool stoped = false;
    void Update()
    {
        if (!stoped)
        {
            if (delay > 0)
            {
                delay -= Time.deltaTime;
            }
            else
            {
                time += 1;
                delay = 1f;
                timeText.text = time.ToString();
            }
        }
    }

    public void stop()
    {
        stoped = true;
        displayTime.text = time.ToString();
    }
}