using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public Text thisText;
    public void setCount(int lives)
    {
        if(lives < 0)
        {
            lives = 0;
        }
        thisText.text = lives.ToString();
    }

}
