using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int lives = 10;
    private bool terrorOn = true;

    public int booster = 100;

    public GameObject terror;
    public Lives uiLives;
    public Booster uiBooster;

    public GameObject exlosion;

    public AudioSource explodeSound;
    void Start()
    {
        uiLives.setCount(lives);
    }

    void Update()
    {
        checkIfTerrorDead();
    }

    private void checkIfTerrorDead()
    {
        if (lives < 1 && terrorOn)
        {
            Instantiate(exlosion, terror.transform.position, terror.transform.rotation);
            terror.SetActive(false);
            terrorOn = false;
            explodeSound.Play();
        }
    }

    //// EXTERNAL FUNCTIONS ////

    public void setLives(int amount)
    {
        lives += amount;
        uiLives.setCount(lives);
    }

    public int getLives()
    {
        return lives;
    }

    public void setBooster(int amount)
    {
        uiBooster.setValue(amount);
    }

    public bool terrorIsOn()
    {
        return terrorOn;
    }
}
