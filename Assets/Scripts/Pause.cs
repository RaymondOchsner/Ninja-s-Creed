using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    public static bool paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (paused)
            {
                Resume();
            }
            else
                PauseGame();

    }


    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }
}
