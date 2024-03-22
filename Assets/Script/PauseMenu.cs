using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool PauseGame = false;
    public GameObject pauseMenuUI;
    public Behaviour PauseCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseCanvas.enabled = !PauseCanvas.enabled;

            if (!PauseCanvas.enabled)
            {
                PauseGame = true;
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        PauseGame =  false;
        PauseCanvas.enabled = PauseCanvas.enabled;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Exit()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
