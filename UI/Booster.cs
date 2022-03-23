using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Booster : MonoBehaviour
{
    public Text thisText;
    public void setValue(int percent)
    {
        if (percent < 0)
        {
            percent = 0;
        }
        if (percent > 100)
        {
            percent = 100;
        }
        if (percent < 20)
        {
            thisText.color = Color.red;
        }
        else
        {
            thisText.color = Color.white;
        }
        thisText.text = percent.ToString();
    }
}
