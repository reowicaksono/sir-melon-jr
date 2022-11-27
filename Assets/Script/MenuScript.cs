using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject missionMenu;

    public static bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pause();
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else if (Input.GetKeyDown("tab"))
        {
            if (isPaused)
            {
                closeMission();
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                showMission();
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
    public void showMission()
    {
        missionMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }

    public void closeMission()
    {
        missionMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0;
    }


}
