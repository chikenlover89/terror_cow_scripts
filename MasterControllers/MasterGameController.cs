using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterGameController : MonoBehaviour
{
    public GameObject menu;
    public GameController cowManager;

    public float delay = 3f;

    private void Update()
    {
        manageMenuScreen();
    }

    private void manageMenuScreen()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (!menu.activeSelf)
            {
                menu.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
            }
        }

        if (!cowManager.terrorIsOn())
        {
            if (delay > 0)
            {
                delay -= Time.deltaTime;
            }
            else
            {
                if (!menu.activeSelf)
                {
                    menu.SetActive(true);
                }
            }
        }
    }
    public void loadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
